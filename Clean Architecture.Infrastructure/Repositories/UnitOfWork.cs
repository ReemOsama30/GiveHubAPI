
using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public IDonationReportRepository DonationReportRepository { get; }

        public IRepository<Corporate>corporations { get; }
        public IRepository<Project> projects { get; }
        public IRepository<Charity> charities { get; }
        public IRepository<Advertisment> advertisments { get; }

        public IReviewRepository reviewRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            projects = new Repository<Project>(context);
            charities = new Repository<Charity>(context);
            corporations = new Repository<Corporate>(context);
            projects = new Repository<Project>(context);
            advertisments = new Repository<Advertisment>(context);
            this.reviewRepository =new ReviewRepository(context);
            this.DonationReportRepository = new DonationReportRepository(context);
        }




       


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
