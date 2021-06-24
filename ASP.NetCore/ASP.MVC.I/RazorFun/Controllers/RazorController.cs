using Microsoft.AspNetCore.Mvc;

namespace RazorFun.Controllers
{
    public class RazorController:Controller
    {
        [HttpGet("")]
        public ViewResult Razor()
        {
            return View();
        } 
    }
}