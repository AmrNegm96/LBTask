using CategoryProduct.Application.Contracts;
using CategoryProduct.Application.DTOs;
using CategoryProduct.Application.Mappers;
using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private CategoryMapper _categoryMapper;

        public CategoryService(IUnitOfWork unitOfWork , CategoryMapper categoryMapper )
        {   
            _categoryMapper = new CategoryMapper();
            _unitOfWork = unitOfWork;
        }

        public CategoryMapper CategoryMapper { get; }

        public List<CategoryDto> GetAllCategories()
        {
            var categoryList = _unitOfWork.Categories.GetAll().ToList();

            var categoryDtoList = _categoryMapper.MapFromModelToViewModel(categoryList);

            return categoryDtoList;
        }
    }
}
