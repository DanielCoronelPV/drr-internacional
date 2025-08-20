using System.Text.Json;

public class TranslationService
{
    private Dictionary<string, Dictionary<string, string>> _translations = new();
    private string _currentLanguage = "es"; // idioma por defecto

    // Evento que los componentes pueden suscribirse
    public event Action? OnLanguageChanged;

    public string CurrentLanguage => _currentLanguage;

    public async Task LoadTranslations(HttpClient http)
    {
        var json = await http.GetStringAsync("assets/i18n/translation.json");
        _translations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)
                        ?? new Dictionary<string, Dictionary<string, string>>();
    }

    public void SetLanguage(string lang)
    {
        if (_translations.ContainsKey(lang) && _currentLanguage != lang)
        {
            _currentLanguage = lang;
            OnLanguageChanged?.Invoke(); // notifica a los componentes
        }
    }

    public string Translate(string key)
    {
        if (_translations.TryGetValue(_currentLanguage, out var langDict) &&
            langDict.TryGetValue(key, out var value))
        {
            return value;
        }

        return key; // fallback
    }
}
