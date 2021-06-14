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
    public class ProductSkuService
    {
        private readonly ProductSkuRepo _productSkuRepo;
        private readonly IMapper _mapper;

        public ProductSkuService(ProductSkuRepo productSkuRepo, IMapper mapper)
        {
            _productSkuRepo = productSkuRepo;
            _mapper = mapper;
        }

        public async Task<ProductSkuResponse> DeleteProductSkuAsync(int id)
        {
            try
            {
                var response = await _productSkuRepo.DeleteOne(id);

                return _mapper.Map<ProductSkuResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] DeleteProductSkuAsync() => " + ex.Message);
            }
        }

        public async Task<IEnumerable<ProductSkuResponse>> GetAllProductSkusAsync()
        {
            try
            {
                var response = await _productSkuRepo.GetAll();

                return _mapper.Map<IEnumerable<ProductSkuResponse>>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] GetAllProductSkusAsync() => " + ex.Message);
            }
        }

        public async Task<ProductSkuResponse> GetProductSkuByIdAsync(int id)
        {
            try
            {
                var response = await _productSkuRepo.GetById(id);

                return _mapper.Map<ProductSkuResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] GetProductSkuByIdAsync() => " + ex.Message);
            }
        }

        public async Task<ProductSkuResponse> InsertProductSkuAsync(ProductSkuRequest p)
        {
            try
            {
                var request = _mapper.Map<ProductSku>(p);
                var response = await _productSkuRepo.InsertOne(request);

                return _mapper.Map<ProductSkuResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] InsertProductSkuAsync() => " + ex.Message);
            }
        }

        public async Task<ProductSkuResponse> UpdateProductSkuAsync(int id, ProductSkuRequest p)
        {
            try
            {
                var request = _mapper.Map<ProductSku>(p);
                var response = await _productSkuRepo.UpdateOne(id, request);

                return _mapper.Map<ProductSkuResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] UpdateProductSkuAsync() => " + ex.Message);
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _productSkuRepo.SaveAsync();
        }
    }
}
