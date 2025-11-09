using ecomerce.shared.Entities;
using ecomerce.shared.Response;

namespace ecomerce.api.Repositories.Interfaces;

public interface IStateRepository
{
    Task<ActionResponse<State>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<State>>> GetAsync();
}
