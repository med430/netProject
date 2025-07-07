using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class InMemoryRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_products);
        }

        public Task AddAsync(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }
    }
}
