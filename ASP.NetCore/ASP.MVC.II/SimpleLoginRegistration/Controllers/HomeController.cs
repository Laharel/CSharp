using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleLoginRegistration.Models;
using Microsoft.AspNetCore.Identity;

namespace SimpleLoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            dbcontext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Registration(Registration user)
        {
            if (ModelState.IsValid)
            {
                if(dbcontext.Users.Any(u => u.email == user.email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<Registration> Hasher = new PasswordHasher<Registration>();
                    user.password = Hasher.HashPassword(user, user.password);
                    return RedirectToAction("Success");
                }
            }
            else
            {
                return View("Index");
            }
        }
        public IActionResult Login(Login Login)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbcontext.Users.FirstOrDefault(u => u.email == Login.email);
                
                if(userInDb == null)
                    {
                        // Add an error to ModelState and return to View!
                        ModelState.AddModelError("Email", "Invalid Email/Password");
                        return View("Index");
                    }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(Login, userInDb.password, Login.password);
                if(result == 0)
                {
                    return View("Index");
                }
                
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index");
            }
        }
        public ViewResult Success()
        {
            return View();
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
