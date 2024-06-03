using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;

namespace Clean_Architecture.core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Project> projects { get; }
        public IRepository<Charity> charities { get; }
        public int save();
        public void Dispose();
    }
}
