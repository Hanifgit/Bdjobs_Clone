using Microsoft.EntityFrameworkCore;
using RegistrationPage.Models.Entities;

namespace RegistrationPage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<CreateAccount> CreateAccounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EducationalQualification> EducationalQualifications { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Upazila> Upazilas { get; set; }
       


        }

   
}
