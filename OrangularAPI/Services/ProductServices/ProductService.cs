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
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Create(NewProduct newProduct)
        {
            Products product = new Products
            {
                breed_name = newProduct.BreedName,
                price = newProduct.Price,
                weight = newProduct.Weight,
                gender = newProduct.Gender,
                description = newProduct.Description
            };

            product = await _productRepository.Create(product);

            return product == null ? null : new ProductResponse
            {
                ProductId = product.products_id,
                BreedName = product.breed_name,
                Price = product.price,
                Weight = product.weight,
                Gender = product.gender,
                Description = product.description
            };
        }

        public async Task<bool> Delete(int products_id)
        {
            var result = await _productRepository.Delete(products_id);
            return (result != null);
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            List<Products> products = await _productRepository.GetAll();

            return products.Select(a => new ProductResponse
            {
                ProductId = a.products_id,
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
            Products entityProduct = await _productRepository.GetById(products_id);
            return entityProduct == null ? null : new ProductResponse
            {
                ProductId = entityProduct.products_id,
                BreedName = entityProduct.breed_name,
                Price = entityProduct.price,
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
