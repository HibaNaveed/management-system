using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;


namespace Restaurant_Management.Controllers
{
    public class adminController : Controller
    {
        private readonly RestaurantDbContext _context;

        public adminController(RestaurantDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orderDetails = _context.OrderDetails.ToList();
            return View(orderDetails);
            //return View();
        }
        public async Task<IActionResult> Orderdetail()
        {
            return View(await _context.NewItems.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderDetails orderdetails)
        {
            if (ModelState.IsValid)
            {
                _context.OrderDetails.Add(orderdetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderdetails);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.OrderDetails.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,CustomerName,Items,Price,Status")] OrderDetails order)
        {
            if (id != order.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.OrderDetails.Any(o => o.id == order.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.OrderDetails.FirstOrDefaultAsync(o => o.id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.OrderDetails.FindAsync(id);
            if (order != null)
            {
                _context.OrderDetails.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





        public IActionResult AddNewFood()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewFood(NewItems newitems)
        {
            if (ModelState.IsValid)
            {
                _context.NewItems.Add(newitems);
                _context.SaveChanges();
                return RedirectToAction("Menu");
            }
            return View(newitems);
        }
        public IActionResult Menu()
        {
            var items = _context.NewItems.ToList();
            return View(items);
        }
    }
}
