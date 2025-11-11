using ecomerce.api.Repositories.Interfaces;
using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;

namespace ecomerce.api.UnitOfWork.Implementations;

public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
{
    private readonly ICitiesRepository _citiesRepository;

    public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
    {
        this._citiesRepository = citiesRepository;
    }

    public override Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
        => this._citiesRepository.GetAsync(pagination);

    public override Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        => this._citiesRepository.GetTotalRecordsAsync(pagination);
}
