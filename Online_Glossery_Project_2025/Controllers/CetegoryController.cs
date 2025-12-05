using Microsoft.AspNetCore.Mvc;
using Online_Glossery_Project_2025.Data;
using Online_Glossery_Project_2025.Models;

namespace Online_Glossery_Project_2025.Controllers
{
    public class CetegoryController : Controller
    {
        private readonly DB db;
        public CetegoryController(DB db)
        {
            this.db = db;
        }

        public IActionResult GetAllCetegory()
        {
            var categories = db.cetegories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cetegory model)
        {
            if (ModelState.IsValid)
            {
                db.cetegories.Add(model);
                db.SaveChanges();
                return RedirectToAction("GetAllCetegory");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var category = db.cetegories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Cetegory model)
        {
            if (ModelState.IsValid)
            {
                db.cetegories.Update(model);
                db.SaveChanges();
                return RedirectToAction("GetAllCetegory");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var category = db.cetegories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            
            return RedirectToAction("GetAllCetegory");
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = db.cetegories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            db.cetegories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("GetAllCetegory");
        }
    }
}
