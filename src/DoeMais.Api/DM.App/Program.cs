using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DM.App;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

//builder.Services.AddHttpClient(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("DM.Api"));
//builder.Services.AddTransient<HttpClient>();

builder.Services.AddScoped(sp =>
new HttpClient
{
    BaseAddress = new Uri("https://localhost:7100/")
});

await builder.Build().RunAsync();
