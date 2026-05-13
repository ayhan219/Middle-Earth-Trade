using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MiddleEarthTraderFront.Controllers
{
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IConfiguration _config;

        public EventsController(ILogger<EventsController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // appsettings.json'daki Api:BaseUrl deðerini view'e gönderiyoruz
            ViewBag.ApiBaseUrl = _config["Api:BaseUrl"];
            return View();
        }
    }
}