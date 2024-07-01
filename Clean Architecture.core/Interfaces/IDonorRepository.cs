using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;

namespace Clean_Architecture.core.Interfaces
{
    public interface IDonorRepository : IRepository<Donor>
    {
        //b Task<List<Donor>> GetAllDonorWithBadgeAsync();
        public Task<List<Donor>> GetAllDonorWithBadgeAsync();
        public Task<List<Project>> GetAllDistinctDonatedProjectsAsync(int id);
        public int GetAllDistinctDonationCategories(int id);
        public bool HasBadge(int id,string badgeName);

        public int GetDonationsCount(int id);


    }
}
