using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Management.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
