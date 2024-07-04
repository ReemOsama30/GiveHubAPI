using charityPulse.core.Models;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class MoneyDonationRepository : Repository<MoneyDonation>, IMoneyDonationRepository
    {
        private readonly ApplicationDbContext _context;
        public MoneyDonationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public int? GetTopDonorOfCurrentMonth()
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1); 
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);


            var topDonor = _context.moneyDonations
                .Where(d => d.DonationDate >= startDate && d.DonationDate < endDate)
                .GroupBy(d => d.DonorId)
                .Select(group => new
                {
                    DonorId = group.Key,
                    TotalAmount = group.Sum(d => d.Amount)
                })
                .OrderByDescending(result => result.TotalAmount)
                .FirstOrDefault();

            if (topDonor == null)
            {
                return null;
            }

            return topDonor.DonorId;
               
        }

    }
}
