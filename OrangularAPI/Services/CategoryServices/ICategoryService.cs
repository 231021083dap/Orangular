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
        Task<List<Category>> GetAll();
        Task<Category> GetById(int categoryId);
        Task<Category> Greate(Category category);
        Task<Category> Update(int categoryId, Category category);
        Task<bool> Delete(int categoryId);
    }
}
