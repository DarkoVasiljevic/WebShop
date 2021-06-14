using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Models
{
    public class Stock
    {
        [Required]
        public int Id { get; set; }

        public ushort Quantity { get; set; }

        public ushort Price { get; set; }

        // Navigation properties

        public Store Store { get; set; }

        public int StoreId { get; set; }

        public ProductSku ProductSku { get; set; }

        public int ProductSkuId { get; set; }
    }
}
