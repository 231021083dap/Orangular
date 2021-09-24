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
        Task<ProductResponse> GetById(int productId);
        Task<ProductResponse> Create(NewProduct newProduct);
        Task<ProductResponse> Update(int productsId, UpdateProduct updateProduct);
        Task<bool> Delete(int productId);

    }
}
