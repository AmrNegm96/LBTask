using CategoryProduct.Application.Contracts;
using CategoryProduct.Application.DTOs;
using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Mappers
{
    public class CategoryMapper : MapperBase<Category, CategoryDto>
    {
        public override CategoryDto MapFromModelToViewModel(Category model)
        {
            if (model == null)
            {
                return null;
            }
            
            var categoryDto = new CategoryDto();

            categoryDto.Name = model.Name;
            categoryDto.Id = model.Id;

            return categoryDto;
        }

        public override Category MapFromViewModelToModel(CategoryDto viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            var category = new Category();

            category.Name = viewModel.Name;
            category.Id = viewModel.Id;
            
            return category;
        }
    }
}
