using rest_api.Models;
using rest_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace rest_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PastelController : ControllerBase
{
    public PastelController()
    {

    }
    [HttpGet]
    public ActionResult<List<Pastel>> getAll() =>
        PastelService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pastel> Get(int id)
    {
        var pastel = PastelService.Get(id);

        if (pastel is null) return NotFound();

        return pastel;
    }

    [HttpPost]
    public IActionResult Create(Pastel pastel)
    {
        PastelService.Add(pastel);
        return CreatedAtAction(nameof(Get), new { id = pastel.Id }, pastel);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pastel pastel)
    {
        if (id != pastel.Id)
        {
            return BadRequest();
        }

        var existingPastel = PastelService.Get(id);
        if (existingPastel is null)
        {
            return NotFound();
        }

        PastelService.Update(pastel);

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pastel = PastelService.Get(id);

        if (pastel is null) return NotFound();

        PastelService.Delete(id);

        return NoContent();
    }
}