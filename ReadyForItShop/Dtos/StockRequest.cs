using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyForItShop.Dtos
{
    public class StockRequest
    {
        public int StoreId { get; set; }

        public int ProductSkuId { get; set; }

        public ushort Quantity { get; set; }

        public ushort Price { get; set; }
    }
}
