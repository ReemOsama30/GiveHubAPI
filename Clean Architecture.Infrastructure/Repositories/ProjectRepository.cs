using charityPulse.core.Models;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Project>> GetProjectsWithCategoryNameAsync()
        {
            return await context.projects.Include(p => p.category)
                                         .Include(p => p.Charity)
                                         .ToListAsync();
        }

        public List<Project> GetProjectsWithCategoryName()
        {
            return context.projects.Include(p => p.category)
                                   .Include(p => p.Charity)
                                   .ToList();
        }

        public Project GetOneProjectWithCategoryName(int id)
        {
            return context.projects.Include(p => p.category).FirstOrDefault(p => p.Id == id);
        }
    }
}
