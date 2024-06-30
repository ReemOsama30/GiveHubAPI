using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext context;



        public IRepository<Corporate> corporations { get; }
        public IRepository<Project> projects { get; }
        public IRepository<Charity> charities { get; }
        public IRepository<Advertisment> advertisments { get; }

        public IRepository<Badge> Badges { get; }
        public IRepository<AwardedBadge> AwardedBadges { get; }



        public IReviewRepository reviewRepository { get; }

        public IMoneyDonationRepository moneyDonationRepository { get; }

        public IInkindDonationRepository inKindDonationRepository { get; }

       
        public IDonationReportRepository DonationReportRepository { get; }


        public IUserRepository UserRepository { get; }

        public IDonorRepository donorRepository { get; }

        public ICategoryRepository categoryRepository { get; }

        public IProjectRepository projectRepository { get; }

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;


            projects = new Repository<Project>(context);
            charities = new Repository<Charity>(context);
            corporations = new Repository<Corporate>(context);
            projects = new Repository<Project>(context);
            Badges = new Repository<Badge>(context);
            AwardedBadges= new Repository<AwardedBadge>(context);
            advertisments = new Repository<Advertisment>(context);

            reviewRepository = new ReviewRepository(context);
            DonationReportRepository = new DonationReportRepository(context);
            donorRepository = new DonorRepository(context);

            UserRepository = new UserRepository(userManager, context);

            moneyDonationRepository = new MoneyDonationRepository(context);

            inKindDonationRepository = new InkindDonationRepository(context);
            categoryRepository = new CategoryRepository(context);
            projectRepository = new ProjectRepository(context);

        }


        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }

}