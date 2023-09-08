using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;
using StudioAdminData.Models.JWT;
using StudioAdminData.Models.Loggin;
using StudioAdminWeb.Helppers;

namespace StudioAdminWeb.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{versio:ApiVersion}[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userServices;
        private readonly ILogger<AccountController> _logger;
        public AccountController(JwtSettings jwtSettings, IUserService userServices, ILogger<AccountController> logger)
        {
            _jwtSettings = jwtSettings;
            _userServices = userServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Loggin(UserLoggin userLoggin)
        {
            try
            {
                var Token = new UserToken();
                var searchUser = await _userServices.ValidateUserAsync(userLoggin);
                if (searchUser != null)
                {
                    Token = GetToken(searchUser);
                }
                else
                {
                    return BadRequest("Wrong credentials");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to generate the Token");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewUser(User NewUser)
        {
            try
            {
                var Token = new UserToken();
                if (NewUser != null)
                {
                    if (await _userServices.InsertAsync(NewUser))
                    {
                        Token = GetToken(NewUser);
                    }
                }
                else
                {
                    return BadRequest("Wrong credentials");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to generate the Token for a new User");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> GetUsersList()
        {
            return Ok(await _userServices.GetAllAsync());
        }

        private UserToken GetToken(User? user)
        {
            var Token = new UserToken();
            if (user != null)
            {
                Token = JwtHelppers.GenerateTokenKey(new UserToken()
                {
                    UserName = user.Name,
                    EmailId = user.Email,
                    Id = user.Id,
                    GuidId = Guid.NewGuid(),
                }, _jwtSettings, user.Roles);
            }
            return Token;
        }

    }
}
