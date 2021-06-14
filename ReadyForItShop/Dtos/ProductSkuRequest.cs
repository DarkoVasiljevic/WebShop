using System.Collections.Generic;

namespace ReadyForItShop.Dtos
{
    public class ProductSkuRequest
    {
        public int ProductId { get; set; }

        public ulong Sku { get; set; }
    }
}
