using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,MyContext context)
        {
            _logger = logger;
            dbcontext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbcontext.Dishes.ToList();
            ViewBag.AllDishes = AllDishes;
            return View();
        }
        [HttpGet("/new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost("/new")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbcontext.Dishes.Add(newDish);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }
        [HttpGet("/{id}")]
        public IActionResult Details(int id)
        {
            Dish oneDish=dbcontext.Dishes.FirstOrDefault(p => p.DishId== id);
            return View(oneDish);
        }
        [HttpGet("/{id}/Delete")]
        public IActionResult Delete(int id)
        {
            Dish oneDish=dbcontext.Dishes.SingleOrDefault(p => p.DishId== id);
            dbcontext.Dishes.Remove(oneDish);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("/{id}/edit")]
        public IActionResult Edit(int id)
        {
            Dish oneDish=dbcontext.Dishes.FirstOrDefault(p => p.DishId== id);
            return View(oneDish);
        }
        [HttpPost("/{id}/edit")]
        public IActionResult Updated(Dish updated,int id)
        {
            Dish oneDish=dbcontext.Dishes.FirstOrDefault(p => p.DishId== id);
            if(ModelState.IsValid)
            {
                oneDish.Name = updated.Name;
                oneDish.Chef = updated.Chef;
                oneDish.Tastiness = updated.Tastiness;
                oneDish.Calories = updated.Calories;
                oneDish.Description = updated.Description;
                oneDish.UpdatedAt = DateTime.Now;
                
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }
        [HttpGet("/privacy")]
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
