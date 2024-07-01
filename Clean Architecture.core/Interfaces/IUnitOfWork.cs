
using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Entities;
using Clean_Architecture.Infrastructure.Repositories;


namespace Clean_Architecture.core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Project> projects { get; }
        public IRepository<Corporate> corporations { get; }
        public IRepository<Charity> charities { get; }
        public IRepository<Advertisment> advertisments { get; }
        public IRepository<Badge> Badges { get; }
        public IRepository<AwardedBadge> AwardedBadges { get; }

        public IUserRepository UserRepository { get; }
        public IDonationReportRepository DonationReportRepository { get; }
        public IReviewRepository reviewRepository { get; }
        public IDonorRepository donorRepository { get; }
        public ICategoryRepository categoryRepository { get; }
        public IProjectRepository projectRepository { get; }

        public int Save();
        public Task<int> SaveAsync();

        public IMoneyDonationRepository moneyDonationRepository { get; }
        public IInkindDonationRepository inKindDonationRepository { get; }


        public void Dispose();
    }
}
