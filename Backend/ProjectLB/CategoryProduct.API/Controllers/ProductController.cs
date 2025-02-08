using Azure;
using CategoryProduct.API.Models;
using CategoryProduct.Application.Contracts;
using CategoryProduct.Application.DTOs;
using CategoryProduct.Application.Services;
using CategoryProduct.Application.Strategies;
using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CategoryProduct.API.Controllers
{

    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ProductPricingServiceStrategy _pricingService;


        public ProductController(IProductService productService, ProductPricingServiceStrategy pricingService)
        {
            _productService = productService;
            _pricingService = pricingService;
        }

        [HttpGet]
        [Route("GetProductsByCategoryId/{id}")]
        public IActionResult GetProductsByCategoryId(int id)
        {
            var response = new ApiResponse<List<ProductDto>>(false, "", null);

            var productsList = _productService.GetProductsByCategoryId(id);

            if (productsList.Any() == true)
            {
                response.Data = productsList;
                response.Success = true;
                response.Message = $"All products of category Id = {id} retrieved";
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(ProductDto product)
        {
            var response = new ApiResponse<ProductDto>(false, "", null);

            var saved = _productService.AddProduct(product);

            if (saved > 0)
            {
                response.Success = true;
                response.Data = product;
                response.Message = "Product Added";
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(ProductDto product)
        {
            var response = new ApiResponse<ProductDto>(false, "", null);

            var updated = _productService.UpdateProduct(product);

            if (updated > 0)
            {
                response.Success = true;
                response.Data = product;
                response.Message = "Product Updated";
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var response = new ApiResponse<ProductDto>(false, "", null);
            var deleted = _productService.DeleteProduct(id);

            if (deleted > 0)
            {
                response.Success = true;
                response.Data = null;
                response.Message = "Product deleted";
            }

            return Ok(response);
        }

        //test global error handling
        [HttpGet]
        [Route("TestGlobalError")]
        public IActionResult TestGlobalError()
        {
            throw new Exception("Something went wrong!");
        }

        //strategy pattern test
        [HttpGet("{name}/price")]
        public IActionResult GetProductPrice(string name, [FromQuery] string strategy, [FromQuery] decimal value = 0)
        {
            var product = new Product { Id = 1000, Name = name, Price = 1000 };

            switch (strategy?.ToLower())
            {
                case "discount":
                    _pricingService.SetPricingStrategy(new DiscountPricingStrategy(value));
                    break;
                case "tax":
                    _pricingService.SetPricingStrategy(new TaxPricingStrategy(value));
                    break;
                default:
                    _pricingService.SetPricingStrategy(new StandardPricingStrategy());
                    break;
            }

            var price = _pricingService.GetPrice(product);
            return Ok(new { product.Name, FinalPrice = price });
        }
    }
}
