using Microsoft.EntityFrameworkCore;
using Ven.Shared.Entities;

namespace Ven.AccessData.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    // Definicion de tablas

    public DbSet<Country> Countries => Set<Country>();
    public DbSet<State> States => Set<State>();
    public DbSet<City> Cities => Set<City>();

    // Configuración del modelo de datos

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Restricciones

        modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<State>().HasIndex(x => new { x.Name, x.StateId }).IsUnique();
        modelBuilder.Entity<City>().HasIndex(x => new { x.Name, x.StateId }).IsUnique();

        // Para evitar eliminaciones en cascada accidentales
        
        DisableCascadingDelete(modelBuilder);
    }

    // Para evitar que haya borrados totales

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationships)
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
