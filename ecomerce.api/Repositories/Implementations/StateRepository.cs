using ecomerce.api.Data;
using ecomerce.api.Repositories.Interfaces;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ecomerce.api.Repositories.Implementations;

public class StateRepository : GenericRepository<State>, IStateRepository
{
    private readonly DataContext _dataContext;

    public StateRepository(DataContext dataContext) : base(dataContext)
    {
        this._dataContext = dataContext;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        var countries = await this._dataContext.States.Include(x => x.Cities).ToListAsync();

        return new ActionResponse<IEnumerable<State>>
        {
            WasSuccess = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<State>> GetAsync(int id)
    {
        var country = await this._dataContext.States.Include(x => x.Cities).FirstOrDefaultAsync(x => x.Id == id);
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
