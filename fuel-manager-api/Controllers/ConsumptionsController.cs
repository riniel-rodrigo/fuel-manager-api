using fuel_manager_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fuel_manager_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsumptionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Consumptions.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Consumption model)
        {
            _context.Consumptions.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Consumptions
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Consumption model)
        {
            if (id != model.Id) return BadRequest();

            var modelDb = _context.Consumptions.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modelDb == null) return NotFound();

            _context.Consumptions.Update(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Consumptions.FindAsync(id);

            if (model == null) return NotFound();

            _context.Consumptions.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
