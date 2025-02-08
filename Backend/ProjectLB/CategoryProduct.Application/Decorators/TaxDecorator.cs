using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Decorators
{
    public class TaxDecorator : IProductPricingService
    {
        private readonly IProductPricingService _basicPricingService;
        private readonly decimal _taxRate;
        public TaxDecorator(IProductPricingService basicPricingService , decimal taxFees) 
        { 
            _basicPricingService = basicPricingService;
            _taxRate = taxFees;
        }
        public decimal GetPrice(Product product)
        {
            decimal basePrice = _basicPricingService.GetPrice(product);
            return basePrice * (1 + _taxRate / 100);
        }
    }
}
