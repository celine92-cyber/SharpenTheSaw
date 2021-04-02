using Microsoft.AspNetCore.Mvc;
using SharpenTheSaw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpenTheSaw.Components
{
    public class BowlerTeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;

        //constructor
        public BowlerTeamViewComponent(BowlingLeagueContext bl)
        {
            context = bl;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["bowlerteam"];

            return View(context.Teams
                .Distinct()
                .OrderBy(X => X)
                .ToList());
        }
    }
}
