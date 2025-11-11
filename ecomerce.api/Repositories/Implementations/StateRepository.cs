using ecomerce.api.Data;
using ecomerce.api.Helpers;
using ecomerce.api.Repositories.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ecomerce.api.Repositories.Implementations;

public class StateRepository : GenericRepository<State>, IStateRepository
{
    private readonly DataContext _context;

    public StateRepository(DataContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = this._context.States
            .Include(x => x.Cities)
            .Where(x => x.Country.Id == pagination.Id)
            .AsQueryable();
        return new ActionResponse<IEnumerable<State>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = this._context.States
            .Where(x => x.Country.Id == pagination.Id)
            .AsQueryable();

        double count = await queryable.CountAsync();

        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = (int)count
        };
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        var countries = await this._context.States.Include(x => x.Cities).ToListAsync();

        return new ActionResponse<IEnumerable<State>>
        {
            WasSuccess = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<State>> GetAsync(int id)
    {
        var country = await this._context.States.Include(x => x.Cities).FirstOrDefaultAsync(x => x.Id == id);
        if (country is null)
        {
            return new ActionResponse<State>
            {
                WasSuccess = true,
                Message = "Data not found"
            };
        }

        return new ActionResponse<State>
        {
            WasSuccess = true,
            Result = country
        };
    }
}
