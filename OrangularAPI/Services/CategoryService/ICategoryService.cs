using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Categories>> getAll();
        Task<Categories> getById(int categoriesId);
        Task<Categories> create(Categories categories);
        Task<Categories> update(int categoriesId, Categories categories);
        Task<bool> delete(int categoriesId);
    }
}
