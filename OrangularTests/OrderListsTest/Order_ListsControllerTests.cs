﻿using OrangularAPI.Controllers;
using OrangularAPI.DTO.OrderLists.Requests;
using OrangularAPI.DTO.OrderLists.Responses;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using OrangularAPI.Services.OrderListServices;

namespace OrangularTests.OrderListsTest
{
    public class OrderListControllerTests
    {
        private readonly OrderListController _sut;
        private readonly Mock<IOrderListService> _order_ListsService = new();

        public OrderListControllerTests()
        {
            _sut = new OrderListController(_order_ListsService.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_whenDataExists()
        {
            // Arrange
            List<OrderListResponse> order_Lists = new();
            order_Lists.Add(new OrderListResponse
            {
                orderListID = 1,
                orderDateTime = DateTime.Parse("2021-12-21 12:55:00")

            });
            order_Lists.Add(new OrderListResponse
            {
                orderListID = 2,
                orderDateTime = DateTime.Parse("2021-12-21 12:55:00")

            });

            _order_ListsService
                .Setup(s => s.GetAll())
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
            List<OrderListResponse> order_Listss = new();

            _order_ListsService
                .Setup(s => s.GetAll())
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
            _order_ListsService
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
            int order_lists_id = 1;
            OrderListResponse order_Lists = new OrderListResponse
            {
                orderListID = order_lists_id,
                orderDateTime = DateTime.Parse("2021-12-21 12:55:00")
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
            NewOrderList NewOrder_Lists = new NewOrderList
            {
                OrderDateTime = DateTime.Parse("2021-12-21 12:55:00")
            };

            OrderListResponse order_Lists = new OrderListResponse
            {
                orderListID = order_lists_id,
                orderDateTime = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.Create(It.IsAny<NewOrderList>()))
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
            NewOrderList NewOrder_Lists = new NewOrderList
            {
                OrderDateTime = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.Create(It.IsAny<NewOrderList>()))
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
            UpdateOrderList updateorder_Lists = new UpdateOrderList
            {
                OrderDateTime = DateTime.Parse("2021-12-21 12:55:00")
            };

            OrderListResponse order_Lists = new OrderListResponse
            {
                orderListID = order_lists_id,
                orderDateTime = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrderList>()))
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
            UpdateOrderList updateorder_Lists = new UpdateOrderList
            {
                OrderDateTime = DateTime.Parse("2021-12-21 12:55:00")
            };

            _order_ListsService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrderList>()))
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