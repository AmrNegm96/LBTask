using CategoryProduct.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Contracts
{
    public interface IProductService
    {
        int AddProduct(ProductDto product);
        int DeleteProduct(int id);
        List<ProductDto> GetProductsByCategoryId(int id);
        int UpdateProduct(ProductDto product);
    }
}
