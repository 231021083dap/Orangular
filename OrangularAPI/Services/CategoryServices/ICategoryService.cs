using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Mangler korrekt navngivning

namespace OrangularAPI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<Categories>> GetAll();
        Task<Categories> GetById(int categoryID);
        Task<Categories> Greate(Categories categories);
        Task<Categories> Update(int categoriesId, Categories categories);
        Task<bool> Delete(int categoriesId);
    }
}
