using ReadyForItShop.Database;
using ReadyForItShop.Dtos;
using ReadyForItShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Repositories
{
    public class StoreRepo : GenericRepo<Store>
    {

        public StoreRepo(DbaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Store> DeleteStoreAsync(int id)
        {
            return await DeleteOne(id);
        }

        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {
            return await GetAll();
        }

        public async Task<Store> GetStoreByIdAsync(int id)
        {
            return await GetById(id);
        }

        public object GetProductQuantityByStore(int id)
        {
            /* SQL Query
            select s.Name, p.Name, sum(st.Quantity) ProductQuantityByStore
            from Stores s join Stocks st on s.Id = st.StoreId
		    join ProductSkus ps on ps.Id = st.ProductSkuId
		    join Products p on p.Id = ps.ProductId
            group by s.Id, s.Name, p.Name;
            */

            var result = _dbContext.Stores
                            .Join(_dbContext.Stocks,
                                    store => store.Id,
                                    stock => stock.StoreId,
                                    (store, stock) => new { store, stock })
                            .Join(_dbContext.ProductSkus,
                                    o => o.stock.ProductSkuId,
                                    productSku => productSku.Id,
                                    (o, productSku) => new { o, productSku })
                            .Join(_dbContext.Products,
                                    o => o.productSku.ProductId,
                                    product => product.Id,
                                    (o, product) => new
                                    {
                                        StoreId = o.o.store.Id,
                                        ProductName = product.Name,
                                        StoreName = o.o.store.Name,
                                        Quantity = o.o.stock.Quantity
                                    })
                            .Where(e => e.StoreId == id)
                            .AsEnumerable()
                            .GroupBy(g => new { g.StoreId , g.StoreName, g.ProductName })
                            .Select(r => new
                            {
                                r.Key.StoreId,
                                r.Key.StoreName,
                                r.Key.ProductName,
                                Quantity = r.Sum(s => s.Quantity)
                            })
                            ;

            return result;
        }

        public async Task<Store> InsertStoreAsync(Store p)
        {
            await _dbContext.Stores.AddAsync(p);
            await SaveAsync();

            return p;
        }

        public async Task<int> SaveAsync()
        {
            return await Save();
        }

        public async Task<Store> UpdateStoreAsync(int id, Store p)
        {
            return await UpdateOne(id, p);
        }

    }
}
