
using Clean_Architecture.core.Interfaces;
using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        private readonly IReviewRepository reviewRepository;
        // public IReviewRepository ReviewRepository { get; }
        public UnitOfWork(ApplicationDbContext context, IReviewRepository reviewRepository)
        {
            this.context = context;
            projects=new Repository<Project>(context);
            this.reviewRepository = reviewRepository;
            //ReviewRepository = new ReviewRepository(context);
        }

        public IRepository<Project> projects { get; }
        

        public IReviewRepository ReviewRepository => reviewRepository;


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
