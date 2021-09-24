using OrangularAPI.Controllers;
using OrangularAPI.DTO.Products.Responses;
using OrangularAPI.DTO.Products.Requests;

using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OrangularAPI.Services.ProductServices;

namespace OrangularTests.ProductsTests
{
    public class ProductsControllerTests
    {
        private readonly ProductController _sut;
        private readonly Mock<IProductService> _productsService = new();

        public ProductsControllerTests()
        {
            _sut = new ProductController(_productsService.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_whenDataExists()
        {
            // Arrange
            List<ProductResponse> products = new();
            products.Add(new ProductResponse
            {
                productID = 1,
                breedName = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            });
            products.Add(new ProductResponse
            {
                productID = 2,
                breedName = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            });

            _productsService
                .Setup(s => s.GetAll())
                .ReturnsAsync(products);



            // Act
            var result = await _sut.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_whenNoDataExists()
        {
            // Arrange
            List<ProductResponse> Productss = new();

            _productsService
                .Setup(s => s.GetAll())
                .ReturnsAsync(Productss);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_whenNullIsReturnedFromService()
        {
            // Arrange
            _productsService
                .Setup(s => s.GetAll())
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_whenExceptionIsRaised()
        {
            // Arrange
            _productsService
                .Setup(s => s.GetAll())
                .ReturnsAsync(() => throw new Exception("This is an exception"));

            // Act
            var result = await _sut.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            // Arrange
            int products_Id = 1;
            ProductResponse products = new ProductResponse
            {
                productID = products_Id,
                breedName = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(products);

            // Act
            var result = await _sut.GetById(products_Id);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenProductsDoesNotExist()
        {
            // Arrange
            int products_id = 1;

            _productsService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            // Act
            var result = await _sut.GetById(products_id);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            _productsService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.GetById(1);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            // Arrange
            int products_id = 1;
            NewProduct newProducts = new NewProduct
            {
                breedName = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            ProductResponse products = new ProductResponse
            {
                productID = products_id,
                breedName = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.Create(It.IsAny<NewProduct>()))
                .ReturnsAsync(products);

            // Act
            var result = await _sut.Create(newProducts);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            NewProduct NewProducts = new NewProduct
            {
                breedName = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.Create(It.IsAny<NewProduct>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Create(NewProducts);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsSaved()
        {
            // Arrange
            int products_id = 1;
            UpdateProduct updateProducts = new UpdateProduct
            {
                breedName = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            ProductResponse products = new ProductResponse
            {
                productID = products_id,
                breedName = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateProduct>()))
                .ReturnsAsync(products);

            // Act
            var result = await _sut.Update(products_id, updateProducts);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int products_id = 1;
            UpdateProduct updateProducts = new UpdateProduct
            {
                breedName = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateProduct>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Update(products_id, updateProducts);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Delete_ShouldReturnStatusCode204_WhenProductsIsDeleted()
        {
            // Arrange
            int products_id = 1;

            _productsService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            var result = await _sut.Delete(products_id);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int products_id = 1;

            _productsService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Delete(products_id);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
