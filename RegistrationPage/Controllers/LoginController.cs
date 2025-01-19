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
            if(ModelState.IsValid)
            {
                var user = dbContext.CreateAccounts.FirstOrDefault(u => u.Email == model.Email);
                if(user != null && VerifyPassword(model.Password , user.Password))
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("UserName", user.Name);

                    return RedirectToAction("Dashboard", "Login");
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

        [HttpGet]
        public IActionResult Dashboard()
        {
            // Ensure the user is logged in
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            // Retrieve user data using the session UserId
            int userId = HttpContext.Session.GetInt32("UserId").Value;
            var user = dbContext.CreateAccounts.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return View(user); 
        }


        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword;
        }
    }
}
