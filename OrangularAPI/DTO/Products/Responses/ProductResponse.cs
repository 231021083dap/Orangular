using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Products.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public ProductCategoryResponse Category { get; set; }
       
    }
}
