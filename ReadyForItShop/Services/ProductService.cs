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
    public class ProductService
    {
        private readonly ProductRepo _productRepo;
        private readonly ProductSkuRepo _productSkuRepo;
        private readonly IMapper _mapper;

        public ProductService(ProductRepo productRepo, ProductSkuRepo productSkuRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _productSkuRepo = productSkuRepo;
            _mapper = mapper;
        }

        public async Task<ProductResponse> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _productRepo.DeleteProductAsync(id);

                return _mapper.Map<ProductResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] DeleteProductAsync() => " + ex.Message);
            }
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            try
            {
                var response = await _productRepo.GetAllProductsAsync();

                return _mapper.Map<IEnumerable<ProductResponse>>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] GetAllProductsAsync() => " + ex.Message);
            }
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _productRepo.GetProductByIdAsync(id);

                return _mapper.Map<ProductResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] GetProductByIdAsync() => " + ex.Message);
            }
        }

        public async Task<ProductResponse> InsertProductAsync(ProductRequest p)
        {
            try
            {

                var request = _mapper.Map<Product>(p);
                var response = await _productRepo.InsertProductAsync(request);

                return _mapper.Map<ProductResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] InsertProductAsync() => " + ex.Message);
            }
        }

        public async Task<ProductResponse> UpdateProductAsync(int id, ProductRequest p)
        {
            try
            {
                var request = _mapper.Map<Product>(p);
                var response = await _productRepo.UpdateProductAsync(id, request);

                return _mapper.Map<ProductResponse>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("[Error] UpdateProductAsync() => " + ex.Message);
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _productRepo.SaveAsync();
        }
    }
}
