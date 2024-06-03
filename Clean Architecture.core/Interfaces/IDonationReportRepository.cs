using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public interface IDonationReportRepository : IRepository<DonationReport>
    {
        List<DonationReport> GetAllReportsIncludeProject();
        DonationReport GetOneWithProject(int id);
    }
}