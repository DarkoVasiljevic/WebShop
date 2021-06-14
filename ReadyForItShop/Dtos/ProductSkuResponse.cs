using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Dtos
{
    public class ProductSkuResponse
    {
        public int Id { get; set; }

        public ulong Sku { get; set; }

        public ICollection<StockResponse> Stocks { get; set; }
    }
}
