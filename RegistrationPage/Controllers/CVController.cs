using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationPage.Data;
using RegistrationPage.Models;
using System.Linq;

namespace RegistrationPage.Controllers
{
    public class CVController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CVController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult ViewCV(int createAccountId)
        {
            // Retrieve CreateAccount data from the database
            var account = dbContext.CreateAccounts
                .Include(a => a.Addresses) // Include Address data
                .Include(a => a.EducationalQualifications) // Include Educational Qualification data
                .FirstOrDefault(a => a.Id == createAccountId);

            if (account == null)
            {
                return NotFound(); // If no record is found, return 404
            }

            // Map the data to a ViewModel
            var cvViewModel = new CVViewModel
            {
                Name = account.Name,
                Email = account.Email,
                MobileNumber = account.MobileNumber,
                Gender = account.Gender,
                Age = account.Age,
                Skill = account.Skill,
                Addresses = account.Addresses.Select(a => new AddressViewModel
                {
                    CountryName = dbContext.Countries.FirstOrDefault(c => c.Id == a.CountryId)?.Name,
                    DistrictName = dbContext.Districts.FirstOrDefault(d => d.Id == a.DistrictId)?.Name,
                    UpazilaName = dbContext.Upazilas.FirstOrDefault(u => u.Id == a.UpazilaId)?.Name,
                    PostOffice = a.PostOffice,
                    Village = a.Village
                }).ToList(),
                EducationalQualifications = account.EducationalQualifications.Select(eq => new EducationalQualificationViewModel
                {
                    EducationalStage = eq.EducationalStage,
                    NameOfEducationalInstitution = eq.NameOfEducationalInstitution,
                    MajorSubject = eq.MajorSubject,
                    Board = eq.Board,
                    YearOfPassing = eq.YearOfPassing
                }).ToList()
            };

            return View(cvViewModel); // Pass the ViewModel to the View
        }
    }
}
