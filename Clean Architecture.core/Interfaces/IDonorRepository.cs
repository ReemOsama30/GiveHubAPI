using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;

namespace Clean_Architecture.core.Interfaces
{
    public interface IDonorRepository : IRepository<Donor>
    {
        //b Task<List<Donor>> GetAllDonorWithBadgeAsync();
        public Task<List<Donor>> GetAllDonorWithBadgeAsync();
        public Task<List<Project>> GetAllDistinctDonatedProjectsAsync(string id);
        public int GetAllDistinctDonationCategories(string id);
        public bool HasBadge(string id,string badgeName);

        public int GetDonationsCount(string id);


    }
}
