using CategoryProduct.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Categories { get; }
        IProductRepository Products { get; }
        int Commit();
    }
}
