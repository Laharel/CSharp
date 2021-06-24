using Microsoft.AspNetCore.Mvc;

namespace Portifolio.Controllers
{
    public class HomeController:Controller
    {
        [HttpGet("")]
        public ViewResult Home(){
            return View();
        }
    }
}