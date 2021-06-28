using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            // Leagues
            ViewBag.WomenLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();
            ViewBag.NotFootballLeagues = _context.Leagues
                .Where(l => !l.Sport.Contains("Football"))
                .ToList();
            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            // Teams
            ViewBag.DallasTeams = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();
            ViewBag.RaptorsTeams = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.CityTeams = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();
            ViewBag.TTeams = _context.Teams
                .Where(l => l.TeamName.StartsWith("T"))
                .ToList();
            ViewBag.OrderedLocation = _context.Teams
                .OrderBy(l => l.Location)
                .ToList();
            ViewBag.OrderedName = _context.Teams
                .OrderByDescending(l => l.TeamName)
                .ToList();
            // Players
            ViewBag.Cooper = _context.Players
                .Where(l => l.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.Joshua = _context.Players
                .Where(l => l.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.CooperNotJoshua = _context.Players
                .Where(l => l.LastName.Contains("Cooper") && !l.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.AlexanderAndWyatt = _context.Players
                .Where(l => l.FirstName.Contains("Alexander") || l.FirstName.Contains("Wyatt"))
                .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}