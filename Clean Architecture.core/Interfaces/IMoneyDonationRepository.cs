using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;

namespace Clean_Architecture.core.Interfaces
{
    public interface IMoneyDonationRepository : IRepository<MoneyDonation>
    {
        public int? GetTopDonorOfCurrentMonth();

    }
}
