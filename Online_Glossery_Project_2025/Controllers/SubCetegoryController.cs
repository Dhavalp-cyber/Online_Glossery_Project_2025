using Microsoft.AspNetCore.Mvc;
using Online_Glossery_Project_2025.Data;
using Online_Glossery_Project_2025.Models;

namespace Online_Glossery_Project_2025.Controllers
{
    public class SubCetegoryController : Controller
    {
        private readonly DB db;
        public SubCetegoryController(DB db)
        {
            this.db = db;
        }

        public IActionResult GetAllSubCetegory(int? id)
        {
            var subcategories = db.subCetegories.Where(s => s.CetegoryID == id).ToList();
            return View(subcategories);
        }

        public IActionResult CreateNewCetegory(int id)
        {
            var model = new SubCetegory
            {
                CetegoryID = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateNewCetegory(SubCetegory model)
        {
            if (ModelState.IsValid)
            {
                db.subCetegories.Add(model);
                db.SaveChanges();
                return RedirectToAction("GetAllSubCetegory", new { id = model.CetegoryID });
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var subcategory = db.subCetegories.Find(id);
            if (subcategory == null)
            {
                return NotFound();
            }
            return View(subcategory);
        }
        [HttpPost]
        public IActionResult Edit(SubCetegory model)
        {
            if (ModelState.IsValid)
            {
                db.subCetegories.Update(model);
                db.SaveChanges();
                return RedirectToAction("GetAllSubCetegory", new { id = model.CetegoryID });
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var subcategory = db.subCetegories.Find(id);
            if (subcategory == null)
            {
                return NotFound();
            }
            return View(subcategory);
        }

        [HttpPost]

        public IActionResult DeleteSubCategory(int SubCetegoryID)
        {
            var sub = db.subCetegories.Find(SubCetegoryID);

            bool hasProducts = db.products
                                 .Any(p => p.SubCetegoryID == SubCetegoryID);

            if (hasProducts)
            {
                TempData["Error"] = "Cannot delete! First You delet All Product Releted tu this SubCetegory";
                return RedirectToAction("GetAllSubCetegory" , new { id = sub.CetegoryID });
            }

            db.subCetegories.Remove(sub);
            db.SaveChanges();

            return RedirectToAction("GetAllSubCetegory" , new { id = sub.CetegoryID });
        }

    }
}
