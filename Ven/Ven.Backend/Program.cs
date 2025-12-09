using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Ven.AccessData.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger/OpenAPI services
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// Conexion a la base de datos en otro proyecto (assembly)
builder.Services.AddDbContext<DataContext>(x => 
    x.UseSqlServer("name=DefaultConnection", options => options.MigrationsAssembly("Ven.Backend")));

var app = builder.Build();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
