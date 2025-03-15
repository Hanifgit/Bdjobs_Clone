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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<EmployerAddress> EmployerAddresses { get; set;}
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Application> Applications { get; set; }
       


        }

   
}
