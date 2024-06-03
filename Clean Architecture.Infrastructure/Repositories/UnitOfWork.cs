
using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private readonly IDonationReportRepository donationReportRepository;

        public IRepository<Project> projects { get; }

        public UnitOfWork(ApplicationDbContext context, IDonationReportRepository donationReportRepository)
        {
            this.context = context;
            this.donationReportRepository = donationReportRepository;
            projects = new Repository<Project>(context);


        }

        public IDonationReportRepository DonationReportRepository => donationReportRepository;

        public int save()
        {

            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
