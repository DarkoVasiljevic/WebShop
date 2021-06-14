using Microsoft.EntityFrameworkCore;
using ReadyForItShop.Database;
using ReadyForItShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Repositories
{
    public class ProductRepo : GenericRepo<Product>, IGenericRepo<Product>
    {
        public ProductRepo(DbaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            return await DeleteOne(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products
                .Include(ps => ps.ProductSkus)
                .ThenInclude(s => s.Stocks)
                .ThenInclude(st => st.Store)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products
                .Include(ps => ps.ProductSkus)
                //.ThenInclude(s => s.Stocks)
                //.ThenInclude(st => st.Store)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Product> InsertProductAsync(Product p)
        {
            return await InsertOne(p);
        }

        public async Task<int> SaveAsync()
        {
            return await Save();
        }

        public async Task<Product> UpdateProductAsync(int id, Product p)
        {
            return await UpdateOne(id, p);
        }

    }
}
