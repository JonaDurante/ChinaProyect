using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;

namespace StudioAdminData.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{versio:ApiVersion}[controller]")]
    [ApiController]
    public class ThirdsController : ControllerBase
    {
        private readonly IThirdServices _thirdServices;

        public ThirdsController(IThirdServices thirdServices)
        {
            _thirdServices = thirdServices;
        }

        // GET: api/Thirds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Third>>> GetThirds()
        {
            var AllThird = await _thirdServices.GetAllAsync();
            if (AllThird == null)
            {
                return NotFound();
            }
            return Ok(AllThird.ToList());
        }

        // GET: api/Thirds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Third>> GetThirdById(Guid id)
        {
            var CurrentThird = await _thirdServices.GetByIdAsync(id);
            if (CurrentThird == null)
            {
                return NotFound();
            }
            return Ok(CurrentThird);
        }

        // PUT: api/Thirds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutThird(Guid id, Third third)
        {
            if (id != third.Id)
            {
                return BadRequest();
            }

            var result = await _thirdServices.UpdateAsync(third);
            if (!result)
            {
                return NotFound("Hubo un error al intentar actualizar.");
            }

            return Ok("Se actualizó satisfactoriamente.");
        }

        // POST: api/Thirds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Third>> PostThird(Third third)
        {
            await _thirdServices.InsertAsync(third);
            return CreatedAtAction("GetThirdById", new { id = third.Id }, third);
        }

        // DELETE: api/Thirds/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteThird(Guid id)
        {
            var result = await _thirdServices.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
