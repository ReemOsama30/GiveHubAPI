using Clean_Architecture.core.Interfaces;
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
            this.reviewRepository = reviewRepository;
            //ReviewRepository = new ReviewRepository(context);
        }


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
