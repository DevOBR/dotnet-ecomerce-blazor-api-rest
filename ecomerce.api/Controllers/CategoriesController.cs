using ecomerce.api.UnitOfWork.Interfaces;
using ecomerce.shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ecomerce.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : GenericController<Category>
{
    public CategoriesController(IGenericUnitOfWork<Category> unitOfWork)
        : base(unitOfWork)
    {
    }
}
