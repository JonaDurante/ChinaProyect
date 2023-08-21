using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioAdminData.DataAcces;
using StudioAdminData.Models.Business;

namespace StudioAdminData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdsController : ControllerBase
    {
        private readonly StudioAdminDBContext _context;

        public ThirdsController(StudioAdminDBContext context)
        {
            _context = context;
        }

        // GET: api/Thirds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Third>>> GetThirds()
        {
          if (_context.Thirds == null)
          {
              return NotFound();
          }
            return await _context.Thirds.ToListAsync();
        }

        // GET: api/Thirds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Third>> GetStudent(Guid id)
        {
          if (_context.Thirds == null)
          {
              return NotFound();
          }
            var third = await _context.Thirds.FindAsync(id);

            if (third == null)
            {
                return NotFound();
            }

            return third;
        }

        // PUT: api/Thirds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutStudent(Guid id, Third third)
        {
            if (id != third.Id)
            {
                return BadRequest();
            }

            _context.Entry(third).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Thirds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Third>> PostStudent(Third third)
        {
          if (_context.Thirds == null)
          {
              return Problem("Entity set 'StudioAdminDBContext.Thirds'  is null.");
          }
            _context.Thirds.Add(third);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = third.Id }, third);
        }

        // DELETE: api/Thirds/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (_context.Thirds == null)
            {
                return NotFound();
            }
            var third = await _context.Thirds.FindAsync(id);
            if (third == null)
            {
                return NotFound();
            }

            _context.Thirds.Remove(third);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(Guid id)
        {
            return (_context.Thirds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
