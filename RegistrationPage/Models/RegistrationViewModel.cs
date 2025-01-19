using Microsoft.AspNetCore.Mvc.Rendering;

namespace RegistrationPage.Models
{
    public class RegistrationViewModel
    {
        // CreateAccount fields
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Skill { get; set; }

        public string Password { get; set; }

        // Address fields
        
        public string PostOffice { get; set; }
        public string Village { get; set; }

        public List<SelectListItem>? Countries { get; set; }
        public List<SelectListItem>? Districts { get; set; }
        public List<SelectListItem>? Upazilas { get; set; }
        

        public int? SelectedCountry { get; set; }
        public int? SelectedDistrict { get; set; }
        public int? SelectedUpazila { get; set; }
        
       
        // Educational Qualifications fields

        public List<EducationalQualificationViewModel> EducationalQualifications { get; set; }
    }
   
}
