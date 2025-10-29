using System;
using System.Formats.Asn1;
using ecomerce.api.Data;
using ecomerce.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecomerce.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly DataContext dataContext;

    public CountriesController(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await this.dataContext.Countries.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Country country)
    {
        this.dataContext.Add(country);
        await this.dataContext.SaveChangesAsync();
        return Ok(country);
    }
}
