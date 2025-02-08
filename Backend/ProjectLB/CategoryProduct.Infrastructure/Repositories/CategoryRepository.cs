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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
