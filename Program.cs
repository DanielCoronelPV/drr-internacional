using DRR_PRESENTATION;
using DRR_PRESENTATION.Services;
using DRR_PRESENTATION.Services.Translate;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<EmpresaService>();

// Inyección correcta de TranslateService con HttpClient e IJSRuntime
builder.Services.AddScoped<TranslateService>(sp =>
{
    var http = sp.GetRequiredService<HttpClient>();
    var js = sp.GetRequiredService<IJSRuntime>();
    return new TranslateService(http, js);
});

await builder.Build().RunAsync();
