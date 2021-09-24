using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.CategoriesRepository {
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int categoryID);
        Task<Category> Create(Category category);
        Task<Category> Update(int categoryID, Category category);
        Task<Category> Delete(int categoryID);
    }
}
