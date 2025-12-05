using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Online_Glossery_Project_2025.Data;
using Online_Glossery_Project_2025.Models;

namespace Online_Glossery_Project_2025.Controllers
{
    public class AdminController : Controller
    {
        private readonly DB context;
        public MyUser? user;
        public AdminController(DB context)
        {

            this.context = context;

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LoadData().Wait();

            ViewBag.userdata = user;
            base.OnActionExecuting(context);
        }

        public async Task<string> LoadData()
        {
            string value = Request.Cookies["Email"];

            user = await context.users.FirstOrDefaultAsync(u => u.Email == value);

            return user.Email;
        }
        public IActionResult GetData()
        {
            var users = context.users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MyUser model)
        {
            if (ModelState.IsValid)
            {
                context.users.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public IActionResult Edit(int id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var user = context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(MyUser model)
        {
            if (ModelState.IsValid)
            {
                context.users.Update(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var user = context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var user = context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]

        public IActionResult DeleteConfirmed(int id)
        {
            var user = context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            context.users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
