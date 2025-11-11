using ecomerce.shared;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;

namespace ecomerce.api.UnitOfWork.Interfaces;

public interface IStatesUnitOfWork
{
    Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination);
    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    Task<ActionResponse<State>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<State>>> GetAsync();
}
