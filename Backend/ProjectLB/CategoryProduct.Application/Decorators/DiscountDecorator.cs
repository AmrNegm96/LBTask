using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Decorators
{

    public class DiscountDecorator : IProductPricingService
    {
        private readonly IProductPricingService _basicPricingService;
        private readonly decimal _discount;

        public DiscountDecorator(IProductPricingService basicPricingService, decimal discount)
        {
            _basicPricingService = basicPricingService;
            _discount = discount;
        }

        public decimal GetPrice(Product product)
        {
            decimal basePrice = _basicPricingService.GetPrice(product);
            return basePrice - _discount;
        }
    }
}

