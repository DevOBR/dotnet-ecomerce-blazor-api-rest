using ecomerce.shared.Response;

namespace ecomerce.api.UnitOfWork.Interfaces;

public interface IGenericUnitOfWork<T> where T : class
{
    Task<ActionResponse<T>> GetAsync(int id);
    Task<ActionResponse<IEnumerable<T>>> GetAsync();
    Task<ActionResponse<T>> AddAsyc(T entity);
    Task<ActionResponse<T>> DeleteAsync(int id);
    Task<ActionResponse<T>> UpdateAsync(T entity);
}
