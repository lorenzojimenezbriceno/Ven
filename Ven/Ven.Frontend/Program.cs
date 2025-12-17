using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ven.Frontend;
using Ven.Frontend.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7206") });

// Manejar el SweetAlert2 de mensajes por toda la aplicacion
builder.Services.AddSweetAlert2();

builder.Services.AddScoped<IRepository, Repository>();

await builder.Build().RunAsync();
