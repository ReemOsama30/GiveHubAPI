using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.core.Entities;

namespace Clean_Architecture.core.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {

        public Task<List<Category>> GetAllCategoriesAsync();
    }
}
