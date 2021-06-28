using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;

namespace Dojodachi.Controllers
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
            Pet Dojodachi = new Pet();
            HttpContext.Session.SetInt32("Happiness", Dojodachi.Happiness);
            HttpContext.Session.SetInt32("Fullness", Dojodachi.Fullness);
            HttpContext.Session.SetInt32("Energy", Dojodachi.Energy);
            HttpContext.Session.SetInt32("Meals", Dojodachi.Meals);
            HttpContext.Session.SetString("msg", "Let's start the game!");
            return RedirectToAction("Dojodachi");
        }

        public IActionResult Dojodachi()
        {
            int Happiness = Convert.ToInt32(HttpContext.Session.GetInt32("Happiness"));
            int Fullness = Convert.ToInt32(HttpContext.Session.GetInt32("Fullness"));
            int Energy = Convert.ToInt32(HttpContext.Session.GetInt32("Energy"));
            int Meals = Convert.ToInt32(HttpContext.Session.GetInt32("Meals"));
            string msg = HttpContext.Session.GetString("msg");
            Pet Dojodachi = new Pet(Happiness, Fullness, Energy, Meals);
            if(Dojodachi.Dead && Dojodachi.Win){
                return RedirectToAction("Index");
            } else if (Dojodachi.Dead){
                ViewBag.Dead = Dojodachi.Dead;
                ViewBag.Win = Dojodachi.Win;
                msg = Dojodachi.End();
            } else if(Dojodachi.Win){
                ViewBag.Win = Dojodachi.Win;
                ViewBag.Dead = Dojodachi.Dead;
                msg = Dojodachi.End();
            }
            else {
                ViewBag.Win = Dojodachi.Win;
                ViewBag.Dead = Dojodachi.Dead;
                ViewBag.msg =Dojodachi.End();
            }
            ViewBag.msg = msg;
            return View(Dojodachi);
        }
        public IActionResult Feed()
        {
            int Happiness = Convert.ToInt32(HttpContext.Session.GetInt32("Happiness"));
            int Fullness = Convert.ToInt32(HttpContext.Session.GetInt32("Fullness"));
            int Energy = Convert.ToInt32(HttpContext.Session.GetInt32("Energy"));
            int Meals = Convert.ToInt32(HttpContext.Session.GetInt32("Meals"));
            Pet Dojodachi = new Pet(Happiness, Fullness, Energy, Meals);
            string msg = Dojodachi.Feed();
            HttpContext.Session.SetInt32("Fullness", Dojodachi.Fullness);
            HttpContext.Session.SetInt32("Meals", Dojodachi.Meals);
            HttpContext.Session.SetString("msg", msg);

            return RedirectToAction("Dojodachi");
        }
        public IActionResult Play()
        {   
            int Happiness = Convert.ToInt32(HttpContext.Session.GetInt32("Happiness"));
            int Fullness = Convert.ToInt32(HttpContext.Session.GetInt32("Fullness"));
            int Energy = Convert.ToInt32(HttpContext.Session.GetInt32("Energy"));
            int Meals = Convert.ToInt32(HttpContext.Session.GetInt32("Meals"));
            Pet Dojodachi = new Pet(Happiness, Fullness, Energy, Meals);
            string msg = Dojodachi.Play();
            HttpContext.Session.SetInt32("Happiness", Dojodachi.Happiness);
            HttpContext.Session.SetInt32("Energy", Dojodachi.Energy);
            HttpContext.Session.SetString("msg", msg);

            return RedirectToAction("Dojodachi");
        }
        public IActionResult Work()
        {
            int Happiness = Convert.ToInt32(HttpContext.Session.GetInt32("Happiness"));
            int Fullness = Convert.ToInt32(HttpContext.Session.GetInt32("Fullness"));
            int Energy = Convert.ToInt32(HttpContext.Session.GetInt32("Energy"));
            int Meals = Convert.ToInt32(HttpContext.Session.GetInt32("Meals"));
            Pet Dojodachi = new Pet(Happiness, Fullness, Energy, Meals);
            string msg = Dojodachi.Work();
            HttpContext.Session.SetInt32("Energy", Dojodachi.Energy);
            HttpContext.Session.SetInt32("Meals", Dojodachi.Meals);
            HttpContext.Session.SetString("msg", msg);

            return RedirectToAction("Dojodachi");
        }

        public IActionResult Sleep()
        {
            int Happiness = Convert.ToInt32(HttpContext.Session.GetInt32("Happiness"));
            int Fullness = Convert.ToInt32(HttpContext.Session.GetInt32("Fullness"));
            int Energy = Convert.ToInt32(HttpContext.Session.GetInt32("Energy"));
            int Meals = Convert.ToInt32(HttpContext.Session.GetInt32("Meals"));
            Pet Dojodachi = new Pet(Happiness, Fullness, Energy, Meals);
            string msg = Dojodachi.Sleep();
            HttpContext.Session.SetInt32("Energy", Dojodachi.Energy);
            HttpContext.Session.SetInt32("Happiness", Dojodachi.Happiness);
            HttpContext.Session.SetInt32("Fullness", Dojodachi.Fullness);
            HttpContext.Session.SetString("msg", msg);

            return RedirectToAction("Dojodachi");

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
