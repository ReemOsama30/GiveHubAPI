using Clean_Architecture.Application.responses;
using Clean_Architecture.Application.services;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse>> GetCategories()
        {
            var categories = await categoryService.GetCategoryNamesAsync();
            var response = new GeneralResponse
            {
                IsPass = true,

                Message = categories,
                Status = 200
            };


            return response;
        }
    }
}
