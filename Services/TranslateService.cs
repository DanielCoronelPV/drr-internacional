using System.Text.Json;
using System.Net.Http;
using Microsoft.JSInterop;

namespace DRR_PRESENTATION.Services.Translate
{
    public class TranslateService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private Dictionary<string, string> _translations = new();
        private const string StorageKey = "drr_language";

        public string CurrentLanguage { get; private set; } = "es"; // idioma por defecto
        public event Action? OnLanguageChanged;

        public TranslateService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
        }

        public async Task InitAsync()
        {
            try
            {
                var saved = await _js.InvokeAsync<string>("localStorage.getItem", StorageKey);
                var lang = string.IsNullOrEmpty(saved) ? "es" : saved;
                await LoadLanguageAsync(lang);
            }
            catch
            {
                await LoadLanguageAsync("es");
            }
        }

        public async Task LoadLanguageAsync(string lang)
        {
            try
            {
                var json = await _http.GetStringAsync($"i18n/{lang}.json");
                await _js.InvokeVoidAsync("console.log", $"[TranslateService] JSON loaded for {lang}: {json}");

                _translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new();
                await _js.InvokeVoidAsync("console.log", $"[TranslateService] Translation keys loaded: {_translations.Count}");

                CurrentLanguage = lang;
                await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, lang);
                OnLanguageChanged?.Invoke();
            }
            catch (Exception ex)
            {
                await _js.InvokeVoidAsync("console.error", $"[TranslateService] Error loading language {lang}: {ex.Message}");
                _translations = new Dictionary<string, string>();
                CurrentLanguage = lang;
                OnLanguageChanged?.Invoke();
            }
        }


        public string T(string key)
            => _translations.TryGetValue(key, out var val) ? val : key;

        public void DebugPrintTranslations()
        {
            foreach (var kv in _translations)
            {
                _js.InvokeVoidAsync("console.log", $"{kv.Key} => {kv.Value}");
            }
        }
    }
}
