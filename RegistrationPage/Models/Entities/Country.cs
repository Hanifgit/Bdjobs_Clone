namespace RegistrationPage.Models.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<District> Districts { get; set; } 
    }
}
