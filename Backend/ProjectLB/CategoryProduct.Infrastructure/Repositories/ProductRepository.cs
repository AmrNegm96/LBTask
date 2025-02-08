using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using CategoryProduct.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository 
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

    }
}
