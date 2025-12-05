using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Glossery_Project_2025.Data;
using Online_Glossery_Project_2025.Models;
using System.Diagnostics;

namespace Online_Glossery_Project_2025.Controllers
{
    public class HomeController : Controller
    {
        private readonly DB db;

        public HomeController(DB db)
        {

            this.db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AllProductList()
        {
            ViewBag.Categories = db.cetegories.ToList();
            ViewBag.SubCategories = db.subCetegories.ToList();

            var products = db.products.ToList();
            return View(products);
        }


        public IActionResult Profile()
        {
            var email = Request.Cookies["Email"];
            var user = db.users.FirstOrDefault(u => u.Email == email);
            var userId = user.UserId;
            if (user == null)
            {
                return NotFound();
            }


            return RedirectToAction("Profile", "Edit", new { id = user.UserId });

        }

        public IActionResult DisplayProductImage(int id)
        {
            var product = db.products.FirstOrDefault(x => x.Id == id);

            if (product == null || product.Image == null)
                return NotFound();

            return File(product.Image, "image/jpeg");
        }




        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
