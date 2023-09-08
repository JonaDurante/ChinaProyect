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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseServices _courseServices;

        public CoursesController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var Courses = await _courseServices.GetAllAsync();
            if (Courses == null)
            {
                return NotFound();
            }
            return Ok(Courses);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var course = await _courseServices.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutCourse(Course course)
        {

            //if (await _courseServices.UpdateAsync(course)) { return Ok(); }
            //else if (await _courseServices.GetByIdAsync(course.Id) == null) { return NotFound(); }
 
            if (await _courseServices.UpdateAsync(course)) { return Ok(); }
            else if (await _courseServices.GetByIdAsync(course.Id) == null) { return NotFound(); }
            else { return NoContent(); }
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            if (await _courseServices.InsertAsync(course))
            {
                return Ok(course);
            }
            else {
                return NoContent();
            }            
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            if (await _courseServices.DeleteAsync(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
