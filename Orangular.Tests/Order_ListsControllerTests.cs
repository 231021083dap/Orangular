using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Orangular.Controllers;
using Orangular.DTO.Order_Lists.Requests;
using Orangular.DTO.Order_Lists.Responses;
using Orangular.Services.Order_List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests
{
    public class Order_ListsControllerTests
    {
        private readonly Order_ListsController _sut;
        private readonly Mock<IOrder_ListsService> _order_ListsService = new();

        public Order_ListsControllerTests()
        {
            _sut = new Order_ListsController(_order_ListsService.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_whenDataExists()
        {
            // Arrange
            List<Order_ListsResponse> order_Lists = new();
            order_Lists.Add(new Order_ListsResponse
            {
                order_lists_id = 1,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")

            });
            order_Lists.Add(new Order_ListsResponse
            {
                order_lists_id = 2,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")

            });

            _order_ListsService
                .Setup(s => s.GetAllOrder_Lists())
                .ReturnsAsync(order_Lists);



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
            List<Order_ListsResponse> order_Listss = new();

            _order_ListsService
                .Setup(s => s.GetAllOrder_Lists())
                .ReturnsAsync(order_Listss);

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
            _order_ListsService
                .Setup(s => s.GetAllOrder_Lists())
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
            _order_ListsService
                .Setup(s => s.GetAllOrder_Lists())
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
            int order_lists_id = 1;
            Order_ListsResponse order_Lists = new Order_ListsResponse
            {
                order_lists_id = order_lists_id,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(order_Lists);

            // Act
            var result = await _sut.GetById(order_lists_id);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode404_Whenorder_ListsDoesNotExist()
        {
            // Arrange
            int order_lists_id = 1;

            _order_ListsService
                .Setup(s => s.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            // Act
            var result = await _sut.GetById(order_lists_id);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            _order_ListsService
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
            int order_lists_id = 1;
            NewOrder_Lists NewOrder_Lists = new NewOrder_Lists
            {
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            Order_ListsResponse order_Lists = new Order_ListsResponse
            {
                order_lists_id = order_lists_id,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.Create(It.IsAny<NewOrder_Lists>()))
                .ReturnsAsync(order_Lists);

            // Act
            var result = await _sut.Create(NewOrder_Lists);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            NewOrder_Lists NewOrder_Lists = new NewOrder_Lists
            {
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.Create(It.IsAny<NewOrder_Lists>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Create(NewOrder_Lists);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsSaved()
        {
            // Arrange
            int order_lists_id = 1;
            UpdateOrder_Lists updateorder_Lists = new UpdateOrder_Lists
            {
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            Order_ListsResponse order_Lists = new Order_ListsResponse
            {
                order_lists_id = order_lists_id,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrder_Lists>()))
                .ReturnsAsync(order_Lists);

            // Act
            var result = await _sut.Update(order_lists_id, updateorder_Lists);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int order_lists_id = 1;
            UpdateOrder_Lists updateorder_Lists = new UpdateOrder_Lists
            {
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrder_Lists>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Update(order_lists_id, updateorder_Lists);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Delete_ShouldReturnStatusCode204_Whenorder_ListsIsDeleted()
        {
            // Arrange
            int order_lists_id = 1;

            _order_ListsService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            var result = await _sut.Delete(order_lists_id);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int order_lists_id = 1;

            _order_ListsService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Delete(order_lists_id);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
