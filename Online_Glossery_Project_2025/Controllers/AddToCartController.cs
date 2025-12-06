using Microsoft.AspNetCore.Mvc;
using Online_Glossery_Project_2025.Data;
using Online_Glossery_Project_2025.Models;

namespace Online_Glossery_Project_2025.Controllers
{
    public class AddToCartController : Controller
    {
        private readonly DB db;
        public AddToCartController(DB db)
        {
            this.db = db;
        }

        public IActionResult Add(int id)
        {
            string cart = Request.Cookies["cart"];

            if (string.IsNullOrEmpty(cart))
            {
                cart = id.ToString();
            }
            else
            {
                cart = cart + "," + id;
            }


            Response.Cookies.Append("cart", cart);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult ViewInCart()
        {
            string cart = Request.Cookies["cart"];

            if (string.IsNullOrEmpty(cart))
            {
                return View(new List<Product>()); // Empty cart
            }

            // Convert string "2,5,8" → int list
            var ids = cart.Split(',').Select(int.Parse).ToList();

            var products = db.products
                             .Where(p => ids.Contains(p.Id))
                             .ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            string cart = Request.Cookies["cart"];

            var idList = cart.Split(',').Select(int.Parse).ToList();

            idList.Remove(id); // Remove item

            string updated = string.Join(",", idList);

            Response.Cookies.Append("cart", updated);

            return RedirectToAction("ViewInCart");
        }

        // CLEAR CART
        public IActionResult Clear()
        {
            Response.Cookies.Delete("cart");
            return RedirectToAction("ViewInCart");
        }

        public IActionResult DisplayProductImage(int id)
        {
            var product = db.products.FirstOrDefault(x => x.Id == id);

            if (product == null || product.Image == null)
                return NotFound();

            return File(product.Image, "image/jpeg");
        }
    }
}
