//using Orangular.Database.Entities;
//using Orangular.DTO.Products.Requests;
//using Orangular.DTO.Products.Responses;
//using Orangular.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Orangular.Services
//{
//    public interface IProductsService
//    {
//        Task<List<ProductsResponse>> GetAllProducts();
//        Task<ProductsResponse> GetById(int products_id);
//        Task<ProductsResponse> Create(NewProducts newProducts);
//        Task<ProductsResponse> Update(int products_id, UpdateProducts updateAuthor);
//        Task<bool> Delete(int products_id);



//    }

//    public class ProductService : IProductsService
//    {
//        private readonly IProductsRepository _productsRepository;

//        public async Task<ProductsResponse> Create(NewProducts newProducts)
//        {
//            Products products = new Products
//            {
//                breed_name = newProducts.breed_name,
//                price = newProducts.price,
//                weight = newProducts.weight,
//                gender = newProducts.gender,
//                description = newProducts.description
//            };

//            products = await _productsRepository.Create(products);

//            return products == null ? null : new ProductsResponse
//            {
//                products_id = products.products_id,
//                breed_name = products.breed_name,
//                price = products.price,
//                weight = products.weight,
//                gender = products.gender,
//                description = products.description
//            };
//        }

//        public async Task<bool> Delete(int products_id)
//        {
//            var result = await _productsRepository.Delete(products_id);
//            return (result != null);
//        }

//        public async Task<List<ProductsResponse>> GetAllProducts()
//        {
//            List<Products> products = await _productsRepository.GetAll();

//            return products.Select(a => new ProductsResponse
//            {
//                products_id = a.products_id,
//                breed_name = a.breed_name,
//                price = a.price,
//                weight = a.weight,
//                gender = a.gender,
//                description = a.description

//                //    Books = a.Books.Select(b => new AuthorBookResponse
//                //    {
//                //        Id = b.Id,
//                //        Title = b.Title,
//                //        Pages = b.Pages
//                //    }).ToList()
//                }).ToList();
//            }

//        public async Task<ProductsResponse> GetById(int products_id)
//        {
//            Products products = await _productsRepository.GetById(products_id);
//            return products == null ? null : new ProductsResponse
//            {
//                products_id = products.products_id,
//                breed_name = products.breed_name,
//                price = products.price,
//                weight = products.weight,
//                gender = products.gender,
//                description = products.description,
//                //Books = author.Books.Select(b => new AuthorBookResponse
//                //{
//                //    Id = b.Id,
//                //    Title = b.Title,
//                //    Pages = b.Pages
//                //}).ToList()
//            };
//        }

//        public async Task<ProductsResponse> Update(int products_id, UpdateProducts updateAuthor)
//        {
//            Products products = new Products
//            {
//                breed_name = UpdateProducts.breed_name,
//                price = UpdateProducts.price,
//                weight = UpdateProducts.weight,
//                gender = UpdateProducts.gender,
//                description = UpdateProducts.description,
//            };

//            products = await _productsRepository.Update(products_id, products);

//            return products == null ? null : new ProductsResponse
//            {
//                Id = author.Id,
//                FirstName = author.FirstName,
//                LastName = author.LastName,
//                MiddleName = author.MiddleName
//            };
//        }
//    }
//}
