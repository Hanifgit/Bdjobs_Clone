using Microsoft.AspNetCore.Mvc;
using RegistrationPage.Data;
using RegistrationPage.Models;

namespace RegistrationPage.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public LoginController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employerAccount = dbContext.CreateAccounts.FirstOrDefault(u => u.Email == model.Email);
                if (employerAccount != null && VerifyPassword(model.Password, employerAccount.Password))
                {
                    HttpContext.Session.SetInt32("CreateAccountId", employerAccount.Id);
                    HttpContext.Session.SetString("UserName", employerAccount.Name);

                    return RedirectToAction("MyJobDashboard", "CreateAccountDashboard");
                }
                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }


        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword;
        }
    }
}
