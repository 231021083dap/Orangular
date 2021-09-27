using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Category.Requests;
using OrangularAPI.DTO.Category.Responses;
using OrangularAPI.Repositories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryResponse>> GetAll()
        {
            List<Category> Category = await _categoryRepository.GetAll();
            return Category.Select(c => new CategoryResponse
            {
                categoryID = c.Id,
                categoryName = c.CategoryName,
                products = c.Product.Select(p => new CategoryProductResponse
                {
                    productID = p.Id,
                    breedName = p.BreedName,
                    price = p.Price,
                    weight = p.Weight,
                    gender = p.Gender,
                    description = p.Description

                }).ToList()

            }).ToList();
        }
        public async Task<CategoryResponse> GetById(int CategoryId)
        {
            Category Category = await _categoryRepository.GetById(CategoryId);
            return Category == null ? null : new CategoryResponse
            {
                categoryID = Category.Id,
                categoryName = Category.CategoryName,
                products = Category.Product.Select(p => new CategoryProductResponse
                {
                    productID = p.Id,
                    breedName = p.BreedName,
                    price = p.Price,
                    weight = p.Weight,
                    gender = p.Gender,
                    description = p.Description
                }).ToList()
            };
        }
        public async Task<CategoryResponse> Create(NewCategory newCategory)
        {
            Category category = new Category
            {
                CategoryName = newCategory.categoryName
            };

            category = await _categoryRepository.Create(category);

            return category == null ? null : new CategoryResponse
            {
                categoryID = category.Id,
                categoryName = category.CategoryName
            };
        }
        public async Task<CategoryResponse> Update(int CategoryId, UpdateCategory updateCategory)
        {
            Category Category = new Category
            {
                CategoryName = updateCategory.categoryName
            };

            Category = await _categoryRepository.Update(CategoryId, Category);

            return Category == null ? null : new CategoryResponse
            {
                categoryID = Category.Id,
                categoryName = Category.CategoryName
            };
        }
        public async Task<bool> Delete(int CategoryId)
        {
            var result = await _categoryRepository.Delete(CategoryId);
            if (result != null) return true;
            else return false;
        }
    }
}
