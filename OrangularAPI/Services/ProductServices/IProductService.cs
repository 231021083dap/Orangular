using OrangularAPI.DTO.Products.Requests;
using OrangularAPI.DTO.Products.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAll();
        Task<ProductResponse> GetById(int products_id);
        Task<ProductResponse> Create(NewProduct newProducts);
        Task<ProductResponse> Update(int products_id, UpdateProduct updateProduct);
        Task<bool> Delete(int products_id);

    }
}
