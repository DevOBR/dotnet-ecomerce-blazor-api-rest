using ecomerce.api.Repositories.Interfaces;
using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;

namespace ecomerce.api.UnitOfWork.Implementations;

public class StateUnitOfWork : GenericUnitOfWork<State>, IStateUnitOfWork
{
    private readonly IStateRepository _stateRepository;

    public StateUnitOfWork(IGenericRepository<State> repository, IStateRepository stateRepository) : base(repository)
    {
        this._stateRepository = stateRepository;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
        => await this._stateRepository.GetAsync();

    public override async Task<ActionResponse<State>> GetAsync(int id)
        => await this._stateRepository.GetAsync(id);
}
