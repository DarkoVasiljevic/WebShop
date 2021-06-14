using AutoMapper;
using ReadyForItShop.Dtos;
using ReadyForItShop.Models;

namespace ReadyForItShop.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>();

            CreateMap<ProductSku, ProductSkuResponse>();
            CreateMap<ProductSkuRequest, ProductSku>();

            CreateMap<Stock, StockResponse>();
            CreateMap<StockRequest, Stock>();

            CreateMap<Store, StoreResponse>();
            CreateMap<StoreRequest, Store>();
        }
    }
}
