using ecomerce.api.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecomerce.api.Controllers;

public class GenericController<T> : Controller where T : class
{
    private readonly IGenericUnitOfWork<T> _unitOfWork;

    public GenericController(IGenericUnitOfWork<T> unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAsync()
    {
        var action = await this._unitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetAsync(int id)
    {
        var action = await this._unitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return NotFound();
    }

    [HttpPost]
    public virtual async Task<IActionResult> PostAsync(T model)
    {
        var action = await this._unitOfWork.AddAsyc(model);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return BadRequest(action.Message);
    }

    [HttpPut]
    public virtual async Task<IActionResult> PutAsync(T model)
    {
        var action = await this._unitOfWork.UpdateAsync(model);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }

        return BadRequest(action.Message);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> DeleteAsync(int id)
    {
        var action = await this._unitOfWork.DeleteAsync(id);
        if (action.WasSuccess)
        {
            return NoContent();
        }

        return BadRequest(action.Message);
    }

}
