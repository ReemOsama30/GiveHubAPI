using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;

namespace Clean_Architecture.core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        public Task<List<Project>> GetProjectsWithCategoryNameAsync();
        public List<Project> GetProjectsWithCategoryName();
        public Project GetOneProjectWithCategoryName(int id);
    }
}
