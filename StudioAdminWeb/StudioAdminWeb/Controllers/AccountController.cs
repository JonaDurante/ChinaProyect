using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioAdminData.Helppers;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.JWT;
using StudioAdminData.Models.Loggin;

namespace StudioAdminData.Controllers
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
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> GetToken(UserLoggin userLoggin)
        {
            try
            {
                var Token = new UserToken();
                var searchUser = await _userServices.ValidateUserAsync(userLoggin);
                if (searchUser != null)
                {
                    Token = JwtHelppers.GenerateTokenKey(new UserToken()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings, searchUser.Roles);
                }
                else
                {
                    return BadRequest("Wrong credentials");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar generar el Token");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
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
