using Microsoft.EntityFrameworkCore;
using ReadyForItShop.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReadyForItShop.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        public readonly DbaseContext _dbContext;
        public readonly DbSet<T> _dbTable;

        public GenericRepo(DbaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbTable = _dbContext.Set<T>();
        }

        public async Task<T> DeleteOne(int id)
        {
            try
            {
                T exist = await _dbTable.FindAsync(id);
                if (null == exist)
                    return null;

                _dbTable.Remove(exist);
                await Save();

                return exist;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("[Error] DeleteOne() => " + ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _dbTable.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("[Error] GetAll() => " + ex.Message);
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await _dbTable.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("[Error] GetById() => " + ex.Message);
            }
        }

        public async Task<T> InsertOne(T one)
        {
            try
            {
                await _dbTable.AddAsync(one);
                await Save();

                return await _dbTable.FindAsync(one);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("[Error] InsertOne() => " + ex.Message);
            }
        }

        public async Task<int> Save()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("[Error] Save() => " + ex.Message);
            }
        }

        public async Task<T> UpdateOne(int id, T one)
        {
            try
            {
                T exist = await _dbTable.FindAsync(id);
                if (null == exist)
                    return null;

                T updated = UpdateObjectProperties(exist, one);
                await Save();

                return updated;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("[Error] UpdateOne() => " + ex.Message);
            }
        }

        private U UpdateObjectProperties<U>(U dest, U src)
        {
            PropertyInfo[] properties = src.GetType().GetProperties();

            var notNullProperties = properties.ToList().FindAll(p => p.GetValue(src) != null);

            List<string> propertyNames = notNullProperties.Select(p => p.Name).Skip(1).ToList();
                //(from p in notNullProperties select p.Name).Skip(1).ToList();

            propertyNames.ToList().ForEach(p => Debug.WriteLine($"property: {p}" + "\n"));

            properties.Where(p => propertyNames.Contains(p.Name)).ToList()
                .ForEach(p => p.SetValue(dest, p.GetValue(src, null)));

            return dest;
        }
    }
}
