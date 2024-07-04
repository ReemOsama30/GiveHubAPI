using charityPulse.core.Models;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class DonorRepository : Repository<Donor>, IDonorRepository
    {
        public DonorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Donor>> GetAllDonorWithBadgeAsync()
        {
            return await context.Set<Donor>()
                  .Where(r => !r.IsDeleted)
                  .Include(d => d.Badges)
                  .ToListAsync();


        }

        public async Task<List<Project>> GetAllDistinctDonatedProjectsAsync(int id)
        {
            var projects = context.donations.Where(d => d.DonorId == id).Select(d => d.Project).Distinct().ToList();
            return projects;
        }

        public int GetAllDistinctDonationCategories(int id)
        {
            var CatagoryCount = context.donations.Where(d => d.DonorId == id).Select(d => d.Project.CategoryId).Distinct().Count();
            return CatagoryCount;
        }

        public bool HasBadge(int id, string badgeName)
        {
            int badgeId = context.Badges.Where(b => b.Name == $"{badgeName}").Select(b => b.Id).FirstOrDefault();

            var donor = context.donors.Where(d => d.Id == id).Include(d => d.Badges).FirstOrDefault();
            bool hasBadge = donor.Badges.Any(b => b.BadgeId == badgeId);

            return hasBadge;
        }
        public int GetDonationsCount(int id)
        {
            int count = context.donations.Where(d => d.DonorId == id).Count();
            return count;
        }




        //here must return DTO but in interface i cant return DTo........

        //public async Task<List<Donor>> GetAllDonorWithBadgeAsync()
        //{
        //    return await context.Set<Donor>()
        //        .Include(d => d.Badges)
        //        .Select(d => new Donor
        //        {

        //            Name = d.Name,
        //            ProfileImg  = d.ProfileImg,
        //            DateJoined  = d.DateJoined,
        //            Badges = d.Badges.Select(b => b.Name).ToList()
        //        })
        //        .ToListAsync();
        //}



    }
}
