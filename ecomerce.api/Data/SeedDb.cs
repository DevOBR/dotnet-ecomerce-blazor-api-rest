
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
        await CheckCategoriesAsync();
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
