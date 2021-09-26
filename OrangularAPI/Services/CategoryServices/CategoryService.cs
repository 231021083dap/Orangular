//using Orangular.Database.Entities;
//using Orangular.DTO.Category.Requests;
//using Orangular.DTO.Category.Responses;
//using Orangular.Repositories.Category;
//using OrangularAPI.Database.Entities;
//using OrangularAPI.DTO.Category.Requests;
//using OrangularAPI.DTO.Category.Responses;

//using OrangularAPI.Repositories.CategoryRepository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OrangularAPI.Services.CategoryServices
//{
//   public interface ICategoryService
//    {
//        Task<List<CategoryResponse>> getAll();
//        Task<CategoryResponse> getById(int CategoryId);
//        Task<CategoryResponse> create(NewCategory newCategory);
//        Task<CategoryResponse> update(int CategoryId, UpdateCategory updateCategory);
//        Task<bool> delete(int CategoryId);
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
//            //    CategoryName = newCategory.CategoryName
//            //};

//            //category = await _categoryRepository.create(category);

//            //return category == null ? null : new CategoryResponse
//            //{
//            //Id = category.Id,
//            // CategoryName = category.CategoryName

//            //};
//        }

//        public async Task<bool> delete(int CategoryId)
//        {
//            var result = await _categoryRepository.delete(CategoryId);
//            return true;
//        }

//        public async Task<List<CategoryResponse>> getAll()
//        {
//            //List<Category> Category = await _categoryRepository.getAll();
//            //return Category.Select(c => new CategoryResponse
//            //{
//            //    Id = c.Id,
//            //    CategoryName = c.CategoryName,
//            //    products = c.products.Select(p => new CategoryProductsResponse
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

//        public async Task<CategoryResponse> getById(int CategoryId)
//        {
//            //Category Category = await _categoryRepository.getById(CategoryId);
//            //return Category == null ? null : new CategoryResponse
//            //{
//            //    Id = Category.Id,
//            //    CategoryName = Category.CategoryName
//            //};
//        }

//        public async Task<CategoryResponse> update(int CategoryId, UpdateCategory updateCategory)
//        {
//        //   Category Category = new Category
//        //   {
//        //       CategoryName = updateCategory.CategoryName
//        //   };

//        //   Category = await _categoryRepository.update(CategoryId, Category);

//        //    return Category == null ? null : new CategoryResponse { 
//        //        Id = Category.Id, 
//        //        CategoryName = Category.CategoryName 
//        //    };
//        //}


//    }
//}

//// ----- CRUD on category ----- Muhmen P.//