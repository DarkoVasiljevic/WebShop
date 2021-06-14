using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Models
{
    public class ProductSku
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public ulong Sku { get; set; }

        // Navigation properties

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
