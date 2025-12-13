# Ven
Software para venta e productos en .NET Core Web API, Blazor Assembly y SQL Server

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

3. EF, SWAG y REDOC

4. HttpResponseWrapper

5. Inyeccion de dependencias en Blazor
    
    [Inject] private IRepository _repository { get; set; }