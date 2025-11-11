
using ecomerce.shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        await CheckCountriesFullAsync();
    }

    private async Task CheckCountriesFullAsync()
    {
        if (!this._context.Countries.Any())
        {
            var countriesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql".Replace('\\', Path.DirectorySeparatorChar));
            await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
        }
    }

}
