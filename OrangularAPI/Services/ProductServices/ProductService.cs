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
            Product product = new Product
            {
                BreedName = newProduct.BreedName,
                Price = newProduct.Price,
                Weight = newProduct.Weight,
                Gender = newProduct.Gender,
                Description = newProduct.Description
            };

            product = await _productRepository.Create(product);

            return product == null ? null : new ProductResponse
            {
                ProductId = product.Id,
                BreedName = product.BreedName,
                Price = product.Price,
                Weight = product.Weight,
                Gender = product.Gender,
                Description = product.Description
            };
        }

        public async Task<bool> Delete(int productId)
        {
            var result = await _productRepository.Delete(productId);
            return (result != null);
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            List<Product> product = await _productRepository.GetAll();

            return product.Select(a => new ProductResponse
            {
                ProductId = a.Id,
                BreedName = a.BreedName,
                Price = a.Price,
                Weight = a.Weight,
                Gender = a.Gender,
                Description = a.Description

                //    Books = a.Books.Select(b => new AuthorBookResponse
                //    {
                //        Id = b.Id,
                //        Title = b.Title,
                //        Pages = b.Pages
                //    }).ToList()
                }).ToList();
            }

        public async Task<ProductResponse> GetById(int productId)
        {
            Product product = await _productRepository.GetById(productId);
            return product == null ? null : new ProductResponse
            {
                ProductId = product.Id,
                BreedName = product.BreedName,
                Price = product.Price,
                Weight = product.Weight,
                Gender = product.Gender,
                Description = product.Description,
                //Books = author.Books.Select(b => new AuthorBookResponse
                //{
                //    Id = b.Id,
                //    Title = b.Title,
                //    Pages = b.Pages
                //}).ToList()
            };
        }

        public async Task<ProductResponse> Update(int productId, UpdateProduct updateProduct)
        {
            Product product = new Product
            {
                BreedName = updateProduct.BreedName,
                Price = updateProduct.Price,
                Weight = updateProduct.Weight,
                Gender = updateProduct.Gender,
                Description = updateProduct.Description,
            };

            product = await _productRepository.Update(productId, product);

            return product == null ? null : new ProductResponse
            {
                ProductId = productId,
                BreedName = product.BreedName,
                Price = product.Price,
                Weight = product.Weight,
                Gender = product.Gender,
                Description = product.Description
            };
        }
    }
}
