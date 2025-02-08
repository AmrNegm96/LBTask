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
    public class ProductMapper : MapperBase<Product, ProductDto>
    {
        public override ProductDto MapFromModelToViewModel(Product model)
        {
            if (model == null)
            {
                return null;
            }

            var productDto = new ProductDto();

            productDto.Id = model.Id;
            productDto.Name = model.Name;
            productDto.Price = model.Price;
            productDto.CategoryId = model.CategoryId;
            productDto.Description = model.Description;

            return productDto;
        }

        public override Product MapFromViewModelToModel(ProductDto viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            var product = new Product();

            product.Id = viewModel.Id;
            product.Name = viewModel.Name;
            product.Price = viewModel.Price;
            product.CategoryId = viewModel.CategoryId;
            product.Description = viewModel.Description;

            return product;
        }
    }
}
