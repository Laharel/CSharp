using Microsoft.AspNetCore.Mvc;

namespace Portifolio.Controllers
{
    public class ContactController:Controller
    {
        [HttpGet("contact")]
        public ViewResult Contact(){
            return View();
        }
    }
}