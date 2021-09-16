using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.products
{
    public interface IProductRepository
    {
        // ----- Interface signature of product ----- Muhmen P.//
        Task<List<Products>> getAll();
        Task<Products> getById(int productsId);
        Task<Products> create(Products products);
        Task<Products> update(int productsId, Products products);
        Task<bool> delete(int productsId);
        // ----- Interface signature of product ----- Muhmen P.//

    }
}

