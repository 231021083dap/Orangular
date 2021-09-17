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
        Task<List<CategoriesResponse>> getAll();
        Task<CategoriesResponse> getById(int categoriesId);
        Task<CategoriesResponse> create(NewCategories newCategories);
        Task<CategoriesResponse> update(int categoriesId, UpdateCategories updateCategories);
        Task<bool> delete(int categoriesId);
    }

    // -----  ----- Muhmen P.//
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public async Task<CategoriesResponse> create(NewCategories newCategories)
        {
            Categories categories = new Categories
            {
                category_name = newCategories.category_name
            };

            categories = await _categoryRepository.create(categories);

            return categories == null ? null : new CategoriesResponse
            {
             category_name = newCategories.category_name,

            };
        }

        public async Task<bool> delete(int categoriesId)
        {
            var result = await _categoryRepository.delete(categoriesId);
            return true;
        }

        public async Task<List<CategoriesResponse>> getAll()
        {
            List<Categories> categories = await _categoryRepository.getAll();
            return categories.Select(c => new CategoriesResponse
            {
                categories_id = c.categories_id,
                category_name = c.category_name,
                products = c.products.Select(p => new CategoriesProductsResponse
                {
                    products_id = p.products_id,
                    breed_name = p.breed_name,
                    price = p.price,
                    weight = p.weight,
                    gender = p.gender,
                    description = p.description

                }).ToList()

            }).ToList();
        }

        public async Task<CategoriesResponse> getById(int categoriesId)
        {
            Categories categories = await _categoryRepository.getById(categoriesId);
            return categories == null ? null : new CategoriesResponse
            {
                categories_id = categories.categories_id,
                category_name = categories.category_name
            };
        }

        public async Task<CategoriesResponse> update(int categoriesId, UpdateCategories updateCategories)
        {
           Categories categories = new Categories
           {
               category_name = updateCategories.category_name
           };

           categories = await _categoryRepository.update(categoriesId, categories);

            return categories == null ? null : new CategoriesResponse { 
                categories_id = categories.categories_id, 
                category_name = categories.category_name 
            };
        }

      
    }
}

// ----- CRUD on category ----- Muhmen P.//