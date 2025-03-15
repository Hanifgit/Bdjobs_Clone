using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace RegistrationPage.Models.Entities
{
    public class CreateAccount : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Skill { get; set; }
       
        public int UserId { get; set; }
        public string Password { get; set; }
        public int? CategoryId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Application> Applications { get; set; }

    }
}
