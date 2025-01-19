namespace RegistrationPage.Models.Entities
{
    public class EducationalQualification : BaseEntity
    {
        public string EducationalStage { get; set; }
        public string NameOfEducationalInstitution { get; set; }
        public string MajorSubject { get; set; }
        public string Board { get; set; }
        public string YearOfPassing { get; set; }
        public int CreateAccountId { get; set; }
        public virtual CreateAccount CreateAccount { get; set; }

    }
}
