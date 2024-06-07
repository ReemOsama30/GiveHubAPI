using charityPulse.core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        DbSet<Admin> Admins { get; set; }
        DbSet<Advertisment> Advertisments { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Badge> Badges { get; set; }
        DbSet<Charity> charities { get; set; }
        DbSet<Corporate> corporations { get; set; }
        DbSet<DonationReport> donationsReport { get; set; }
        DbSet<Donation> donations { get; set; }
        DbSet<Donor> donors { get; set; }
        DbSet<InKindDonation> inKindDonations { get; set; }
        DbSet<MoneyDonation> moneyDonations { get; set; }
        DbSet<Project> projects { get; set; }
        DbSet<Review> reviews { get; set; }

        // removed??
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasData(
            new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    UserName = "user1@example.com",
                    Email = "user1@example.com",
                    PasswordHash = "Doe",
                    PhoneNumber = "+1-555-1234",
                    
                    // Add other properties you want to set
                },
                new ApplicationUser
                {
                    UserName = "user2@example.com",
                    Email = "user2@example.com",
                    PasswordHash = "Doe",
                    PhoneNumber = "+1-555-5678",
                    
                    // Add other properties you want to set
                },
                new ApplicationUser
                {
                    UserName = "user3@example.com",
                    Email = "user3@example.com",
                    PasswordHash = "Smith",
                    PhoneNumber = "+1-555-9012",

                },
                new ApplicationUser
                {
                    UserName = "user4@example.com",
                    Email = "user4@example.com",

                    PasswordHash = "Johnson",
                    PhoneNumber = "+1-555-3456",
                      
                    // Add other properties you want to set
                },
                new ApplicationUser
                {
                    UserName = "user5@example.com",
                    Email = "user5@example.com",
                    PasswordHash = "William",

                    PhoneNumber = "+1-555-7890",
                     
                    // Add other properties you want to set
                }
            });


            // Configure inheritance using TPH (Table per Hierarchy) strategy
            modelBuilder.Entity<Donation>()
                .HasDiscriminator<string>("DonationType")
                .HasValue<MoneyDonation>("Monetary")
                .HasValue<InKindDonation>("InKind");
        }


    }
}
