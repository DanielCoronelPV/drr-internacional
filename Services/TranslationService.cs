//using System.Text.Json;

//public class TranslationService
//{
//    private Dictionary<string, Dictionary<string, string>> _translations = new();
//    private string _currentLanguage = "es"; // idioma por defecto

//    // Evento que los componentes pueden suscribirse
//    public event Action? OnLanguageChanged;

//    public string CurrentLanguage => _currentLanguage;

//    public async Task LoadTranslations(HttpClient http)
//    {
//        var json = await http.GetStringAsync("assets/i18n/translation.json");
//        _translations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json)
//                        ?? new Dictionary<string, Dictionary<string, string>>();
//    }

//    public void SetLanguage(string lang)
//    {
//        if (_translations.ContainsKey(lang) && _currentLanguage != lang)
//        {
//            _currentLanguage = lang;
//            OnLanguageChanged?.Invoke(); // notifica a los componentes
//        }
//    }

//    public string Translate(string key)
//    {
//        if (_translations.TryGetValue(_currentLanguage, out var langDict) &&
//            langDict.TryGetValue(key, out var value))
//        {
//            return value;
//        }

//        return key; // fallback
//    }
//}

using System.Text.Json;

public class TranslationService
{
    private Dictionary<string, string> _translations = new();
    private string _currentLanguage = "es"; // idioma por defecto

    public event Action? OnLanguageChanged;
    public string CurrentLanguage => _currentLanguage;

    // Cargar un idioma desde su archivo JSON
    public async Task SetLanguageAsync(HttpClient http, string lang)
    {
        // Construir ruta al archivo JSON correspondiente
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

