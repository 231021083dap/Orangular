using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.CategoriesRepository {
    public interface ICategoryRepository
    {
        Task<List<Categories>> GetAll();
        Task<Categories> GetById(int categoryID);
        Task<Categories> Create(Categories category);
        Task<Categories> Update(int categoryID, Categories category);
        Task<bool> Delete(int categoryID);
    }
}
