using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Category.Responses
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<CategoryProductResponse> Products { get; set; }

    }
}
