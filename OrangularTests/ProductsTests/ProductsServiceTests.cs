using System.Collections.Generic;
using Moq;
using Xunit;
// Orangular
using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Products.Requests;
using OrangularAPI.DTO.Products.Responses;
using OrangularAPI.Services;
using OrangularAPI.Services.ProductServices;
using OrangularAPI.Repositories.ProductsRepository;
// Orangular

namespace OrangularTests.ProductsTests
{
    public class ProductserviceTests
    {

        private readonly ProductService _sut;
        private readonly Mock<IProductRepository> _productsRepository = new();

        public ProductserviceTests()
        {
            _sut = new ProductService(_productsRepository.Object);
        }
        [Fact]
        public async void GetAll_ShouldReturnListOfProductsResponses_WhenProductsExist()
        {
            // Arrange
            List<Products> Products = new();
            Products.Add(new Products
            {
                products_id = 1,
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            });

            Products.Add(new Products
            {
                products_id = 2,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
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
            List<Products> Products = new();

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
            int products_Id = 1;

            Products Products = new Products
            {
                products_id = products_Id,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsRepository
                .Setup(a => a.GetById(It.IsAny<int>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.GetById(products_Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(Products.products_id, result.ProductID);
            Assert.Equal(Products.breed_name, result.BreedName);
            Assert.Equal(Products.price, result.Price);
            Assert.Equal(Products.weight, result.Weight);
            Assert.Equal(Products.gender, result.Gender);
            Assert.Equal(Products.description, result.Description);

        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenProductsDoesNotExist()
        {
            // Arrange
            int products_Id = 1;

            _productsRepository
                .Setup(a => a.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetById(products_Id);

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

            int products_Id = 1;

            Products Products = new()
            {
                products_id = products_Id,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsRepository
                .Setup(a => a.Create(It.IsAny<Products>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.Create(newProduct);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(Products.products_id, result.ProductID);
            Assert.Equal(Products.breed_name, result.BreedName);
            Assert.Equal(Products.price, result.Price);
            Assert.Equal(Products.weight, result.Weight);
            Assert.Equal(Products.gender, result.Gender);
            Assert.Equal(Products.description, result.Description);
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

            int products_Id = 1;

            ProductResponse ProductResponse = new ProductResponse
            {
                ProductID = products_Id,
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test"
            };

            Products Products = new()
            {
                products_id = products_Id,
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            _productsRepository
                .Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Products>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.Update(products_Id, updateProduct);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(Products.products_id, result.ProductID);
            Assert.Equal(Products.breed_name, result.BreedName);
            Assert.Equal(Products.price, result.Price);
            Assert.Equal(Products.weight, result.Weight);
            Assert.Equal(Products.gender, result.Gender);
            Assert.Equal(Products.description, result.Description);
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
                Description = "Test test"
            };

            int products_Id = 1;

            _productsRepository
                .Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Products>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.Update(products_Id, updateProducts);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccess()
        {
            // Arrange
            int products_Id = 1;

            Products Products = new()
            {
                products_id = products_Id,
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            _productsRepository
                .Setup(a => a.Delete(It.IsAny<int>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.Delete(products_Id);

            // Assert
            Assert.True(result);
        }
    }
}
