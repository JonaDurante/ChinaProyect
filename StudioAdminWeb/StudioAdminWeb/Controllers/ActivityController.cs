using Microsoft.AspNetCore.Mvc;
using StudioAdminData.Controllers;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudioAdminWeb.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{versio:ApiVersion}[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        // GET: api/<ActivityController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> Get()
        {
            var Actividies = await _activityService.GetAllAsync();
            if (Actividies == null)
            {
                return NotFound();
            }
            return Ok(Actividies);
        }

        // GET api/<ActivityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Get(Guid id)
        {
            var Activity = await _activityService.GetByIdAsync(id);
            if (Activity == null)
            {
                return NotFound();
            }
            return Ok(Activity);
        }

        // POST api/<ActivityController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Activity activityValue)
        {
            if (await _activityService.UpdateAsync(activityValue))
            {
                return Ok();
            }
            else { return NoContent(); }
        }

        // PUT api/<ActivityController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put([FromBody] Activity value)
        {
            if (await _activityService.InsertAsync(value))
            {
                return Ok(true);
            }
            else { return NoContent(); }
        }

        // DELETE api/<ActivityController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid Id)
        {
            if (await _activityService.DeleteAsync(Id))
            {
                return Ok(true);
            }
            return BadRequest("Error occurred during activity delete.");
        }
    }
}
