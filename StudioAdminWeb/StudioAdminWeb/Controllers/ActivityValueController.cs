using Microsoft.AspNetCore.Mvc;
using StudioAdminData.DataAcces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudioAdminWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityValueController : ControllerBase
    {
        // GET: api/<ActivityValueController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ActivityValueController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ActivityValueController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActivityValueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActivityValueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
