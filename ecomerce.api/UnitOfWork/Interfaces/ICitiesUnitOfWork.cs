using ecomerce.shared;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;

namespace ecomerce.api.UnitOfWork.Interfaces;

public interface ICitiesUnitOfWork
{
    Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);
    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
}
