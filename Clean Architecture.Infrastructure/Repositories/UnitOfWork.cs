
using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IRepository<Project> projects { get; }
        public IRepository<Advertisment> advertisments { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            projects=new Repository<Project>(context);
            advertisments=new Repository<Advertisment>(context);
           
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
