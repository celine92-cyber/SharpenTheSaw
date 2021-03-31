using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpenTheSaw.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SharpenTheSaw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BowlingLeagueContext context;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext bl)
        {
            _logger = logger;
            context = bl;
        }

        public IActionResult Index()
        {
            return View(context.Bowlers.ToList());
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
