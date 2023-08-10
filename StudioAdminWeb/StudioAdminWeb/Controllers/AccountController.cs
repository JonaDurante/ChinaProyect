using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioAdminData.DataAcces;
using StudioAdminData.Helppers;
using StudioAdminData.Models.DataModels;

namespace StudioAdminData.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly StudioAdminDBContext _context;

        public AccountController(JwtSettings jwtSettings, StudioAdminDBContext context)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        [HttpPost]
        public IActionResult GetToken(UserLoggin userLoggin)
        {
            try
            {

                var Token = new UserToken();
                var searchUser = _context.Users
                    .Where(us =>us.Email == userLoggin.UserName && us.Password == userLoggin.Password)
                    .FirstOrDefault();

                if (searchUser != null)
                {
                    Token = JwtHelppers.GenerateTokenKey(new UserToken()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                }
                else 
                {
                    return BadRequest("Wrong credentials");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUsersList()
        { 
            return Ok(_context.Users.Where(x => x.IsDeleted == false).ToList());
        }

    }
}
