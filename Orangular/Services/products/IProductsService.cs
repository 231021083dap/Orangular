using Orangular.DTO.Products.Requests;
using Orangular.DTO.Products.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.products
{
    public interface IProductsService
    {
        Task<List<ProductsResponse>> GetAllProducts();
        Task<ProductsResponse> GetById(int products_id);
        Task<ProductsResponse> Create(NewProducts newProducts);
        Task<ProductsResponse> Update(int products_id, UpdateProducts updateAuthor);
        Task<bool> Delete(int products_id);



    }
}
