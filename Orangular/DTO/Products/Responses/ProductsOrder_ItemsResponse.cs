using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Products.Responses
{
    public class ProductsOrder_ItemsResponse
    {
        public int order_items_id { get; set; }

        public int order_lists_id { get; set; }

        public int price { get; set; }

        public int quantity { get; set; }

    }
}
