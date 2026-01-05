# Ven

Aprendizaje en .NET Core Web API, Blazor Assembly y SQL Server

# Fuente

https://www.youtube.com/playlist?list=PLDNoyuGg6hYfwQcg5wnBn-BCvU8FUV1eL

# Aprendizajes

1. Conexion a la base de datos en otro proyecto (assembly)

    builder.Services.AddDbContext<DataContext>(x => 
        x.UseSqlServer("name=DefaultConnection", options => options.MigrationsAssembly("Ven.Backend")));

2. CORS para mejorar la seguridad

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

    app.UseCors("AllowSpecificOrigin");

3. Comandos EF (https://learn.microsoft.com/en-us/ef/core/cli/powershell)

    - Install-Package Microsoft.EntityFrameworkCore.Tools
    - Update-Package Microsoft.EntityFrameworkCore.Tools

    - Cada cambio en el modelo de las entidades de las bases de datos
        1. add-migration CambiosBaseDatos
        2. update-database
    
    - Cuando se desea limpiar la base de datos para con SeedDB.cs se agreguen los cambios
        1. drop-database

4. EF, SWAG y REDOC

5. HttpResponseWrapper

6. Inyeccion de dependencias en Blazor
    
    [Inject] private IRepository _repository { get; set; }

7. Pasar variables por encabezados 

    context.Response.Headers.Append("Counting", conteo.ToString());
    context.Response.Headers.Append("TotalPages", totalPaginas.ToString());


