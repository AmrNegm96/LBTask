using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Services
{
    public class ProductPricingServiceStrategy
    {
        private IPricingStrategy _pricingStrategy;

        public ProductPricingServiceStrategy(IPricingStrategy pricingStrategy)
        {
            _pricingStrategy = pricingStrategy;
        }

        public void SetPricingStrategy(IPricingStrategy pricingStrategy)
        {
            _pricingStrategy = pricingStrategy;
        }

        public decimal GetPrice(Product product)
        {
            return _pricingStrategy.CalculatePrice(product);
        }
    }
}

