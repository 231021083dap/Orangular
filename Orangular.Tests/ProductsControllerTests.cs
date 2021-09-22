using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Orangular.Controllers;
using Orangular.Services.products;
using Orangular.DTO.Products.Responses;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Orangular.DTO.Products.Requests;

namespace Orangular.Tests
{
    public class ProductsControllerTests
    {
        private readonly ProductsController _sut;
        private readonly Mock<IProductsService> _productsService = new();

        public ProductsControllerTests()
        {
            _sut = new ProductsController(_productsService.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_whenDataExists()
        {
            // Arrange
            List<ProductsResponse> products = new();
            products.Add(new ProductsResponse
            {
                products_id = 1,
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            });
            products.Add(new ProductsResponse
            {
                products_id = 2,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            });

            _productsService
                .Setup(s => s.GetAllProducts())
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
            List<ProductsResponse> Productss = new();

            _productsService
                .Setup(s => s.GetAllProducts())
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
                .Setup(s => s.GetAllProducts())
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
                .Setup(s => s.GetAllProducts())
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
            ProductsResponse products = new ProductsResponse
            {
                products_id = products_Id,
                breed_name = "Cane Corso",
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
            NewProducts newProducts = new NewProducts
            {
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            ProductsResponse products = new ProductsResponse
            {
                products_id = products_id,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.Create(It.IsAny<NewProducts>()))
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
            NewProducts NewProducts = new NewProducts
            {
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.Create(It.IsAny<NewProducts>()))
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
            UpdateProducts updateProducts = new UpdateProducts
            {
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            ProductsResponse products = new ProductsResponse
            {
                products_id = products_id,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateProducts>()))
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
            UpdateProducts updateProducts = new UpdateProducts
            {
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            _productsService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateProducts>()))
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
