using Microsoft.AspNetCore.Mvc;
using Online_Glossery_Project_2025.Data;
using Online_Glossery_Project_2025.ViewModel;

namespace Online_Glossery_Project_2025.Controllers
{
    public class LoginLogoutController : Controller
    {
        private readonly DB dB;
        public LoginLogoutController(DB dB)
        {
            this.dB = dB;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == dB.users.FirstOrDefault(u => u.Email == model.Email)?.Email)
                {
                    ModelState.AddModelError("Email", "Email already exists.");
                    return View(model);
                }
                else
                {

                }
                var data = new Models.MyUser
                {
                    Username = model.Username,
                    Email = model.Email,

                    Password = model.Password,
                    Phone = model.Phone,
                    IsActive = model.IsActive,
                    Role = "User",
                    Islogin = true


                };
                dB.users.Add(data);
                dB.SaveChanges();

                CookieOptions opt = new CookieOptions();
                opt.Expires = DateTime.Now.AddHours(1);

                Response.Cookies.Append("IsLogin", "true", opt);
                Response.Cookies.Append("Email", model.Email, opt);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                var user = dB.users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {

                    CookieOptions opt = new CookieOptions();
                    opt.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Append("IsLogin", "true", opt);
                    Response.Cookies.Append("Email", model.Email, opt);

                    return RedirectToAction("AllProductList", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Email or password");
                return View(model);
            }
            return View(model);


        }


        public IActionResult Logout()
        {
            CookieOptions opt = new CookieOptions();
            opt.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append("IsLogin", "true", opt);
            Response.Cookies.Append("Email", "", opt);
            return RedirectToAction("Login", "LoginLogout");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }



    }
}
