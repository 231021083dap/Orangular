using Moq;
using Orangular.Database.Entities;
using Orangular.DTO.Products.Requests;
using Orangular.DTO.Products.Responses;
using Orangular.Repositories.products;
using Orangular.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests
{
    public class ProductserviceTests
    {

        private readonly ProductsService _sut;
        private readonly Mock<IProductsRepository> _productsRepository = new();

        public ProductserviceTests()
        {
            _sut = new ProductsService(_productsRepository.Object);
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
            var result = await _sut.GetAllProducts();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<ProductsResponse>>(result);
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
            var result = await _sut.GetAllProducts();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<ProductsResponse>>(result);
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
            Assert.IsType<ProductsResponse>(result);
            Assert.Equal(Products.products_id, result.products_id);
            Assert.Equal(Products.breed_name, result.breed_name);
            Assert.Equal(Products.price, result.price);
            Assert.Equal(Products.weight, result.weight);
            Assert.Equal(Products.gender, result.gender);
            Assert.Equal(Products.description, result.description);

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
            NewProducts newProducts = new NewProducts
            {
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

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
                .Setup(a => a.Create(It.IsAny<Products>()))
                .ReturnsAsync(Products);

            // Act
            var result = await _sut.Create(newProducts);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductsResponse>(result);
            Assert.Equal(Products.products_id, result.products_id);
            Assert.Equal(Products.breed_name, result.breed_name);
            Assert.Equal(Products.price, result.price);
            Assert.Equal(Products.weight, result.weight);
            Assert.Equal(Products.gender, result.gender);
            Assert.Equal(Products.description, result.description);
        }

        [Fact]
        public async void Update_ShouldReturnUpdatedProductsResponse_WhenUpdateIsSuccess()
        {
            // Arrange
            UpdateProducts updateProducts = new UpdateProducts
            {
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            int products_Id = 1;

            ProductsResponse ProductsResponse = new ProductsResponse
            {
                products_id = products_Id,
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            Products Products = new Products
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
            var result = await _sut.Update(products_Id, updateProducts);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductsResponse>(result);
            Assert.Equal(Products.products_id, result.products_id);
            Assert.Equal(Products.breed_name, result.breed_name);
            Assert.Equal(Products.price, result.price);
            Assert.Equal(Products.weight, result.weight);
            Assert.Equal(Products.gender, result.gender);
            Assert.Equal(Products.description, result.description);
        }

        [Fact]
        public async void Update_ShouldReturnNull_WhenProductsDoesNotExist()
        {
            // Arrange
            UpdateProducts updateProducts = new UpdateProducts
            {
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
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

            Products Products = new Products
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
