using AutoMapper;
using ReadyForItShop.Dtos;
using ReadyForItShop.Models;
using ReadyForItShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Services
{
    public class StockService
    {
        private readonly StockRepo _stockRepo;
        private readonly IMapper _mapper;

        public StockService(StockRepo stockRepo, IMapper mapper)
        {
            _stockRepo = stockRepo;
            _mapper = mapper;
        }

        public async Task<StockResponse> DeleteStockAsync(int id)
        {
            try
            {
                var response = await _stockRepo.DeleteOne(id);

                return _mapper.Map<StockResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] DeleteStockAsync() => " + ex.Message);
            }
        }

        public async Task<IEnumerable<StockResponse>> GetAllStocksAsync()
        {
            try
            {
                var response = await _stockRepo.GetAll();

                return _mapper.Map<IEnumerable<StockResponse>>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] GetAllStocksAsync() => " + ex.Message);
            }
        }

        public async Task<StockResponse> GetStockByIdAsync(int id)
        {
            try
            {
                var response = await _stockRepo.GetById(id);

                return _mapper.Map<StockResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] GetStockByIdAsync() => " + ex.Message);
            }
        }

        public async Task<StockResponse> InsertStockAsync(StockRequest p)
        {
            try
            {
                var request = _mapper.Map<Stock>(p);
                var response = await _stockRepo.InsertOne(request);

                return _mapper.Map<StockResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] InsertStockAsync() => " + ex.Message);
            }
        }

        public async Task<StockResponse> UpdateStockAsync(int id, StockRequest p)
        {
            try
            {
                var request = _mapper.Map<Stock>(p);
                var response = await _stockRepo.UpdateOne(id, request);

                return _mapper.Map<StockResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] UpdateStockAsync() => " + ex.Message);
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _stockRepo.SaveAsync();
        }
    }
}
