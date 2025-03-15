using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RegistrationPage.Data;
using RegistrationPage.Models;
using RegistrationPage.Models.Entities;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Security.Principal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RegistrationPage.Controllers
{

    public class AccountController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public AccountController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(AddCountryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var country = new Country
                {
                    Name = viewModel.Name,
                   
                };
                dbContext.Countries.Add(country);
                dbContext.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddDistrict()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddDistrict(AddDistrictViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var district = new District
                {
                    Name = viewModel.Name,
                    CountryId = viewModel.CountryId

                };
                dbContext.Districts.Add(district);
                dbContext.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddUpazila()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddUpazila(AddUpazilaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var upazila = new Upazila
                {
                    Name = viewModel.Name,
                    DistrictId = viewModel.DistrictId

                };
                dbContext.Upazilas.Add(upazila);
                dbContext.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {

            var currentYear = DateTime.Now.Year;

            var yearDropdown = Enumerable.Range(1900, currentYear - 1900 + 1)
                .Reverse() // Display in descending order
                .Select(year => new SelectListItem
                {
                    Value = year.ToString(),
                    Text = year.ToString()
                }).ToList();


            //var model = new RegistrationViewModel
            //{

            //    Countries = dbContext.Countries
            //        .Select(c => new SelectListItem
            //        {
            //            Value = c.Id.ToString(),
            //            Text = c.Name
            //        }).ToList(),

            //    Districts = dbContext.Districts.Select(d => new SelectListItem
            //    {
            //        Value = d.Id.ToString(),
            //        Text = d.Name
            //    }).ToList(),

            //    Upazilas = dbContext.Upazilas.Select(u => new SelectListItem
            //    {
            //        Value = u.Id.ToString(),
            //        Text = u.Name
            //    }).ToList(),

            var model = new RegistrationViewModel
            {
                Countries = dbContext.Countries
                  .Select(c => new SelectListItem
                  {
                      Value = c.Id.ToString(),
                      Text = c.Name
                  }).ToList(),
                Districts = new List<SelectListItem>(), // Empty initially
                Upazilas = new List<SelectListItem>(), // Empty initially  


                EducationalQualifications = new List<EducationalQualificationViewModel>
                {
                    new EducationalQualificationViewModel()
                    {
                         YearDropdown = yearDropdown // Assign the dropdown list
                    }
                }
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the CreateAccount entity
                var createAccount = new CreateAccount
                {
                    Name = model.Name,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    Gender = model.Gender,
                    Age = model.Age,
                    Skill = model.Skill,
                    Password = model.Password
                    
                };
                dbContext.CreateAccounts.Add(createAccount);
                dbContext.SaveChanges(); // Save CreateAccount first to generate its ID

                //  Save Country manually (if it doesn't exist)
                Country country = dbContext.Countries.FirstOrDefault(c => c.Id == model.SelectedCountry);
                if (country == null && model.SelectedCountry.HasValue)
                {
                    country = new Country
                    {
                        Id = model.SelectedCountry.Value,
                        Name = model.Countries.FirstOrDefault(c => c.Value == model.SelectedCountry.Value.ToString())?.Text
                    };
                    dbContext.Countries.Add(country);
                    dbContext.SaveChanges();
                }

                //  Save District manually (if it doesn't exist)
                District district = dbContext.Districts.FirstOrDefault(d => d.Id == model.SelectedDistrict);
                if (district == null && model.SelectedDistrict.HasValue)
                {
                    district = new District
                    {
                        Id = model.SelectedDistrict.Value,
                        Name = model.Districts.FirstOrDefault(d => d.Value == model.SelectedDistrict.Value.ToString())?.Text,
                        CountryId = country.Id // Link to the saved Country
                    };
                    dbContext.Districts.Add(district);
                    dbContext.SaveChanges();
                }

                // Save Upazila manually (if it doesn't exist)
                Upazila upazila = dbContext.Upazilas.FirstOrDefault(u => u.Id == model.SelectedUpazila);
                if (upazila == null && model.SelectedUpazila.HasValue)
                {
                    upazila = new Upazila
                    {
                        Id = model.SelectedUpazila.Value,
                        Name = model.Upazilas.FirstOrDefault(u => u.Value == model.SelectedUpazila.Value.ToString())?.Text,
                        DistrictId = district.Id // Link to the saved District
                    };
                    dbContext.Upazilas.Add(upazila);
                    dbContext.SaveChanges();
                }

                // Save Address manually
                var address = new Address
                {
                    CountryId = country.Id,
                    DistrictId = district.Id,
                    UpazilaId = upazila.Id,
                    PostOffice = model.PostOffice,
                    Village = model.Village,
                    CreateAccountId = createAccount.Id
                };

                dbContext.Addresses.Add(address);
                dbContext.SaveChanges();

               
               //  Save Educational Qualifications
                var educationalQualifications = model.EducationalQualifications.Select(eq => new EducationalQualification
                {
                    EducationalStage = eq.EducationalStage,
                    NameOfEducationalInstitution = eq.NameOfEducationalInstitution,
                    MajorSubject = eq.MajorSubject,
                    Board = eq.Board,
                    YearOfPassing = eq.YearOfPassing,
                   
                    CreateAccountId = createAccount.Id
                }).ToList();


                dbContext.EducationalQualifications.AddRange(educationalQualifications);
                dbContext.SaveChanges();

                HttpContext.Session.SetInt32("CreateAccountId", createAccount.Id);
                HttpContext.Session.SetString("UserName", createAccount.Name);

                return RedirectToAction("MyJobDashboard", "CreateAccountDashboard");
            }

            return View(model);
        }

        [HttpGet]
        public JsonResult GetDistrictsByCountry(int countryId)
        {
            var districts = dbContext.Districts
                .Where(d => d.CountryId == countryId)
                .Select(d => new { d.Id, d.Name })
                .ToList();

            return Json(districts);
        }

        [HttpGet]
        public JsonResult GetUpazilasByDistrict(int districtId)
        {
            var upazilas = dbContext.Upazilas
                .Where(u => u.DistrictId == districtId)
                .Select(u => new { u.Id, u.Name })
                .ToList();

            return Json(upazilas);
        }
    }
}


