using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Strategies
{
    public class DiscountPricingStrategy : IPricingStrategy
    {
        private readonly decimal _discountAmount;

        public DiscountPricingStrategy(decimal discountAmount)
        {
            _discountAmount = discountAmount;
        }

        public decimal CalculatePrice(Product product)
        {
            return product.Price - _discountAmount;
        }
    }
}
