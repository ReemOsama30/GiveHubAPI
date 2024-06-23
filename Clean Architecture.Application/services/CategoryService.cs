using AutoMapper;
using Clean_Architecture.Application.DTOs.CategoryDTOs;
using Clean_Architecture.core.Interfaces;

namespace Clean_Architecture.Application.services
{
    public class CategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<showCategoriesDTO>> GetCategoryNamesAsync()
        {
            var categories = await unitOfWork.categoryRepository.GetAllCategoriesAsync();
            return mapper.Map<List<showCategoriesDTO>>(categories);
        }

        public int getCategoryIDbyName(string name)
        {
            {
                var category = unitOfWork.categoryRepository.Get(c => c.Name == name);
                return category.id;


            }
        }
    }
}
