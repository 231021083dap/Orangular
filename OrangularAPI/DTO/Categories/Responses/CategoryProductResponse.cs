using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Categories.Responses
{
    public class CategoryProductResponse
    {
        public int productID { get; set; }

        public string breedName { get; set; }

        public int price { get; set; }

        public int weight { get; set; }

        public string gender { get; set; }

        public string description { get; set; }

    }
}
