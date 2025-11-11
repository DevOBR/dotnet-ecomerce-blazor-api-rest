using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ecomerce.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesControllers : GenericController<City>
    {
        private readonly ICitiesUnitOfWork _citiesUnitOfWork;

        public CitiesControllers(IGenericUnitOfWork<City> unitOfWork, ICitiesUnitOfWork citiesUnitOfWork) : base(unitOfWork)
        {
            this._citiesUnitOfWork = citiesUnitOfWork;
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await this._citiesUnitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }

            return BadRequest(action.Message);
        }

        [HttpGet("totalRecords")]
        public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await this._citiesUnitOfWork.GetTotalRecordsAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }

            return BadRequest(action.Message);
        }
    }
}
