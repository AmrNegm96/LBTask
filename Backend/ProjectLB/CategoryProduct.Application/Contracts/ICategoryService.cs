using CategoryProduct.Application.DTOs;

namespace CategoryProduct.Application.Contracts
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategories();
    }
}
