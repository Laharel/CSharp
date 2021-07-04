using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginAndRegistration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace LoginAndRegistration.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if(userId != null)
            {
                ViewBag.LoggedIn = true;
            } else if(userId == null)
            {
                ViewBag.LoggedIn = false;
            }
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!"); 
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("userId", user.UserId);
                return RedirectToAction("LoginForm");
            }
            return View("Index");
        }
        [HttpGet("login/form")]
        public IActionResult LoginForm()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if(userId != null){
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost("login")]
        public IActionResult LoginUser(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("LoginForm");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    // if didn't pass
                    ModelState.AddModelError("Password", "Invalid Password");
                    return View("LoginForm");
                }
                // if logged in successfully
                // store userId in session
                HttpContext.Session.SetInt32("userId", userInDb.UserId);
                return RedirectToAction("Success");
            }
            return View("LoginForm");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if(userId != null){
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}

