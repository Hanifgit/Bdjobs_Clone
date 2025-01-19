namespace RegistrationPage.Models.Entities
{
    public class Upazila : BaseEntity
    {
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
