using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string? Weight { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Product() { }    
        public Product(string name, int price, int categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
