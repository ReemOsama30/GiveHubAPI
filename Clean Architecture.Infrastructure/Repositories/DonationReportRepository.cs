using charityPulse.core.Models;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class DonationReportRepository : Repository<DonationReport>, IDonationReportRepository
    {
        private readonly ApplicationDbContext context;

        public DonationReportRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public List<DonationReport> GetAllReportsIncludeProject()
        {
            return context.Set<DonationReport>()
                          .Where(r => !r.IsDeleted)
                          .Include(dr => dr.Project)
                          .ToList();

        }

        public DonationReport GetOneWithProject(int id)
        {
            return context.Set<DonationReport>()
                          .Where(r => !r.IsDeleted)
                          .Include(dr => dr.Project)
                          .FirstOrDefault(dr => dr.id == id);
        }

    }
}
