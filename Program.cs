using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using frontendApi.HttpInterceptors;
using frontendApi;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




//adding serivces to be injected
//builder.Services.AddScoped(sp => new HttpClient(new HttpInterceptor(null)) { BaseAddress = new Uri("https://localhost:44320") });
//builder.Services.AddTransient<HttpInterceptor>();

builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient(new HttpInterceptor(sp.GetRequiredService<ILocalStorageService>()))
    {
        BaseAddress = new Uri("http://localhost:5268")
    };

    return httpClient;
});


//builder.Services
//    .AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri("https://localhost:44320"))
//    .AddHttpMessageHandler<HttpInterceptor>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddBlazoredLocalStorage();




builder.Services.AddMudServices();

await builder.Build().RunAsync();

