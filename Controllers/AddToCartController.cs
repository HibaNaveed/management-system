using Microsoft.AspNetCore.Mvc;
using Restaurant_Management.Models;

namespace Restaurant_Management.Controllers
{
    public class AddToCartController : Controller
    {
        private readonly RestaurantDbContext _context;

        public AddToCartController(RestaurantDbContext context)
        {
            _context = context;
        }

        public IActionResult Cart()
        {
            ViewBag.Foods = _context.NewItems.ToList();
            var cart = _context.AddtoCart.ToList();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int Id, int Quantity)
        {
            var item = _context.NewItems.FirstOrDefault(i => i.Id == Id);
            if (item == null)
            {
                return RedirectToAction("Menu", "Orderdetail");

            }

            var CartItem = _context.AddtoCart.FirstOrDefault(c => c.Item == OrderDetails.Items);

            if (CartItem != null)
            {

                CartItem.quantity += Quantity;
            }
            else
            {
                var cartItem = new AddtoCart
                {
                    Item = NewItems.foodname,
                    Quantity = Quantity
                };
                _context.AddtoCart.Add(cartItem);
            }

            _context.SaveChanges();

            return RedirectToAction("ViewCart");
        }

        public IActionResult Edit(int id)
        {
            var cartItem = _context.AddtoCart.FirstOrDefault(c => c.Id == id);
            if (cartItem == null)
            {

            }
            return View(cartItem);
        }

        [HttpPost]
        public IActionResult Edit(AddtoCart cart)
        {
            if (ModelState.IsValid)
            {
                _context.AddtoCart.Update(cart);
                _context.SaveChanges();
                return RedirectToAction("ViewCart");
            }
            return View(cart);
        }

        public IActionResult Delete(int id)
        {
            var cartItem = _context.AddtoCart.FirstOrDefault(c => c.Id == id);
            if (cartItem == null)
            {
                return NotFound();
            }
            _context.AddtoCart.Remove(cartItem);
            _context.SaveChanges();
            return RedirectToAction("ViewCart");
        }

        public IActionResult Checkout()
        {
            var cartItems = _context.AddtoCart.ToList();
            return View(cartItems);
        }
        [HttpPost]
        public IActionResult ConfirmOrder(string paymentMethod)
        {
            if (paymentMethod == "COD")
            {
                ViewBag.OrderSuccess = "Here's a one-line order confirmation message with Cash on Delivery:\r\n\r\n\"Thank you for your order! Your payment will be collected via Cash on Delivery upon delivery.\"";
            }

            return View("OrderConfirmation");
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }

    }
}
