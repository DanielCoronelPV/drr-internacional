using Microsoft.JSInterop;
using System.Text.Json;

public class TranslationService
{
    private Dictionary<string, string> _translations = new();
    private string _currentLanguage = "es"; // default languaje

    public event Action? OnLanguageChanged;
    public string CurrentLanguage => _currentLanguage;

    public async Task InitializeAsync(HttpClient http, IJSRuntime js)
    {
        // Call JS to get browser language
        string? browserLang = await js.InvokeAsync<string>("getBrowserLanguage");

        string lang = browserLang?.ToLowerInvariant() switch
        {
            var l when l.StartsWith("es") => "es",
            var l when l.StartsWith("pt") => "pt-BR",
            var l when l.StartsWith("zh") => "zh-CN",
            _ => "es"
        };

        await SetLanguageAsync(http, lang);
    }

    public async Task SetLanguageAsync(HttpClient http, string lang)
    {
        string path = lang switch
        {
            "es" => "assets/i18n/es.json",
            "pt-BR" => "assets/i18n/pt-BR.json",
            "zh-CN" => "assets/i18n/zh-CN.json",
            _ => "assets/i18n/es.json"
        };

        var json = await http.GetStringAsync(path);
        _translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json, new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        }) ?? new Dictionary<string, string>();

        _currentLanguage = lang;
        OnLanguageChanged?.Invoke();
    }

    public string Translate(string key)
    {
        return _translations.TryGetValue(key, out var value) ? value : key;
    }
}

