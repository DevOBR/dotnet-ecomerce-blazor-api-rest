using ecomerce.shared.Entities;
using ecomerce.shared.Response;

namespace ecomerce.api.Repositories.Interfaces;

public interface ICountryRepository
{
    Task<ActionResponse<Country>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}
