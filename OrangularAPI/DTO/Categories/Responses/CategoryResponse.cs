using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Categories.Responses
{
    public class CategoryResponse
    {
        public int categories_id { get; set; }
        public string category_name { get; set; }
        public List<CategoryProductResponse> Products { get; set; }

    }
}
