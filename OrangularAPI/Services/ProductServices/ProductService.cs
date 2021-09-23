using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Products.Requests;
using OrangularAPI.DTO.Products.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.ProductServices
{


    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductsResponse> Create(NewProducts newProducts)
        {
            Products products = new Products
            {
                breed_name = newProducts.breed_name,
                price = newProducts.price,
                weight = newProducts.weight,
                gender = newProducts.gender,
                description = newProducts.description
            };

            products = await _productsRepository.Create(products);

            return products == null ? null : new ProductsResponse
            {
                products_id = products.products_id,
                breed_name = products.breed_name,
                price = products.price,
                weight = products.weight,
                gender = products.gender,
                description = products.description
            };
        }

        public async Task<bool> Delete(int products_id)
        {
            var result = await _productsRepository.Delete(products_id);
            return (result != null);
        }

        public async Task<List<ProductsResponse>> GetAll()
        {
            List<Products> products = await _productsRepository.GetAll();

            return products.Select(a => new ProductsResponse
            {
                products_id = a.products_id,
                breed_name = a.breed_name,
                price = a.price,
                weight = a.weight,
                gender = a.gender,
                description = a.description

                //    Books = a.Books.Select(b => new AuthorBookResponse
                //    {
                //        Id = b.Id,
                //        Title = b.Title,
                //        Pages = b.Pages
                //    }).ToList()
                }).ToList();
            }

        public async Task<ProductsResponse> GetById(int products_id)
        {
            Products products = await _productsRepository.GetById(products_id);
            return products == null ? null : new ProductsResponse
            {
                products_id = products.products_id,
                breed_name = products.breed_name,
                price = products.price,
                weight = products.weight,
                gender = products.gender,
                description = products.description,
                //Books = author.Books.Select(b => new AuthorBookResponse
                //{
                //    Id = b.Id,
                //    Title = b.Title,
                //    Pages = b.Pages
                //}).ToList()
            };
        }

        public async Task<ProductsResponse> Update(int products_id, UpdateProducts updateProducts)
        {
            Products products = new Products
            {
                breed_name = updateProducts.breed_name,
                price = updateProducts.price,
                weight = updateProducts.weight,
                gender = updateProducts.gender,
                description = updateProducts.description,
            };

            products = await _productsRepository.Update(products_id, products);

            return products == null ? null : new ProductsResponse
            {
                products_id = products_id,
                breed_name = products.breed_name,
                price = products.price,
                weight = products.weight,
                gender = products.gender,
                description = products.description
            };
        }
    }
}
