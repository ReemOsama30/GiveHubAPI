using charityPulse.core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
      public  DbSet<Admin> Admins { get; set; }
      public  DbSet<Advertisment> Advertisments { get; set; }
      public  DbSet<ApplicationUser> ApplicationUsers { get; set; }
public DbSet<Badge> Badges { get; set; }
   public     DbSet<Charity> charities { get; set; }
   public     DbSet<Corporate> corporations { get; set; }
     public   DbSet<DonationReport> donationsReport { get; set; }
        public DbSet<Donation> donations { get; set; }
        public DbSet<Donor> donors { get; set; }
        public DbSet<InKindDonation> inKindDonations { get; set; }
        public DbSet<MoneyDonation> moneyDonations { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Review> reviews { get; set; }

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
                Id = "1",
                UserName = "user1@example.com",
                Email = "user1@example.com",
                NormalizedUserName = "USER1@EXAMPLE.COM",
                NormalizedEmail = "USER1@EXAMPLE.COM",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123"),
                PhoneNumber = "+1-555-1234",
                AccountType = "Donor",
                IsDeleted = false,
                // Add other properties and relationships you want to set
            },
            new ApplicationUser
            {
                Id = "2",
                UserName = "user2@example.com",
                Email = "user2@example.com",
                NormalizedUserName = "USER2@EXAMPLE.COM",
                NormalizedEmail = "USER2@EXAMPLE.COM",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Password123"),
                PhoneNumber = "+1-555-5678",
                AccountType = "Donor",
                IsDeleted = false,
                // Add other properties and relationships you want to set
            }, });

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = "1",
                   Name = "Admin",
                   NormalizedName = "ADMIN"
               }
               // Add more roles as needed
           );

            // Configure inheritance using TPH (Table per Hierarchy) strategy
            modelBuilder.Entity<Donation>()
                .HasDiscriminator<string>("DonationType")
                .HasValue<MoneyDonation>("Monetary")
                .HasValue<InKindDonation>("InKind");
        
        }



    }
}
