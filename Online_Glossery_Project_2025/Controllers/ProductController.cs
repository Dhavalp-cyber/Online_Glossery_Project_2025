using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Glossery_Project_2025.Data;
using Online_Glossery_Project_2025.Models;

namespace Online_Glossery_Project_2025.Controllers
{
    public class ProductController : Controller
    {
        private readonly DB db;
        public ProductController(DB db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            var products = db.products.ToList();

            var categories = db.cetegories.ToList();
            var subcategories = db.subCetegories.ToList();

            ViewBag.Categories = categories;
            ViewBag.SubCategories = subcategories;

            return View(products);
        }

        public IActionResult DisplayProductImage(int id)
        {
            var product = db.products.FirstOrDefault(x => x.Id == id);

            if (product == null || product.Image == null)
                return NotFound();

            return File(product.Image, "image/jpeg");
        }

        public IActionResult AddProduct(int? Id)
        {
            ViewBag.Categories = db.cetegories.ToList();

            if (Id != null)
            {
                ViewBag.SubCategories = db.subCetegories
                    .Where(x => x.CetegoryID == Id)
                    .ToList();
            }
            else
            {
                ViewBag.SubCategories = new List<SubCetegory>();
            }

            Product model = new Product();
            model.CetegoryID = Id ?? 0;

            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(Product model, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imageFile.CopyTo(ms);
                    model.Image = ms.ToArray();
                }
            }

            db.products.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        


        public IActionResult Edit(int id)
        {
            var product = db.products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = db.cetegories.ToList();
            ViewBag.SubCategories = db.subCetegories
                .Where(x => x.CetegoryID == product.CetegoryID)
                .ToList();
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product model, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imageFile.CopyTo(ms);
                    model.Image = ms.ToArray();
                }
            }
            db.products.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var product = db.products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                db.products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        


    }
}
