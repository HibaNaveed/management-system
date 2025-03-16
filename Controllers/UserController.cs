using Microsoft.AspNetCore.Mvc;
using Restaurant_Management.Models;

namespace Restaurant_Management.Controllers
{
    public class UserController : Controller
    {
        private readonly RestaurantDbContext _context;

        public UserController(RestaurantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //return View();
            return View(new booking());
        }
        [HttpPost]
        public IActionResult BookaTable(booking model)
        {
            if (ModelState.IsValid)
            {
                _context.Booking.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View("Index", model);
        }
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
