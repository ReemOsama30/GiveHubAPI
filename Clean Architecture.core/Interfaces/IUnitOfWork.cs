
using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.Infrastructure.Repositories;


namespace Clean_Architecture.core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Project> projects { get; }
        public IDonationReportRepository DonationReportRepository { get; }
        public IRepository<Corporate> corporations { get; }
        public IRepository<Charity> charities { get; }
        public IRepository<Advertisment> advertisments { get; }
        public IReviewRepository reviewRepository { get; }

        public IRepository<Badge> badgs { get; }


        public IDonorRepository donorRepository { get; }




        public int save();
        public void Dispose();
    }
}
