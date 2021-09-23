using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.products
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAll();
        Task<Products> GetById(int products_id);
        Task<Products> Create(Products products);
        Task<Products> Update(int products_id, Products products);
        Task<Products> Delete(int products_id);
    }
}
