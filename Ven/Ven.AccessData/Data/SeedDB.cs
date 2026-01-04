
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
                    },
                    new State {
                        Name = "Amazonas",
                        Cities = new List<City>()
                        {
                            new City { Name = "Amazonas 1" },
                            new City { Name = "Amazonas 2" },
                            new City { Name = "Amazonas 3" },
                            new City { Name = "Amazonas 4" },
                            new City { Name = "Amazonas 5" },
                        }
                    },
                    new State {
                        Name = "Atlántico",
                        Cities = new List<City>()
                        {
                            new City { Name = "Atlántico 1" },
                            new City { Name = "Atlántico 2" },
                            new City { Name = "Atlántico 3" },
                            new City { Name = "Atlántico 4" },
                            new City { Name = "Atlántico 5" },
                        }
                    },
                    new State {
                        Name = "Bolívar",
                        Cities = new List<City>()
                        {
                            new City { Name = "Bolívar 1" },
                            new City { Name = "Bolívar 2" },
                            new City { Name = "Bolívar 3" },
                            new City { Name = "Bolívar 4" },
                            new City { Name = "Bolívar 5" },
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
                    },
                    new State {
                        Name = "California",
                        Cities = new List<City>()
                        {
                            new City { Name = " 1" },
                            new City { Name = " 2" },
                            new City { Name = " 3" },
                            new City { Name = " 4" },
                            new City { Name = " 5" },
                        }
                    },
                    new State {
                        Name = "Virginia",
                        Cities = new List<City>()
                        {
                            new City { Name = "Virginia 1" },
                            new City { Name = "Virginia 2" },
                            new City { Name = "Virginia 3" },
                            new City { Name = "Virginia 4" },
                            new City { Name = "Virginia 5" },
                        }
                    },
                    new State {
                        Name = "Ohio",
                        Cities = new List<City>()
                        {
                            new City { Name = "Ohio 1" },
                            new City { Name = "Ohio 2" },
                            new City { Name = "Ohio 3" },
                            new City { Name = "Ohio 4" },
                            new City { Name = "Ohio 5" },
                        }
                    },
                    new State {
                        Name = "Michigan",
                        Cities = new List<City>()
                        {
                            new City { Name = "Michigan 1" },
                            new City { Name = "Michigan 2" },
                            new City { Name = "Michigan 3" },
                            new City { Name = "Michigan 4" },
                            new City { Name = "Michigan 5" },
                        }
                    },
                    new State {
                        Name = "Arizona",
                        Cities = new List<City>()
                        {
                            new City { Name = "Arizona 1" },
                            new City { Name = "Arizona 2" },
                            new City { Name = "Arizona 3" },
                            new City { Name = "Arizona 4" },
                            new City { Name = "Arizona 5" },
                        }
                    },
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
