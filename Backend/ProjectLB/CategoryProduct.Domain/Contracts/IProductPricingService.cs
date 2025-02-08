using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Domain.Contracts
{
    public interface IProductPricingService
    {
        decimal GetPrice(Product product);
    }
}
