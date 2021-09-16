using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Categories.Responses
{
    public class CategoriesResponse
    {
        public int categories_id { get; set; }
        public string category_name { get; set; }
        public List<CategoriesProductsResponse> Products { get; set; }

    }
}
