using ReadyForItShop.Database;
using ReadyForItShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Repositories
{
    public class StockRepo : GenericRepo<Stock>
    {

        public StockRepo(DbaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Stock> DeleteStockAsync(int id)
        {
            return await DeleteOne(id);
        }

        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            return await GetAll();
        }

        public async Task<Stock> GetStockByIdAsync(int id)
        {
            return await GetById(id);
        }

        public async Task<Stock> InsertStockAsync(Stock p)
        {
            return await InsertOne(p);
        }

        public async Task<int> SaveAsync()
        {
            return await Save();
        }

        public async Task<Stock> UpdateStockAsync(int id, Stock p)
        {
            return await UpdateOne(id, p);
        }

    }
}
