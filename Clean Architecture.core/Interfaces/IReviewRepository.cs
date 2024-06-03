using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;

namespace Clean_Architecture.core.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        List<Review> GetByDonerId(string donerId);
        List<Review> GetByCharityId(int charityId);
        List<Review> GetAllReviewsWithDonorInfo();
        Review GetOneWithDonorInfo(int id);

    }
}
