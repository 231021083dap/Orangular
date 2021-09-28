using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Category.Responses
{
    public class CategoryResponse
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public List<CategoryProductResponse> products { get; set; }

    }
}
