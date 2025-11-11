using ecomerce.api.Repositories.Interfaces;
using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using ecomerce.shared.Response;

namespace ecomerce.api.UnitOfWork.Implementations;

public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
{
    private readonly ICountryRepository _countryRepository;

    public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountryRepository countryRepository) : base(repository)
    {
        this._countryRepository = countryRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination)
        => await this._countryRepository.GetAsync(pagination);

    public override async Task<ActionResponse<Country>> GetAsync(int id)
        => await this._countryRepository.GetAsync(id);

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
        => await this._countryRepository.GetAsync();

}
