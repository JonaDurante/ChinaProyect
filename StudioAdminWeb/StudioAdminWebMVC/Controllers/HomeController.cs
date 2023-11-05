using Microsoft.AspNetCore.Mvc;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.JWT;
using StudioAdminWebMVC.Models;
using System.Diagnostics;

namespace StudioAdminWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userServices;
        private readonly ILogger<AccountController> _logger;
        public HomeController(JwtSettings jwtSettings, IUserService userServices, ILogger<AccountController> logger)
        {
            _jwtSettings = jwtSettings;
            _userServices = userServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}