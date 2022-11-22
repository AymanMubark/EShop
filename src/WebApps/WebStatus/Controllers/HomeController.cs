using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebStatus.Models;

namespace WebStatus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Redirect("/healthchecks-ui");
        }

    }
}