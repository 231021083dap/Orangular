using OrangularAPI.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.ProductsRepository
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAll();
        Task<Products> GetById(int products_id);
        Task<Products> Create(Products products);
        Task<Products> Update(int products_id, Products products);
        Task<Products> Delete(int products_id);
    }
}
