namespace RegistrationPage.Models.Entities
{
    public class Address : BaseEntity
    {
        
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
        public int UpazilaId { get; set; }
        public virtual Upazila Upazila { get; set; }

       // public int Id { get; set; }
        public string PostOffice { get; set; }
        public string Village { get; set; }

        public int CreateAccountId { get; set; }
        public virtual CreateAccount CreateAccount { get; set; }
        

    }
}
