using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Management.Controllers
{
    public class AddToCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
