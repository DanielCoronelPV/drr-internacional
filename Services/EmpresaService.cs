using System.Net.Http.Headers;
using System.Text.Json;
using DRR_PRESENTATION.Models;

namespace DRR_PRESENTATION.Services;

public class EmpresaService
{
    private readonly HttpClient _httpClient;

    public EmpresaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Empresa?> ObtenerEmpresaAsync()
    {
        //EMPRESA
        var request = new HttpRequestMessage(HttpMethod.Get, "https://drrsystemas4.azurewebsites.net/Empresa?include=1&empresaID=2");
        //EMPRESA/SUCIRSAL
        //var request = new HttpRequestMessage(HttpMethod.Get, "https://drrsystemas4.azurewebsites.net/Empresa/Sucursal?sucursalID=&include=0");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "155E6F14-742F-47ED-9580-A8B604455B91");

        var response = await _httpClient.SendAsync(request);
        string responseContent = await response.Content.ReadAsStringAsync();

        //Console.WriteLine("Respuesta JSON:");

        //Console.WriteLine(responseContent);
        //using var jdoc = JsonDocument.Parse(responseContent);
        //string jsonBonito = JsonSerializer.Serialize(jdoc.RootElement, new JsonSerializerOptions
        //{
        //    WriteIndented = true
        //});

        //Console.WriteLine(jsonBonito);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
        }

        var empresaResponse = JsonSerializer.Deserialize<EmpresaResponse>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return empresaResponse?.Data.FirstOrDefault(); // ← Devolvemos la primera empresa
    }
}
