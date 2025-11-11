using ecomerce.api.Data;
using ecomerce.api.Helpers;
using ecomerce.api.Repositories.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ecomerce.api.Repositories.Implementations;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    private readonly DataContext _context;

    public CountryRepository(DataContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = this._context.Countries
            .Include(x => x.States)
            .AsQueryable();
        return new ActionResponse<IEnumerable<Country>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    {
        var countries = await this._context.Countries.Include(x => x.States).ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            WasSuccess = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<Country>> GetAsync(int id)
    {
        var country = await this._context.Countries
            .Include(x => x.States!)
            .ThenInclude(x => x.Cities)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (country is null)
        {
            return new ActionResponse<Country>
            {
                WasSuccess = false,
                Message = "Data was not found."
            };
        }

        return new ActionResponse<Country>
        {
            WasSuccess = true,
            Result = country
        };
    }
}
