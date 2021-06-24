using Microsoft.AspNetCore.Mvc;
namespace ProjectName.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet("")]       //type of request and associated route string (exclude the leading /)
        public ViewResult Index()
        {
            return View();
        }
    }
}

