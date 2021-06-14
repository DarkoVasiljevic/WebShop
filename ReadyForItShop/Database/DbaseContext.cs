using Microsoft.EntityFrameworkCore;
using ReadyForItShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Database
{
    public class DbaseContext : DbContext
    {
        public DbaseContext(DbContextOptions options) : base(options)
        {
                
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSku> ProductSkus { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasMany(p => p.ProductSkus)
                .WithOne(ps => ps.Product)
                .OnDelete(DeleteBehavior.Cascade)
                ;

            builder
                .Entity<ProductSku>()
                .HasOne(p => p.Product)
                .WithMany(ps => ps.ProductSkus)
                .HasForeignKey(fk => fk.ProductId)
                ;

            /*
            builder
                .Entity<Stock>()
                .HasIndex(ind => new { ind.StoreId, ind.ProductSkuId })
                .IsUnique()
                ;
            */

            builder
                .Entity<Stock>()
                .HasOne(ps => ps.ProductSku)
                .WithMany(st => st.Stocks)
                .HasForeignKey(fk => fk.ProductSkuId)
                ;

            builder
                .Entity<Stock>()
                .HasOne(s => s.Store)
                .WithMany(st => st.Stocks)
                .HasForeignKey(fk => fk.StoreId)
                ;

            DbaseSeed.Seed(builder);
        }


    }
}
