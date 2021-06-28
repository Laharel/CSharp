using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using RandomPassCode.Models;



namespace RandomPassCode.Controllers
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

            return View();
        }
        public IActionResult Generate()
        {
            string[] mylist={"0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            Random rand = new Random();
            string passcode="";
            for (int i = 0; i < 14; i++)
            {
                passcode += mylist[rand.Next(0,mylist.Length)];
            }
            if(HttpContext.Session.GetInt32("Count")!=null)
            {
                int? Count=HttpContext.Session.GetInt32("Count");
                Count++;
                HttpContext.Session.SetInt32("Count",(int)Count);
            }
            else
            {
                HttpContext.Session.SetInt32("Count",1);
            }
            ViewBag.Passcode=passcode;
            ViewBag.Count= HttpContext.Session.GetInt32("Count");
            return View("Index");
        }
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return View("Index");
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
