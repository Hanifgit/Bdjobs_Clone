using System.Drawing;

namespace RegistrationPage.Models
{
    public class CVViewModel
    {
        // CreateAccount fields
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Skill { get; set; }
       
        public string Password { get; set; }
       

        // Address Field
        public List<CVAddressViewModel> Addresses { get; set; }
       
       

        // EducationalQualification 
        public List<EducationalQualificationViewModel> EducationalQualifications { get; set; }

    }
}
