using CategoryProduct.Domain.Contracts;
using CategoryProduct.Domain.Entities;
using CategoryProduct.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<Category> Categories { get; }

        public IProductRepository Products { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Categories = new GenericRepository<Category>(_context);
            Products = new ProductRepository(_context);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
