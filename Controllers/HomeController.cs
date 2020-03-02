using Microsoft.AspNetCore.Mvc;


namespace CollegeManagement.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
