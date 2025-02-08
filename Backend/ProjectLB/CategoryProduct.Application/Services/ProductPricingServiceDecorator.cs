using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Services
{
    public class ProductPricingServiceDecorator : IProductPricingService
    {
        public decimal GetPrice(Product product)
        {
            return product.Price;
        }
    }
}
