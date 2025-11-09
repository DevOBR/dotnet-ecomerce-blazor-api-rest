using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ecomerce.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    private IStateUnitOfWork _stateUnitOfWork;

    public StatesController(IGenericUnitOfWork<State> unitOfWork, IStateUnitOfWork stateUnitOfWork) : base(unitOfWork)
    {
        this._stateUnitOfWork = stateUnitOfWork;
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
