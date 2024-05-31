using charityPulse.core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Infrastructure.DbContext
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

      
    }
}
