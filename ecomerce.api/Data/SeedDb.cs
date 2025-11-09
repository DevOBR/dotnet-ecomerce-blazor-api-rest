
using ecomerce.shared.Entities;

namespace ecomerce.api.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        this._context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
        await CheckStatesAsync();
        await CheckCitiessync();
        await CheckCategoriesAsync();
    }

    private async Task CheckCitiessync()
    {
        if (!this._context.Cities.Any())
        {
            this._context.Cities.Add(new City { Name = "Apodaca", StateId = 1 });
            this._context.Cities.Add(new City { Name = "Santa Catarina", StateId = 1 });
            this._context.Cities.Add(new City { Name = "Puebla", StateId = 2 });
            this._context.Cities.Add(new City { Name = "Cholula", StateId = 2 });
            await this._context.SaveChangesAsync();
        }
    }

    private async Task CheckStatesAsync()
    {
        if (!this._context.States.Any())
        {
            this._context.States.Add(new State { Name = "Nuevo Leon", CountryId = 1 });
            this._context.States.Add(new State { Name = "Puebla", CountryId = 1 });
            await this._context.SaveChangesAsync();
        }
    }

    private async Task CheckCategoriesAsync()
    {
        if (!this._context.Categories.Any())
        {
            this._context.Categories.Add(new Category { Name = "Calzado" });
            this._context.Categories.Add(new Category { Name = "Tecnología" });
            await this._context.SaveChangesAsync();
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!this._context.Countries.Any())
        {
            this._context.Countries.Add(new Country { Name = "México" });
            this._context.Countries.Add(new Country { Name = "Bolivia" });
            await this._context.SaveChangesAsync();
        }
    }
}
