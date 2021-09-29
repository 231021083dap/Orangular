using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Products.Requests;
using OrangularAPI.DTO.Products.Responses;
using OrangularAPI.Repositories.CategoryRepository;
using OrangularAPI.Repositories.ProductsRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            List<Product> product = await _productRepository.GetAll();
            return product.Select(a => new ProductResponse
            {
                Id = a.Id,
                BreedName = a.BreedName,
                Price = a.Price,
                Weight = a.Weight,
                Gender = a.Gender,
                Description = a.Description,
                Category = new ProductCategoryResponse
                {
                    Category = a.Category.Id,
                    CategoryName = a.Category.CategoryName
                }
            }).ToList();
        }
        public async Task<ProductResponse> GetById(int productId)
        {
            Product product = await _productRepository.GetById(productId);
            return product == null ? null : new ProductResponse
            {
                Id = product.Id,
                BreedName = product.BreedName,
                Price = product.Price,
                Weight = product.Weight,
                Gender = product.Gender,
                Description = product.Description,
                Category = new ProductCategoryResponse
                {
                    Category = product.Category.Id,
                    CategoryName = product.Category.CategoryName
                }
            };
        }
        public async Task<ProductResponse> Create(NewProduct newProduct)
        {
            Product product = new Product
            {
                BreedName = newProduct.BreedName,
                Price = newProduct.Price,
                Weight = newProduct.Weight,
                Gender = newProduct.Gender,
                Description = newProduct.Description,
                CategoryId = newProduct.CategoryId
            };

            product = await _productRepository.Create(product);
            await _categoryRepository.GetById(product.CategoryId);

            return product == null ? null : new ProductResponse
            {
                Id = product.Id,
                BreedName = product.BreedName,
                Price = product.Price,
                Weight = product.Weight,
                Gender = product.Gender,
                Description = product.Description,
                Category = new ProductCategoryResponse
                {
                    Category = product.Category.Id,
                    CategoryName = product.Category.CategoryName
                }

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
                CategoryId = updateProduct.CategoryId
            };

            product = await _productRepository.Update(productId, product);
            if (product == null) return null;
            else
            {
                await _categoryRepository.GetById(product.CategoryId);
                return product == null ? null : new ProductResponse
                {
                    Id = productId,
                    BreedName = product.BreedName,
                    Price = product.Price,
                    Weight = product.Weight,
                    Gender = product.Gender,
                    Description = product.Description,
                    Category = new ProductCategoryResponse
                    {
                        Category = product.Category.Id,
                        CategoryName = product.Category.CategoryName
                    }
                };
            }
        }
        public async Task<bool> Delete(int productId)
        {
            var result = await _productRepository.Delete(productId);
            return (result != null);
        }
    }
}
