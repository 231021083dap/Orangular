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
        Task<Categories> GetById(int categoryId);
        Task<Categories> Greate(Categories category);
        Task<Categories> Update(int categoryId, Categories category);
        Task<bool> Delete(int categoryId);
    }
}
