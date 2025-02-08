using CategoryProduct.Application.Contracts;
using CategoryProduct.Application.DTOs;
using CategoryProduct.Application.Mappers;
using CategoryProduct.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Services
{
    public class ProductService : IProductService
    {
        private ProductMapper _productMapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork, ProductMapper productMapper)
        {
            _unitOfWork = unitOfWork;
            _productMapper = productMapper;
        }

        public int AddProduct(ProductDto productDto)
        {
            var product = _productMapper.MapFromViewModelToModel(productDto);
            _unitOfWork.Products.Add(product);
            var saved = _unitOfWork.Commit();
            return saved;
        }

        public List<ProductDto> GetProductsByCategoryId(int id)
        {
            var productList = _unitOfWork.Products.GetProductsByCategoryId(id).ToList();

            var productDtoList = _productMapper.MapFromModelToViewModel(productList);

            return productDtoList;
        }

        public int UpdateProduct(ProductDto product)
        {
            var originalProduct = _unitOfWork.Products.GetById(product.Id);

            originalProduct.Description = product.Description;
            originalProduct.Price = product.Price;
            originalProduct.Name = product.Name;
            originalProduct.CategoryId = product.CategoryId;

             _unitOfWork.Products.Update(originalProduct);
            var updated = _unitOfWork.Commit();
            return updated;
        }

        public int DeleteProduct(int id)
        {
            _unitOfWork.Products.Delete(id);
            var deleted = _unitOfWork.Commit();
            return deleted;
        }
    }
}
