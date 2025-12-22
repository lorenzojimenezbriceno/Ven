
using Ven.Shared.Entities;

namespace Ven.AccessData.Data;

public class SeedDB
{
    private readonly DataContext context;

    public SeedDB(DataContext context)
    {
        this.context = context;
    }

    public async Task SeedAsync()
    {
        await context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
    }

    private async Task CheckCountriesAsync()
    {
       if (!context.Countries.Any())
       {
            await context.Countries.AddRangeAsync(new List<Country>()
            {
                new Country { Name = "Andorra" },
                new Country { Name = "Belgica" },
                new Country { Name = "Belorusia" },
                new Country { Name = "Canada" },
                new Country { Name = "China" },
                new Country { Name = "Corea" },
                new Country { Name = "Colombia" },
                new Country { Name = "Costa Rica" },
                new Country { Name = "El Salvador" },
                new Country { Name = "Espana" },
                new Country { Name = "Estados Unidos" },
                new Country { Name = "Dinamarca" },
                new Country { Name = "Nicaragua" },
                new Country { Name = "Honduras" },
                new Country { Name = "Italia" },
                new Country { Name = "Reino Unido" },
                new Country { Name = "Rusia" },
                new Country { Name = "Suiza" },
            });
            await context.SaveChangesAsync();
       }
    }
}
