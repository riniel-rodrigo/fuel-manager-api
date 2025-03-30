using fuel_manager_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fuel_manager_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehiclesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Vehicles.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Vehicle model)
        {
            if(model.YearFab <=0 || model.YearModel <=0)
            {
                return BadRequest(new { message = "Ano de Fabricação e Ano de Modelo devem ser um número válido" });
            }
            _context.Vehicles.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Vehicles
                .Include(t => t.Consumptions)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            AddLinks(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Vehicle model)
        {
            if(id != model.Id) return BadRequest();

            var modelDb = _context.Vehicles.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modelDb == null) return NotFound();

            _context.Vehicles.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Vehicles.FindAsync(id);

            if (model == null) return NotFound();

            _context.Vehicles.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void AddLinks(Vehicle model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", method: "GET" ));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", method: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", method: "Delete"));
        }
    }
}
