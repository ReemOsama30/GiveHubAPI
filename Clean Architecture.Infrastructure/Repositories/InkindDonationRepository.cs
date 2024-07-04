using charityPulse.core.Models;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class InkindDonationRepository : Repository<InKindDonation>, IInkindDonationRepository
    {
        public InkindDonationRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public List<Project> GetInkindDonationByCharityId(int id)
        {
            var projects = context.donations.Where(c => c.CharityId == id).Select(d => d.Project).Distinct().ToList();
            return projects;
        }


    }
}
