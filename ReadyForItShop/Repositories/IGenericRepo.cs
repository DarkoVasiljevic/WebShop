using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Repositories
{
    interface IGenericRepo <T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> InsertOne(T one);
        public Task<T> UpdateOne(int id, T one);
        public Task<T> DeleteOne(int id);
        public Task<int> Save();
    }
}
