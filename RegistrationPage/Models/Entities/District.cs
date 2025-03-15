namespace RegistrationPage.Models.Entities
{
    public class District : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Upazila> Upazilas { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<EmployerAddress> EmployerAddresses { get; set; }
    }
}
