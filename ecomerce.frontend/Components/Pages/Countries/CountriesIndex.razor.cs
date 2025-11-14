using ecomerce.frontend.Repositories;
using ecomerce.shared.Entities;
using Microsoft.AspNetCore.Components;

namespace ecomerce.frontend.Components.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject]
        private IRepository Repository { get; set; } = null!;
        private List<Country>? countries;
        protected override async Task OnInitializedAsync()
        {
            var httpResult = await Repository.GetAsync<List<Country>>("/api/countries");
            countries = httpResult.Response;
        }
    }
}