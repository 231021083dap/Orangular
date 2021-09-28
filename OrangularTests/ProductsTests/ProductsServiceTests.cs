using System.Collections.Generic;
using Moq;
using Xunit;
// Orangular
using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Products.Requests;
using OrangularAPI.DTO.Products.Responses;
using OrangularAPI.Services.ProductServices;
using OrangularAPI.Repositories.ProductsRepository;
using OrangularAPI.Repositories.CategoryRepository;
// Orangular

namespace OrangularTests.ProductsTests
{
    public class ProductServiceTests
    {

        private readonly ProductService _sut;
        private readonly Mock<IProductRepository> _productsRepository = new();
        private readonly Mock<ICategoryRepository> _categoryRepository = new();

        public ProductServiceTests()
        {
            _sut = new ProductService(_productsRepository.Object, _categoryRepository.Object);
        }
        [Fact]
        public async void GetAll_ShouldReturnListOfProductsResponses_WhenProductsExist()
        {
            // Arrange
            List<Product> Products = new();
            Products.Add(new Product
            {
                Id = 1,
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test",
                Category = new()
            });

            Products.Add(new Product
            {
                Id = 2,
                BreedName = "Beetle",
                Price = 1000,
                Weight = 10000,
                Gender = "Male",
                Description = "Test test",
                Category = new()

            });

            _productsRepository
                .Setup(a => a.GetAll())
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<ProductResponse>>(result);
        }

        [Fact]
        public async void GetAll_ShouldReturnEmptyListOfProductsResponses_WhenNoProductsExists()
        {
            // Arrange
            List<Product> Products = new();

            _productsRepository
                .Setup(a => a.GetAll())
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<ProductResponse>>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnAnProductsResponse_WhenProductsExists()
        {
            // Arrange
            int ProductId = 1;

            Product Products = new Product
            {
                Id = ProductId,
                BreedName = "Beetle",
                Price = 1000,
                Weight = 10000,
                Gender = "Male",
                Description = "Test test",
                Category = new()
            };

            _productsRepository
                .Setup(a => a.GetById(It.IsAny<int>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.GetById(ProductId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(Products.Id, result.ProductId);
            Assert.Equal(Products.BreedName, result.BreedName);
            Assert.Equal(Products.Price, result.Price);
            Assert.Equal(Products.Weight, result.Weight);
            Assert.Equal(Products.Gender, result.Gender);
            Assert.Equal(Products.Description, result.Description);

        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenProductsDoesNotExist()
        {
            // Arrange
            int ProductId = 1;

            _productsRepository
                .Setup(a => a.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetById(ProductId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void Create_ShouldReturnProductsResponse_WhenCreateIsSuccess()
        {
            // Arrange
            NewProduct newProduct = new NewProduct
            {
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test"
            };

            int ProductId = 1;

            Product Products = new()
            {
                Id = ProductId,
                BreedName = "Beetle",
                Price = 1000,
                Weight = 10000,
                Gender = "Male",
                Description = "Test test",
                Category = new()
                
            };

            _productsRepository
                .Setup(a => a.Create(It.IsAny<Product>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.Create(newProduct);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(Products.Id, result.ProductId);
            Assert.Equal(Products.BreedName, result.BreedName);
            Assert.Equal(Products.Price, result.Price);
            Assert.Equal(Products.Weight, result.Weight);
            Assert.Equal(Products.Gender, result.Gender);
            Assert.Equal(Products.Description, result.Description);
        }

        [Fact]
        public async void Update_ShouldReturnUpdatedProductsResponse_WhenUpdateIsSuccess()
        {
            // Arrange
            UpdateProduct updateProduct = new UpdateProduct
            {
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test"
            };

            int ProductId = 1;

            ProductResponse ProductResponse = new ProductResponse
            {
                ProductId = ProductId,
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test",
            };

            Product Products = new()
            {
                Id = ProductId,
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test",
                Category = new()
            };

            _productsRepository
                .Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Product>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.Update(ProductId, updateProduct);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(Products.Id, result.ProductId);
            Assert.Equal(Products.BreedName, result.BreedName);
            Assert.Equal(Products.Price, result.Price);
            Assert.Equal(Products.Weight, result.Weight);
            Assert.Equal(Products.Gender, result.Gender);
            Assert.Equal(Products.Description, result.Description);
        }

        [Fact]
        public async void Update_ShouldReturnNull_WhenProductsDoesNotExist()
        {
            // Arrange
            UpdateProduct updateProducts = new UpdateProduct
            {
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test",
                CategoryId = 1
            };

            int ProductId = 1;

            _productsRepository
                .Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Product>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.Update(ProductId, updateProducts);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccess()
        {
            // Arrange
            int ProductId = 1;

            Product Products = new()
            {
                Id = ProductId,
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test"
            };

            _productsRepository
                .Setup(a => a.Delete(It.IsAny<int>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.Delete(ProductId);

            // Assert
            Assert.True(result);
        }
    }
}
