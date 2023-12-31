using AfiliacionesCirsa;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AfiliacionesCirsa.ViewModels;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ClienteAfiliadoService>();
builder.Services.AddScoped<UsuarioAfiliadorService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<IRecentClientsViewModel, RecentClientsViewModel>();
builder.Services.AddTransient<ILoginViewModel, LoginViewModel>();
builder.Services.AddTransient<IRegisterViewModel, RegisterViewModel>();
builder.Services.AddTransient<IHomePageViewModel, HomePageViewModel>();
builder.Services.AddTransient<IProfileViewModel, ProfileViewModel>();
builder.Services.AddTransient<IClienteSearchViewModel, ClienteSearchViewModel>();
builder.Services.AddTransient<IDashboardViewModel,  DashboardViewModel>();
builder.Services.AddTransient<IRegisterAfiliadosViewModel, RegisterAfiliadosViewModel>();

await builder.Build().RunAsync();
