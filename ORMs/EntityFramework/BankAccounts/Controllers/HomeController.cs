using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,MyContext context)
        {
            dbcontext = context;
            _logger = logger;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if(userId != null)
            {
                ViewBag.LoggedIn = true;
                ViewBag.User=dbcontext.Users.FirstOrDefault(l => l.UserId == userId);
            } else if(userId == null)
            {
                ViewBag.LoggedIn = false;
            }
            return View();
        }
        [HttpPost("")]
        public IActionResult Create(User user)
        {
            if(dbcontext.Users.Any(l => l.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!"); 
                return View("Index");
            }
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.Password = Hasher.HashPassword(user, user.Password);
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
            HttpContext.Session.SetInt32("userId", user.UserId);
            return RedirectToAction("LoginForm");            
        }
        [HttpGet("Login")]
        public IActionResult LoginForm()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if(userId != null){
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost("Login")]
        public IActionResult Login(Login submitted)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbcontext.Users.FirstOrDefault(l => l.Email == submitted.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("LoginForm");
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(submitted, userInDb.Password, submitted.Password);
                if(result == 0)
                {
                    // if didn't pass
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("LoginForm");
                }
                // if logged in successfully
                // store userId in session
                HttpContext.Session.SetInt32("userId", userInDb.UserId);
                return RedirectToAction("Index");
            }
            return View("LoginForm");
        }
        [HttpGet("Account/{id}")]
        public IActionResult Account(int id)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            string message = HttpContext.Session.GetString("message");
            if(userId != null){
                ViewBag.LoggedIn = true;
                Transaction trans=dbcontext.Transactions.FirstOrDefault(l=> l.UserId==id);
                ViewBag.User=dbcontext.Users
                    .Include(u => u.Transactions)
                        .OrderByDescending(l => l.CreatedAt)
                            .FirstOrDefault(l => l.UserId==id);
                if (message ==null)
                {
                    ViewBag.message="";
                }
                else
                {
                    ViewBag.message=message;
                }
                return View(trans);
            }
            else{
                ViewBag.LoggedIn = false;
                return RedirectToAction("LoginForm");
            }
        }
        [HttpPost("Account/{id}")]
        public IActionResult Add(int id,Transaction newtrans)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if(userId != null){
                Transaction trans=dbcontext.Transactions.FirstOrDefault(l => l.UserId==id);
                User thisUser=dbcontext.Users
                        .Include(u => u.Transactions)
                            .OrderByDescending(l => l.CreatedAt)
                                .FirstOrDefault(l => l.UserId==id);
                if (thisUser.Transactions.Count == 0 )
                {
                    newtrans.UserId=id;
                    dbcontext.Transactions.Add(newtrans);
                    dbcontext.SaveChanges();
                    return RedirectToAction("Account");
                }
                else
                {   
                    decimal sum=0;
                    foreach (Transaction T in thisUser.Transactions)
                    {
                        sum+=T.Amount;
                    }
                    if(sum+newtrans.Amount>=0)
                    {
                        newtrans.UserId=id;
                        dbcontext.Transactions.Add(newtrans);
                        dbcontext.SaveChanges();
                        return RedirectToAction("Account");
                    }
                    else
                    {
                        string message="Insufficient balance";
                        HttpContext.Session.SetString("message", message);
                        return RedirectToAction("Account"); 
                    }
                }
            }
            else{
                return RedirectToAction("LoginForm");
            }
        }
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            HttpContext.Session.Clear();
            return RedirectToAction("LoginForm");
        }
        [HttpGet]
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
