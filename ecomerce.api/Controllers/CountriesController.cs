using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ecomerce.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : GenericController<Country>
{
    private readonly ICountriesUnitOfWork _countriesUnitOfWork;

    public CountriesController(IGenericUnitOfWork<Country> unitOfWork, ICountriesUnitOfWork countriesUnitOfWork)
        : base(unitOfWork)
    {
        this._countriesUnitOfWork = countriesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await this._countriesUnitOfWork.GetAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return BadRequest(action.Message);
    }


    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var action = await this._countriesUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var action = await this._countriesUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return NotFound();
    }
}
