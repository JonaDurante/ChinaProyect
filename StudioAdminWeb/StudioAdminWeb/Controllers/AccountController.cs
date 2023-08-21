using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioAdminData.DataAcces;
using StudioAdminData.Helppers;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.JWT;
using StudioAdminData.Models.Loggin;

namespace StudioAdminData.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userServices;

        public AccountController(JwtSettings jwtSettings, StudioAdminDBContext context, IUserService userServices)
        {
            _jwtSettings = jwtSettings;
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(UserLoggin userLoggin)
        {
            try
            {
                var Token = new UserToken();
                var searchUser = await _userServices.ValidateUserAsync(userLoggin);
                if (searchUser != null)
                {
                    JwtHelppers.Initialize(_userServices);
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
        public async Task<IActionResult> GetUsersList()
        { 
            return Ok(await _userServices.GetAllAsync());
        }

    }
}
