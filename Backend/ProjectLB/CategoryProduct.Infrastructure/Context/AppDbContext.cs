using CategoryProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Product>()
           .HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
        }

    }
}
