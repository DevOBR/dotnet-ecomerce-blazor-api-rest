using ecomerce.api.Repositories.Interfaces;
using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;

namespace ecomerce.api.UnitOfWork.Implementations;

public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
{
    private readonly IStateRepository _stateRepository;

    public StatesUnitOfWork(IGenericRepository<State> repository, IStateRepository stateRepository) : base(repository)
    {
        this._stateRepository = stateRepository;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
        => await this._stateRepository.GetAsync(pagination);

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        => await this._stateRepository.GetTotalRecordsAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
        => await this._stateRepository.GetAsync();

    public override async Task<ActionResponse<State>> GetAsync(int id)
        => await this._stateRepository.GetAsync(id);
}
