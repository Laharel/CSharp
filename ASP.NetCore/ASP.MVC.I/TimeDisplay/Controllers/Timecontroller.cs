using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
    public class Timecontroller:Controller
    {
        [HttpGet("")]
        public ViewResult Time()
        {
            return View();
        }
    }
}