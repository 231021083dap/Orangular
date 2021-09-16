using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Products.Responses
{
    public class ProductsResponse
    {
        public int products_id { get; set; }
        public string breed_name { get; set; }
        public int price { get; set; }
        public int weight { get; set; }
        public string gender { get; set; }
        public string description { get; set; }
        public ProductsCategoriesResponse Categories { get; set; }
       
    }
}
