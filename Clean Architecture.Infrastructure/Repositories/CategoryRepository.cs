using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await context.categories.ToListAsync();
        }
    }

}
