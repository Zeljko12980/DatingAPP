using API.Services.Destinacija;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinacijaController: ControllerBase
    {
         private readonly IDestinacijaService _destinacijaService;

        public DestinacijaController(IDestinacijaService destinacijaService)
        {
            _destinacijaService = destinacijaService;
        }

        // GET: api/Destinacija
        [HttpGet]
        public async Task<ActionResult<IEnumerable<API.Entities.Destinacija>>> GetDestinacije()
        {
            var destinacije = await _destinacijaService.GetAllAsync();
            return Ok(destinacije);
        }

        // GET: api/Destinacija/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<API.Entities.Destinacija>> GetDestinacija(int id)
        {
            var destinacija = await _destinacijaService.GetByIdAsync(id);
            if (destinacija == null)
                return NotFound();

            return Ok(destinacija);
        }

        // POST: api/Destinacija
        [HttpPost]
        public async Task<ActionResult<API.Entities.Destinacija>> CreateDestinacija(API.Entities.Destinacija destinacija)
        {
            var created = await _destinacijaService.CreateAsync(destinacija);
            return CreatedAtAction(nameof(GetDestinacija), new { id = created.Id }, created);
        }

        // PUT: api/Destinacija/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDestinacija(int id, API.Entities.Destinacija destinacija)
        {
            if (id != destinacija.Id)
                return BadRequest();

            var updated = await _destinacijaService.UpdateAsync(destinacija);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Destinacija/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinacija(int id)
        {
            var deleted = await _destinacijaService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}