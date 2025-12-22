using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ven.AccessData.Data;
using Ven.Backend.Helpers;
using Ven.Shared.Entities;

namespace Ven.Backend.Controllers;

[Route("api/countries")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly DataContext _context;

    public CountriesController(DataContext context)
    {
        _context = context;
    }

    // GET: api/countries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountries([FromQuery] PaginationDTO pagination)
    {
        var queryable = _context.Countries.AsQueryable();
        await HttpContext.InsertParameterPagination(queryable, pagination.RecordsNumber);

        return await queryable.OrderBy(x => x.Name).Paginate(pagination).ToListAsync();
    }

    // GET: api/countries/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Country>> GetCountry(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id invalido");
        }

        var country = await _context.Countries.FindAsync(id);
        if (country == null)
        {
            return NotFound("No existge el registro solicitado");
        }

        return country;
    }

    // PUT: api/countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    public async Task<IActionResult> PutCountry(Country country)
    {
        if (country.Id <= 0)
        {
            return BadRequest("Id invalido");
        }

        if (CountryExists(country.Name, country.Id))
        {
            return BadRequest("Ya existe un registro con el mismo nombre.");
        }

        _context.Entry(country).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(country.Name))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok();
    }

    // POST: api/countries
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(Country country)
    {
        if (CountryExists(country.Name))
        {
            return BadRequest("Ya existe un registro con el mismo nombre.");
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(country.Name))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCountry", new { id = country.Id }, country);
    }

    // DELETE: api/countries/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        var country = await _context.Countries.FindAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();

        return Ok();
    }

    private bool CountryExists(string name)
    {
        return _context.Countries.Any(e => e.Name.ToLower() == name.Trim().ToLower());
    }

    private bool CountryExists(string name, int Id)
    {
        return _context.Countries.Any(e => e.Name.ToLower() == name.Trim().ToLower() && e.Id != Id);
    }
}
