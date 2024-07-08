using charityPulse.core.Models;
using Clean_Architecture.core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<AwardedBadge> AwardedBadges { get; set; }
        public DbSet<Charity> charities { get; set; }
        public DbSet<Corporate> corporations { get; set; }
        public DbSet<DonationReport> donationsReport { get; set; }
        public DbSet<Donation> donations { get; set; }
        public DbSet<Donor> donors { get; set; }
        public DbSet<InKindDonation> inKindDonations { get; set; }
        public DbSet<MoneyDonation> moneyDonations { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Category> categories { set; get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            modelBuilder.Entity<Category>().HasData(
                new Category { id = 1, Name = "Health" },
                new Category { id = 2, Name = "Education" },
                new Category { id = 3, Name = "Animal Welfare" },
                new Category { id = 4, Name = "Hunger and Thirst" },
                new Category { id = 5, Name = "Environment" }

            );

            // Configure inheritance using TPH (Table per Hierarchy) strategy
            modelBuilder.Entity<Donation>()
                .HasDiscriminator<string>("DonationType")
                .HasValue<MoneyDonation>("Monetary")
                .HasValue<InKindDonation>("InKind");
        }
    }
}
