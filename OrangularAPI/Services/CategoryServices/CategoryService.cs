//using Orangular.Database.Entities;
//using Orangular.DTO.Category.Requests;
//using Orangular.DTO.Category.Responses;
//using Orangular.Repositories.categories;
//using OrangularAPI.Database.Entities;
//using OrangularAPI.DTO.Categories.Requests;
//using OrangularAPI.DTO.Categories.Responses;

//using OrangularAPI.Repositories.CategoriesRepository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OrangularAPI.Services.CategoryServices
//{
//   public interface ICategoryService
//    {
//        Task<List<CategoryResponse>> getAll();
//        Task<CategoryResponse> getById(int categoriesId);
//        Task<CategoryResponse> create(NewCategory newCategories);
//        Task<CategoryResponse> update(int categoriesId, UpdateCategory updateCategories);
//        Task<bool> delete(int categoriesId);
//    }

//    // -----  ----- Muhmen P.//
//    public class CategoryService : ICategoryService
//    {
//        private readonly ICategoryRepository _categoryRepository;

//        public CategoryService(ICategoryRepository categoryRepository)
//        {
//            _categoryRepository = categoryRepository;
//        }

//        public async Task<CategoryResponse> create(NewCategory newCategory)
//        {
//            //Category category = new Category
//            //{
//            //    category_name = newCategory.category_name
//            //};

//            //category = await _categoryRepository.create(category);

//            //return category == null ? null : new CategoryResponse
//            //{
//            //categories_id = category.categories_id,
//            // category_name = category.category_name

//            //};
//        }

//        public async Task<bool> delete(int categoriesId)
//        {
//            var result = await _categoryRepository.delete(categoriesId);
//            return true;
//        }

//        public async Task<List<CategoryResponse>> getAll()
//        {
//            //List<Category> categories = await _categoryRepository.getAll();
//            //return categories.Select(c => new CategoryResponse
//            //{
//            //    categories_id = c.categories_id,
//            //    category_name = c.category_name,
//            //    products = c.products.Select(p => new CategoriesProductsResponse
//            //    {
//            //        ProductId = p.ProductId,
//            //        breed_name = p.breed_name,
//            //        price = p.price,
//            //        weight = p.weight,
//            //        gender = p.gender,
//            //        description = p.description

//            //    }).ToList()

//            //}).ToList();
//        }

//        public async Task<CategoryResponse> getById(int categoriesId)
//        {
//            //Category categories = await _categoryRepository.getById(categoriesId);
//            //return categories == null ? null : new CategoryResponse
//            //{
//            //    categories_id = categories.categories_id,
//            //    category_name = categories.category_name
//            //};
//        }

//        public async Task<CategoryResponse> update(int categoriesId, UpdateCategory updateCategories)
//        {
//        //   Category categories = new Category
//        //   {
//        //       category_name = updateCategories.category_name
//        //   };

//        //   categories = await _categoryRepository.update(categoriesId, categories);

//        //    return categories == null ? null : new CategoryResponse { 
//        //        categories_id = categories.categories_id, 
//        //        category_name = categories.category_name 
//        //    };
//        //}


//    }
//}

//// ----- CRUD on category ----- Muhmen P.//