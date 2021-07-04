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
            ViewBag.Chefs = dbcontext.Chefs.Include(l => l.Dishes);
            return View();
        }
        [HttpGet("/Chef/new")]
        public IActionResult NewChef()
        {
            return View();
        }
        [HttpPost("/Chef/new")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                newChef.Age = DateTime.Today.Year - newChef.DoB.Year;
                dbcontext.Chefs.Add(newChef);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }
        [HttpGet("/Chef/{id}")]
        public IActionResult ChefDetails(int id)
        {
            
            Chef oneChef=dbcontext.Chefs.FirstOrDefault(l => l.ChefId== id);
            return View(oneChef);
        }
        [HttpGet("/Chef/{id}/delete")]
        public IActionResult DeleteChef(int id)
        {
            Chef oneChef=dbcontext.Chefs.SingleOrDefault(l => l.ChefId== id);
            dbcontext.Chefs.Remove(oneChef);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("/Chef/{id}/edit")]
        public IActionResult EditChef(int id)
        {
            Chef oneChef=dbcontext.Chefs.FirstOrDefault(l=> l.ChefId== id);
            return View(oneChef);
        }
        [HttpPost("/Chef/{id}/edit")]
        public IActionResult UpdatedChef(Chef updated,int id)
        {
            Chef oneChef=dbcontext.Chefs.FirstOrDefault(l => l.ChefId== id);
            if(ModelState.IsValid)
            {
                oneChef.FirstName = updated.FirstName;
                oneChef.LastName = updated.LastName;
                oneChef.DoB = updated.DoB;
                oneChef.Age = DateTime.Today.Year - updated.DoB.Year;;
                oneChef.UpdatedAt = DateTime.Now;
                
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditChef");
            }
        }
        [HttpGet("/Dishes")]
        public IActionResult Dishes()
        {
            ViewBag.Dishes = dbcontext.Dishes.Include(l => l.Cook);
            return View();
        }
        [HttpGet("/Dish/new")]
        public IActionResult NewDish()
        {
            ViewBag.Chefs = dbcontext.Chefs;
            return View();
        }
        [HttpPost("/Dish/new")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                newDish.Cook=dbcontext.Chefs.FirstOrDefault(l => l.ChefId==newDish.ChefId);
                dbcontext.Dishes.Add(newDish);
                dbcontext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return View("NewDish");
            }
        }
        [HttpGet("/Dish/{id}")]
        public IActionResult DishDetails(int id)
        {
            Dish oneDish=dbcontext.Dishes.FirstOrDefault(l => l.DishId== id);
            return View(oneDish);
        }
        [HttpGet("/Dish/{id}/delete")]
        public IActionResult DeleteDish(int id)
        {
            Dish oneDish=dbcontext.Dishes.SingleOrDefault(l => l.DishId== id);
            dbcontext.Dishes.Remove(oneDish);
            dbcontext.SaveChanges();
            return RedirectToAction("Dishes");
        }
        [HttpGet("/Dish/{id}/edit")]
        public IActionResult EditDish(int id)
        {
            ViewBag.Chefs = dbcontext.Chefs;
            Dish oneDish=dbcontext.Dishes.FirstOrDefault(l => l.DishId== id);
            return View(oneDish);
        }
        [HttpPost("/Dish/{id}/edit")]
        public IActionResult UpdatedDish(Dish updated,int id)
        {
            Dish oneDish=dbcontext.Dishes.FirstOrDefault(l => l.DishId== id);
            if(ModelState.IsValid)
            {
                oneDish.Name = updated.Name;
                oneDish.ChefId = updated.ChefId;
                oneDish.Cook = dbcontext.Chefs.FirstOrDefault(l => l.ChefId==updated.ChefId);
                oneDish.Tastiness = updated.Tastiness;
                oneDish.Calories = updated.Calories;
                oneDish.Description = updated.Description;
                oneDish.UpdatedAt = DateTime.Now;
                
                dbcontext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return View("EditDish");
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
