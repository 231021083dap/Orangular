using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.categories
{
    interface ICategoryRepository
    {
        Task<List<Categories>> getAll();
        Task<Categories> getById(int categoriesId);
        Task<Categories> create(Categories categories);
        Task<Categories> update(int categoriesId, Categories categories);
        Task<Categories> delete(int categoriesId);
    }
}
