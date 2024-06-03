
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

        public IRepository<Corporate> corporations { get; }
        public IRepository<Project> projects { get; }
        public IRepository<Charity> charities { get; }

        public IRepository<Advertisment> advertisments { get; }

        private readonly IReviewRepository reviewRepository;
        // public IReviewRepository ReviewRepository { get; }
        public UnitOfWork(ApplicationDbContext context, IReviewRepository reviewRepository, IDonationReportRepository donationReportRepository)
        {
            this.context = context;
            projects = new Repository<Project>(context);
            advertisments = new Repository<Advertisment>(context);
            this.reviewRepository = reviewRepository;
            this.donationReportRepository = donationReportRepository;
            corporations = new Repository<Corporate>(context);
            charities = new Repository<Charity>(context);
            //ReviewRepository = new ReviewRepository(context);


        }


        public IReviewRepository ReviewRepository => reviewRepository;
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
