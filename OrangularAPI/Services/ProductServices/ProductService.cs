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
                breed_name = newProducts.breedName,
                price = newProducts.price,
                weight = newProducts.weight,
                gender = newProducts.gender,
                description = newProducts.description
            };

            products = await _productsRepository.Create(products);

            return products == null ? null : new ProductResponse
            {
                productID = products.products_id,
                breedName = products.breed_name,
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

        public async Task<List<ProductResponse>> GetAll()
        {
            List<Products> products = await _productsRepository.GetAll();

            return products.Select(a => new ProductResponse
            {
                productID = a.products_id,
                breedName = a.breed_name,
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

        public async Task<ProductResponse> GetById(int products_id)
        {
            Products products = await _productsRepository.GetById(products_id);
            return products == null ? null : new ProductResponse
            {
                productID = products.products_id,
                breedName = products.breed_name,
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

        public async Task<ProductResponse> Update(int products_id, UpdateProduct updateProducts)
        {
            Products products = new Products
            {
                breed_name = updateProducts.breedName,
                price = updateProducts.price,
                weight = updateProducts.weight,
                gender = updateProducts.gender,
                description = updateProducts.description,
            };

            products = await _productsRepository.Update(products_id, products);

            return products == null ? null : new ProductResponse
            {
                productID = products_id,
                breedName = products.breed_name,
                price = products.price,
                weight = products.weight,
                gender = products.gender,
                description = products.description
            };
        }
    }
}
