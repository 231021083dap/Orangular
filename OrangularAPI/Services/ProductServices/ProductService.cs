using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Products.Requests;
using OrangularAPI.DTO.Products.Responses;
using OrangularAPI.Repositories.ProductsRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.ProductServices
{


    public class ProductService : IProductService
    {
        private readonly IProductRepository _productsRepository;

        public ProductService(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductResponse> Create(NewProduct newProducts)
        {
            Products products = new Products
            {
                breed_name = newProducts.BreedName,
                price = newProducts.Price,
                weight = newProducts.Weight,
                gender = newProducts.Gender,
                description = newProducts.Description
            };

            products = await _productsRepository.Create(products);

            return products == null ? null : new ProductResponse
            {
                ProductID = products.products_id,
                BreedName = products.breed_name,
                Price = products.price,
                Weight = products.weight,
                Gender = products.gender,
                Description = products.description
            };
        }

        public async Task<bool> Delete(int products_id)
        {
            var result = await _productsRepository.Delete(products_id);
            return (result != null);
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            List<Products> products = await _productsRepository.GetAll();

            return products.Select(a => new ProductResponse
            {
                ProductID = a.products_id,
                BreedName = a.breed_name,
                Price = a.price,
                Weight = a.weight,
                Gender = a.gender,
                Description = a.description

                //    Books = a.Books.Select(b => new AuthorBookResponse
                //    {
                //        Id = b.Id,
                //        Title = b.Title,
                //        Pages = b.Pages
                //    }).ToList()
                }).ToList();
            }

        public async Task<ProductResponse> GetById(int products_id)
        {
            Products products = await _productsRepository.GetById(products_id);
            return products == null ? null : new ProductResponse
            {
                ProductID = products.products_id,
                BreedName = products.breed_name,
                Price = products.price,
                Weight = products.weight,
                Gender = products.gender,
                Description = products.description,
                //Books = author.Books.Select(b => new AuthorBookResponse
                //{
                //    Id = b.Id,
                //    Title = b.Title,
                //    Pages = b.Pages
                //}).ToList()
            };
        }

        public async Task<ProductResponse> Update(int products_id, UpdateProduct updateProducts)
        {
            Products products = new Products
            {
                breed_name = updateProducts.BreedName,
                price = updateProducts.Price,
                weight = updateProducts.Weight,
                gender = updateProducts.Gender,
                description = updateProducts.Description,
            };

            products = await _productsRepository.Update(products_id, products);

            return products == null ? null : new ProductResponse
            {
                ProductID = products_id,
                BreedName = products.breed_name,
                Price = products.price,
                Weight = products.weight,
                Gender = products.gender,
                Description = products.description
            };
        }
    }
}
