using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiddleEarthTraderFront.Models;

namespace MiddleEarthTraderFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
       
            ViewBag.ApiBaseUrl = _config["Api:BaseUrl"];
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.ApiBaseUrl = _config["Api:BaseUrl"];
            return View();
        }

        [HttpGet]
        public IActionResult Trader()
        {
            ViewBag.ApiBaseUrl = _config["Api:BaseUrl"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
