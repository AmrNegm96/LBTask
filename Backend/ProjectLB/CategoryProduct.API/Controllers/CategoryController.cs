using CategoryProduct.API.Models;
using CategoryProduct.Application.Contracts;
using CategoryProduct.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CategoryProduct.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var response = new ApiResponse<List<CategoryDto>>(false, "", null);

            var categories = _categoryService.GetAllCategories();

            if(categories.Any() == true)
            {
                response.Data = categories;
                response.Success = true;
                response.Message = "All categories retrieved";
            }
           
            return Ok(response);
        }


    }
}
