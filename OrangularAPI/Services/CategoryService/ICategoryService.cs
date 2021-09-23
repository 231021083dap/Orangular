using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Categories>> GetAll();
        Task<Categories> GetById(int categoriesId);
        Task<Categories> Greate(Categories categories);
        Task<Categories> Update(int categoriesId, Categories categories);
        Task<bool> Delete(int categoriesId);
    }
}
