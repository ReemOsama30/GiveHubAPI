
using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IRepository<Project> projects { get; }
        public IRepository<Charity> charities { get; }


        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            projects = new Repository<Project>(context);
            charities = new Repository<Charity>(context);

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
