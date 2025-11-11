using System;
using ecomerce.api.Data;
using ecomerce.api.Helpers;
using ecomerce.api.Repositories.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ecomerce.api.Repositories.Implementations;

public class CitiesRepository : GenericRepository<City>, ICitiesRepository
{
    private readonly DataContext _context;

    public CitiesRepository(DataContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = this._context.Cities
            .Where(x => x.State.Id == pagination.Id)
            .AsQueryable();
        return new ActionResponse<IEnumerable<City>>
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
        var queryable = this._context.Cities
            .Where(x => x.State.Id == pagination.Id)
            .AsQueryable();

        double count = await queryable.CountAsync();

        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = (int)count
        };
    }
}
