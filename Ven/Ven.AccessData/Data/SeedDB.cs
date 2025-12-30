
using System.Xml.Linq;
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
            context.Countries.Add(new Country()
            {
                Name = "Colombia",
                States = new List<State>()
                {
                    new State {
                        Name = "Antioquia",
                        Cities = new List<City>()
                        {
                            new City { Name = "Medellin" },
                            new City { Name = "Itagui" },
                            new City { Name = "Envigado" },
                            new City { Name = "Bello" },
                            new City { Name = "Rionegro" },
                        }
                    },
                    new State {
                        Name = "Bogota",
                        Cities = new List<City>()
                        {
                            new City { Name = "Usaquen" },
                            new City { Name = "Champineo" },
                            new City { Name = "Santa fe" },
                            new City { Name = "Useme" },
                            new City { Name = "Bosa" },
                        }
                    }
                }
            });

            context.Countries.Add(new Country()
            {
                Name = "Estados Unidos",
                States = new List<State>()
                {
                    new State {
                        Name = "Florida",
                        Cities = new List<City>()
                        {
                            new City { Name = "Orlando" },
                            new City { Name = "Miami" },
                            new City { Name = "Tampa" },
                            new City { Name = "Fort Lauderdale" },
                            new City { Name = "Key West" },
                        }
                    },
                    new State {
                        Name = "Texas",
                        Cities = new List<City>()
                        {
                            new City { Name = "Houston" },
                            new City { Name = "San Antonio" },
                            new City { Name = "Dallas" },
                            new City { Name = "Austin" },
                            new City { Name = "El Paso" },
                        }
                    }
                }
            });

            /*
             * OTRA FORMA
             
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
            */

            await context.SaveChangesAsync();
       }
    }
}
