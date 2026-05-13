using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MiddleEarthTraderFront.Models;
using System.Diagnostics;

namespace MiddleEarthTraderFront.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IConfiguration _config;

        public ProfileController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            // appsettings.json'daki Api:BaseUrl değerini view'e gönderiyoruz
            ViewBag.ApiBaseUrl = _config["Api:BaseUrl"];
            return View();
        }
    }
}
