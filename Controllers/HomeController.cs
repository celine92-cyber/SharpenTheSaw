using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpenTheSaw.Models;
using SharpenTheSaw.Models.ViewModels;
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
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext bl)
        {
            _logger = logger;
            context = bl;
        }

        public IActionResult Index(long? bowlerteamid, string bowlerteam, int pageNum = 0)
        {
            int pageSize = 5;

            return View(new IndexViewModel

            {
                Bowlers = (context.Bowlers
                .Where(m => m.TeamId == bowlerteamid || bowlerteamid == null)
                .OrderBy(m => m.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //if no bowler is selected, then get the full count. Otherwise, only count the number
                    //from the bowler team that has been selected
                    TotalNumItems = (bowlerteamid == null ?  context.Bowlers.Count() :
                                    context.Bowlers.Where(x => x.TeamId == bowlerteamid).Count())
                },

                BowlerTeam = bowlerteam
            });
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
