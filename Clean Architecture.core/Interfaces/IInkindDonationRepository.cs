using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;


namespace Clean_Architecture.core.Interfaces
{
    public interface IInkindDonationRepository : IRepository<InKindDonation>
    {
        public List<Project> GetInkindDonationByCharityId(int id);
    }
}
