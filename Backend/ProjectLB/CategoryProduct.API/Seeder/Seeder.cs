using CategoryProduct.Domain.Entities;
using CategoryProduct.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CategoryProduct.API.Seeder
{
    public static class Seeder
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Electronics" },
                    new Category { Name = "Clothing" },
                    new Category { Name = "Books" }
                );
                await context.SaveChangesAsync();
            }


            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Laptop", Description = "Gaming Laptop", Price = 1200, CategoryId = 1 },
                    new Product { Name = "T-Shirt", Description = "Cotton T-Shirt", Price = 20, CategoryId = 2 },
                    new Product { Name = "Book", Description = "C# Programming", Price = 30, CategoryId = 3 }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}

