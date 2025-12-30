using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Ven.AccessData.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Evitar ciclos: investigar

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();

// Add Swagger/OpenAPI services
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// Conexion a la base de datos en otro proyecto (assembly)

builder.Services.AddDbContext<DataContext>(x => 
    x.UseSqlServer("name=DefaultConnection", options => options.MigrationsAssembly("Ven.Backend")));

// Instalar servicio para sembrar datos en la base de datos

builder.Services.AddTransient<SeedDB>();

// Agregar CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .WithOrigins("https://localhost:7098") // Dominio de la aplicacion Blazor
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithExposedHeaders(new string[] { "Totalpages", "Counting" });
    });
});

var app = builder.Build();

// Ejecutar Servicio para sembrar datos en la base de datos

SeedData(app);

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // 1. NSwag
    app.UseSwaggerUi(options =>
    {
        options.Path = "/openapi";
        options.DocumentPath = "/openapi/v1.json";
    });

    // 2. Redoc
    app.UseReDoc(options =>
    {
        options.Path = "/opendoc";
        options.DocumentPath = "/openapi/v1.json";
    });

    // 3. Swagger Oficial
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

// Llamar el servicio de CORS

app.UseCors("AllowSpecificOrigin");

// Preparar el resto del pipeline

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

/*
 * Metodo para levantar una fabrica de 
 */

void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (IServiceScope? scope = scopedFactory!.CreateScope())
    {
        SeedDB? service = scope.ServiceProvider.GetService<SeedDB>();
        service!.SeedAsync().Wait();
    }
}