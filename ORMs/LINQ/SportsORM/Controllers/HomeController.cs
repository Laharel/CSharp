﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // Teams
            ViewBag.Atlantic = _context.Teams
                .Include(l => l.CurrLeague)
                .Where(l => l.CurrLeague.Name.Contains("Soccer"));
            // players
            ViewBag.Penguins = _context.Players
                .Include(l => l.CurrentTeam.CurrentPlayers)
                .Where(l => l.CurrentTeam.Location.Contains("Location") && l.CurrentTeam.TeamName.Contains("Penguins"));
            ViewBag.Baseball = _context.Players
                .Include(l => l.CurrentTeam.CurrentPlayers)
                .Where(l => l.CurrentTeam.CurrLeague.Name.Contains("Collegiate"));
            ViewBag.Lopez = _context.Players
                .Include(l => l.CurrentTeam)
                .Where(l => l.CurrentTeam.CurrLeague.Name.Contains("Amateur") && l.CurrentTeam.CurrLeague.Sport.Contains("Football") && l.FirstName.Contains("Lopez"));
            ViewBag.Football = _context.Players
                .Include(l => l.CurrentTeam)
                .Where(l => l.CurrentTeam.CurrLeague.Sport.Contains("Football"));
            ViewBag.SophiaTeams = _context.Players
                .Include(l => l.CurrentTeam.CurrentPlayers)
                .Where(l => l.FirstName.Contains("Sophia"));
            ViewBag.SophiaLeagues = _context.Players
                .Include(l => l.CurrentTeam.CurrLeague)
                .Where(l => l.FirstName.Contains("Sophia"));
            ViewBag.Flores = _context.Players
                .Include(l => l.CurrentTeam)
                .Where(l => l.LastName.Contains("Flores") && !l.CurrentTeam.TeamName.Contains("Washington Roughriders"));
                
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}