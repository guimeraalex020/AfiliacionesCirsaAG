using AfiliacionesCirsa;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AfiliacionesCirsa.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ClienteAfiliadoService>();
builder.Services.AddScoped<UsuarioAfiliadorService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<IFetchDataViewModel, FetchDataViewModel>();
builder.Services.AddTransient<ILoginViewModel, LoginViewModel>();



await builder.Build().RunAsync();
