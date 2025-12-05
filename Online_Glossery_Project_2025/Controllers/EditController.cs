using Microsoft.AspNetCore.Mvc;
using Online_Glossery_Project_2025.Data;
using Online_Glossery_Project_2025.Models;

namespace Online_Glossery_Project_2025.Controllers
{
    public class EditController : Controller
    {
        private readonly DB db;
        public EditController(DB db)
        {
            this.db = db;

        }
        public IActionResult Profile(int id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }
        [HttpPost]
        public IActionResult Profile(MyUser model)
        {
            if (ModelState.IsValid)
            {
                db.users.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }
    }
}
