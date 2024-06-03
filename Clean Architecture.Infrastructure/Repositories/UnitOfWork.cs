
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

        private readonly IReviewRepository reviewRepository;
        // public IReviewRepository ReviewRepository { get; }
        public UnitOfWork(ApplicationDbContext context, IReviewRepository reviewRepository, IDonationReportRepository donationReportRepository)
        {
            this.context = context;
            projects = new Repository<Project>(context);
            this.reviewRepository = reviewRepository;
            this.donationReportRepository = donationReportRepository;
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
