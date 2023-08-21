using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;
using StudioAdminData.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudioAdminWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityValueController : ControllerBase
    {
        private readonly IActivityValueService _activityValueService;
        public ActivityValueController(IActivityValueService activityValueService)
        {
            _activityValueService = activityValueService;
        }
        // GET: api/<ActivityValueController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityValue>>> Get()
        {
            var Actividies = await _activityValueService.GetAllValuesAsync();
            if (Actividies == null)
            {
                return NotFound();
            }
            return Ok(Actividies);
        }

        // GET api/<ActivityValueController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityValue>> Get(int codigo)
        {
            var Activity = await _activityValueService.GetActivityValueAsync(codigo);
            if (Activity == null)
            {
                return NotFound();
            }
            return Ok(Activity);
        }

        // POST api/<ActivityValueController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActivityValue activityValue)
        {
            if (await _activityValueService.UpdateAsync(activityValue))
            {
                return Ok();
            }
            else { return NoContent(); }
        }

        // PUT api/<ActivityValueController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put([FromBody] ActivityValue value)
        {
            if (await _activityValueService.InsertAsync(value))
            {
                return Ok(true);
            }
            else { return NoContent(); }
        }

        // DELETE api/<ActivityValueController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int ActivityQuantity)
        {
            if (await _activityValueService.DeletAsync(ActivityQuantity))
            {
                return Ok(true);
            }
            return BadRequest("Error occurred during activity delete.");
        }
    }
}
