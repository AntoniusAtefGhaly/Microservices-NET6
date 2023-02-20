using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Catalog.API.Repositories
{
    public class ProductRepository : ICatalogApi
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context
                           .Products
                           .Where(p => (p.Id == id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context
               .Products
               .Where(p => p.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            return await _context
            .Products
                             .Where(p => p.Category == categoryName)
                            .ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = _context
                                        .Products
                                        .Update(product);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(P => P.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                return false;
            }
            _context.SaveChanges();
            return true;
        }
    }
}