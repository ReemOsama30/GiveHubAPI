using charityPulse.core.Models;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class MoneyDonationRepository : Repository<MoneyDonation>, IMoneyDonationRepository
    {
        public MoneyDonationRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
