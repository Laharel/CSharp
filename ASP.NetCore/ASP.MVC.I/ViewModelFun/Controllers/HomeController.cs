using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
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
            string message="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam condimentum facilisis accumsan. In hac habitasse platea dictumst. Nunc ultrices porttitor arcu eget scelerisque. Pellentesque a dolor est. Pellentesque in lectus eu libero aliquet rutrum. Proin pulvinar lectus vitae felis mollis, id imperdiet leo ultrices. Quisque tempor imperdiet odio, venenatis tristique augue euismod ut. Integer vestibulum quis ex in varius. Vestibulum vehicula libero id lectus semper, eget laoreet ante aliquet. In malesuada nunc arcu, a elementum quam condimentum et. Morbi vestibulum leo ligula, eget semper enim gravida vel. Vestibulum sit amet nulla eget eros hendrerit lobortis.";
            return View("Index",message);
        }


        public IActionResult Numbers()
        {
            int[] numbers = new int[]
            {
                1,
                2,
                3,
                10,
                43,
                5
            };
            return View(numbers);
        }
        public IActionResult Users()
        {
            List<User> users=new List<User>()
            {
                new User{FirstName="Moose",LastName="Philips"},
                new User{FirstName="Sarah"},
                new User{FirstName="Jerry"},
                new User{FirstName="Rene",LastName="Ricky"},
                new User{FirstName="Barbarah"}
                
            };
            return View(users);
        }
        [HttpGet("user")]
        public IActionResult OneUser()
        {
            User OneUser=new User()
            {
                FirstName="Moose",
                LastName="Philips"
            };
            return View(OneUser);
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
