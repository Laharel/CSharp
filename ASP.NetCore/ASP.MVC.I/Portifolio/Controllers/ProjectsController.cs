using Microsoft.AspNetCore.Mvc;

namespace Portifolio.Controllers
{
    public class ProjectsController:Controller
    {
        [HttpGet("projects")]
        public ViewResult Projects(){
            return View();
        }
    }
}