using Orangular.Database.Entities;
using Orangular.DTO.Categories.Requests;
using Orangular.DTO.Categories.Responses;
using Orangular.Repositories.categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.categories
{
    interface ICategoryService
    {
        Task<List<Categories>> getAll();
        Task<Categories> getById(int categoriesId);
        Task<Categories> create(NewCategories newCategories);
        Task<Categories> update(int categoriesId, UpdateCategories updateCategories);
        Task<bool> delete(int categoriesId);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public async Task<Categories> create(NewCategories newCategories)
        {
            Categories categories = new Categories
            {
                category_name = newCategories.category_name
            };

            categories = await _categoryRepository.create(categories);

        /*    return categories == null ? null : new CategoriesResponse
            {
                categories_id = categories.categories_id,
                category_name = categories.category_name
            }; */
        }

        public Task<bool> delete(int categoriesId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Categories>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Categories> getById(int categoriesId)
        {
            throw new NotImplementedException();
        }

        public Task<Categories> update(int categoriesId, UpdateCategories updateCategories)
        {
            throw new NotImplementedException();
        }
    }
}
