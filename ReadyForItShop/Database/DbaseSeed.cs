using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadyForItShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Database
{
    public static class DbaseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                
                new Product()
                {
                    Id = 7520,
                    Name = "Jeans",
                    ImageUrl = "https://api.ps.rs/service/mainImageByOid.php"
                },
                new Product()
                {
                    Id = 7521,
                    Name = "Sneakers",
                    ImageUrl = "https://api.ps.rs/service/mainImageByOid.php"
                });

                
            builder.Entity<ProductSku>().HasData(
                new ProductSku()
                {
                    Id = 12,
                    ProductId = 7520,
                    Sku = 0215012604
                },
                new ProductSku()
                {
                    Id = 13,
                    ProductId = 7520,
                    Sku = 1021019836
                },
                new ProductSku()
                {
                    Id = 14,
                    ProductId = 7520,
                    Sku = 1074015042
                },
                new ProductSku()
                {
                    Id = 15,
                    ProductId = 7521,
                    Sku = 4040016400
                },
                new ProductSku()
                {
                    Id = 16,
                    ProductId = 7521,
                    Sku = 4533510440
                },
                new ProductSku()
                {
                    Id = 17,
                    ProductId = 7521,
                    Sku = 3206520434
                });

            builder.Entity<Store>().HasData(

               new Store()
               {
                   Id = 1,
                   Name = "MPO",
                   Address = "Main Road 4"
               },
               new Store()
               {
                   Id = 2,
                   Name = "MSO",
                   Address = "Park Avenue 8"
               });

            builder.Entity<Stock>().HasData(
                new Stock()
                {
                    Id = 1,
                    StoreId = 1,
                    ProductSkuId = 17,
                    Quantity = 2,
                    Price = 8
                },
                new Stock()
                {
                    Id = 2,
                    StoreId = 1,
                    ProductSkuId = 14,
                    Quantity = 3,
                    Price = 0
                },
                new Stock()
                {
                    Id = 3,
                    StoreId = 1,
                    ProductSkuId = 12,
                    Quantity = 1,
                    Price = 2
                },
                new Stock()
                {
                    Id = 4,
                    StoreId = 2,
                    ProductSkuId = 13,
                    Quantity = 1,
                    Price = 7
                },
                new Stock()
                {
                    Id = 5,
                    StoreId = 2,
                    ProductSkuId = 17,
                    Quantity = 4,
                    Price = 3
                });
        }
    }
}
