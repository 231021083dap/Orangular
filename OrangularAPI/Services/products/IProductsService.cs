using OrangularAPI.DTO.Products.Requests;
using OrangularAPI.DTO.Products.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.products
{
    public interface IProductsService
    {
        Task<List<ProductsResponse>> GetAllProducts();
        Task<ProductsResponse> GetById(int products_id);
        Task<ProductsResponse> Create(NewProducts newProducts);
        Task<ProductsResponse> Update(int products_id, UpdateProducts updateProducts);
        Task<bool> Delete(int products_id);



    }
}
