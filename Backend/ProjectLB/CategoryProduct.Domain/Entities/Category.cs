using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; } 

        public Category() { }
        public Category(string name)
        {
            Name = name;
        }
    }
}