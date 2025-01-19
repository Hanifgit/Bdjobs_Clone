using Microsoft.AspNetCore.Mvc.Rendering;

namespace RegistrationPage.Models
{
    public class EducationalQualificationViewModel
    {
        public string EducationalStage { get; set; }
        public string NameOfEducationalInstitution { get; set; }
        public string MajorSubject { get; set; }
        public string Board { get; set; }
        public string YearOfPassing { get; set; }

        public List<SelectListItem>? YearDropdown { get; set; }


    }
}
