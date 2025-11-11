using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared;
using ecomerce.shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ecomerce.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    private IStatesUnitOfWork _stateUnitOfWork;

    public StatesController(IGenericUnitOfWork<State> unitOfWork, IStatesUnitOfWork stateUnitOfWork) : base(unitOfWork)
    {
        this._stateUnitOfWork = stateUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await this._stateUnitOfWork.GetAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return BadRequest(action.Message);
    }

    [HttpGet("totalRecords")]
    public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await this._stateUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return BadRequest(action.Message);
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var action = await this._stateUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var action = await this._stateUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return NotFound();
    }

}
