using System.Net.Http.Headers;
using System.Text.Json;
using DRR_PRESENTATION.Models;

namespace DRR_PRESENTATION.Services;

public class EmpresaService
{
    private readonly HttpClient _httpClient;

    // 🔑 Token entregado por tu backend
    private const string TOKEN = "FCAD75CE-4971-4A4C-B1F4-9BEF5411FD37";

    public EmpresaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // 📌 Obtener Empresa usando el token fijo
    public async Task<Empresa?> ObtenerEmpresaAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "https://drrsystemas4.azurewebsites.net/Empresa?include=1&empresaID=2");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);

        var response = await _httpClient.SendAsync(request);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}\n{responseContent}");

        var empresaResponse = JsonSerializer.Deserialize<EmpresaResponse>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return empresaResponse?.Data.FirstOrDefault();
    }
}
