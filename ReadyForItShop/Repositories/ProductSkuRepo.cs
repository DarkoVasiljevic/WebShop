using ReadyForItShop.Database;
using ReadyForItShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Repositories
{
    public class ProductSkuRepo : GenericRepo<ProductSku>, IGenericRepo<ProductSku>
    {
        public ProductSkuRepo(DbaseContext dbContext) : base(dbContext)
        {

        }

        public async Task<ProductSku> DeleteProductSkuAsync(int id)
        {
            return await DeleteOne(id);
        }

        public async Task<IEnumerable<ProductSku>> GetAllProductsSkuAsync()
        {
            return await GetAll();
        }

        public async Task<ProductSku> GetProductSkuByIdAsync(int id)
        {
            return await GetById(id);
        }

        public async Task<ProductSku> InsertProductSkuAsync(ProductSku p)
        {
            return await InsertOne(p);
        }

        public async Task<int> SaveAsync()
        {
            return await Save();
        }

        public async Task<ProductSku> UpdateProductSkuAsync(int id, ProductSku p)
        {
            return await UpdateOne(id, p);
        }

    }
}
