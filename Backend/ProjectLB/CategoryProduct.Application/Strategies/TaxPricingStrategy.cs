using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Strategies
{
    public class TaxPricingStrategy : IPricingStrategy
    {
        private readonly decimal _taxRate;

        public TaxPricingStrategy(decimal taxRate)
        {
            _taxRate = taxRate;
        }

        public decimal CalculatePrice(Product product)
        {
            return product.Price * (1 + _taxRate / 100);
        }
    }
}
