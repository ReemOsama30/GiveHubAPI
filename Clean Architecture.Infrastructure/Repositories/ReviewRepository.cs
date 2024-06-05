using charityPulse.core.Models;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {

        }

        public List<Review> GetByCharityId(int charityId)
        {
            return context.Set<Review>()
                          .Where(r => r.CharityId == charityId && !r.IsDeleted)
                          .Include(r => r.Donor)
                          .ToList();
        }

        public List<Review> GetByDonerId(string donerId)
        {
            return context.Set<Review>()
                          .Where(r => r.DonorID.ToString() == donerId && !r.IsDeleted)
                          .ToList();
        }


        public List<Review> GetAllReviewsWithDonorInfo()
        {
            return context.Set<Review>()
                          .Where(r => !r.IsDeleted)
                          .Include(r => r.Donor)
                          .ToList();
        }


        public Review GetOneWithDonorInfo(int id)
        {
            return context.Set<Review>()
                          .Where(r => !r.IsDeleted)
                          .Include(r => r.Donor)
                          .FirstOrDefault(r => r.Id == id);

        }


    }
}
