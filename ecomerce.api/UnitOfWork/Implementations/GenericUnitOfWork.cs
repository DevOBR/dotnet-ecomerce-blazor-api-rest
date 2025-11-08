using ecomerce.api.Repositories.Interfaces;
using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared.Response;

namespace ecomerce.api.UnitOfWork.Implementations;

public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericUnitOfWork(IGenericRepository<T> repository)
    {
        this._repository = repository;
    }

    public virtual async Task<ActionResponse<T>> AddAsyc(T entity)
        => await this._repository.AddAsync(entity);

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        => await this._repository.DeleteAsync(id);

    public virtual async Task<ActionResponse<T>> GetAsync(int id)
        => await this._repository.GetAsync(id);

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        => await this._repository.GetAsync();

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        => await this._repository.UpdateAsync(entity);
}
