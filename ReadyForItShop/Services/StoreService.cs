using ReadyForItShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadyForItShop.Models;
using AutoMapper;
using ReadyForItShop.Dtos;

namespace ReadyForItShop.Services
{
    public class StoreService
    {
        private readonly StoreRepo _storeRepo;
        private readonly IMapper _mapper;

        public StoreService(StoreRepo storeRepo, IMapper mapper)
        {
            _storeRepo = storeRepo;
            _mapper = mapper;
        }

        public async Task<StoreResponse> DeleteStoreAsync(int id)
        {
            try
            {
                var response = await _storeRepo.DeleteOne(id);

                return _mapper.Map<StoreResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] DeleteStoreAsync() => " + ex.Message);
            }
        }

        public async Task<IEnumerable<StoreResponse>> GetAllStoresAsync()
        {
            try
            {
                var response = await _storeRepo.GetAll();

                return _mapper.Map<IEnumerable<StoreResponse>>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] GetAllStoresAsync() => " + ex.Message);
            }
        }

        public async Task<StoreResponse> GetStoreByIdAsync(int id)
        {
            try
            {
                var response = await _storeRepo.GetById(id);

                return _mapper.Map<StoreResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] GetStoreByIdAsync() => " + ex.Message);
            }
        }

        public async Task<StoreResponse> InsertStoreAsync(StoreRequest p)
        {
            try
            {
                var request = _mapper.Map<Store>(p);
                var response = await _storeRepo.InsertStoreAsync(request);

                return _mapper.Map<StoreResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] InsertStoreAsync() => " + ex.Message);
            }
        }

        

        public async Task<StoreResponse> UpdateStoreAsync(int id, StoreRequest p)
        {
            try
            {
                var request = _mapper.Map<Store>(p);
                var response = await _storeRepo.UpdateOne(id, request);

                return _mapper.Map<StoreResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] UpdateStoreAsync() => " + ex.Message);
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _storeRepo.SaveAsync();
        }

        public object GetProductQuantityByStore(int id)
        {
            return _storeRepo.GetProductQuantityByStore(id);
        }
    }
}
