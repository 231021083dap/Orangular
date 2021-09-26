﻿//using Moq;
//using Orangular.Database.Entities;
//using Orangular.DTO.Order_Lists.Requests;
//using Orangular.DTO.Order_Lists.Responses;
//using Orangular.Repositories.order_lists;
//using Orangular.Services.Order_List;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace OrangularTests.OrderListsTest
//{

//    public class OrderListServiceTest
//    {
//        public class Order_ListserviceTests
//        {

//            private readonly Order_ListsService _sut;
//            private readonly Mock<IOrder_ListsRepository> _order_ListsRepository = new();

//            public Order_ListserviceTests()
//            {
//                _sut = new Order_ListsService(_order_ListsRepository.Object);
//            }
//            [Fact]
//            public async void GetAll_ShouldReturnListOfOrder_ListsResponses_WhenOrder_ListsExist()
//            {
//                // Arrange
//                List<Order_Lists> order_Lists = new();
//                order_Lists.Add(new Order_Lists
//                {
//                    OrderListId = 1,
//                    order_date_time = DateTime.Parse("2021-12-21 12:55:00")

//                });

//                order_Lists.Add(new Order_Lists
//                {
//                    OrderListId = 2,
//                    order_date_time = DateTime.Parse("2021-12-23 12:55:00")
//                });

//                _order_ListsRepository
//                    .Setup(a => a.GetAll())
//                    .ReturnsAsync(order_Lists);

//                // Act
//                var result = await _sut.GetAllOrder_Lists();

//                // Assert
//                Assert.NotNull(result);
//                Assert.Equal(2, result.Count);
//                Assert.IsType<List<Order_ListsResponse>>(result);
//            }

//            [Fact]
//            public async void GetAll_ShouldReturnEmptyListOfOrder_ListsResponses_WhenNoOrder_ListsExists()
//            {
//                // Arrange
//                List<Order_Lists> Order_Lists = new();

//                _order_ListsRepository
//                    .Setup(a => a.GetAll())
//                    .ReturnsAsync(Order_Lists);

//                // Act
//                var result = await _sut.GetAllOrder_Lists();

//                // Assert
//                Assert.NotNull(result);
//                Assert.Empty(result);
//                Assert.IsType<List<Order_ListsResponse>>(result);
//            }

//            [Fact]
//            public async void GetById_ShouldReturnAnOrder_ListsResponse_WhenOrder_ListsExists()
//            {
//                // Arrange
//                int OrderListId = 1;

//                Order_Lists Order_Lists = new Order_Lists
//                {
//                    OrderListId = OrderListId,
//                    order_date_time = DateTime.Parse("2020-12-21 12:57:00")
//                };

//                _order_ListsRepository
//                    .Setup(a => a.GetById(It.IsAny<int>()))
//                    .ReturnsAsync(Order_Lists);

//                // Act
//                var result = await _sut.GetById(OrderListId);

//                // Assert
//                Assert.NotNull(result);
//                Assert.IsType<Order_ListsResponse>(result);
//                Assert.Equal(Order_Lists.OrderListId, result.OrderListId);
//                Assert.Equal(Order_Lists.order_date_time, result.order_date_time);


//            }

//            [Fact]
//            public async void GetById_ShouldReturnNull_WhenOrder_ListsDoesNotExist()
//            {
//                // Arrange
//                int OrderListId = 1;

//                _order_ListsRepository
//                    .Setup(a => a.GetById(It.IsAny<int>()))
//                    .ReturnsAsync(() => null);

//                // Act
//                var result = await _sut.GetById(OrderListId);

//                // Assert
//                Assert.Null(result);
//            }

//            [Fact]
//            public async void Create_ShouldReturnOrder_ListsResponse_WhenCreateIsSuccess()
//            {
//                // Arrange
//                NewOrder_Lists newOrder_Lists = new NewOrder_Lists
//                {
//                    order_date_time = DateTime.Parse("2020-12-21 12:57:00")
//                };

//                int OrderListId = 1;

//                Order_Lists Order_Lists = new Order_Lists
//                {
//                    OrderListId = OrderListId,
//                    order_date_time = DateTime.Parse("2020-12-21 12:57:00")
//                };

//                _order_ListsRepository
//                    .Setup(a => a.Create(It.IsAny<Order_Lists>()))
//                    .ReturnsAsync(Order_Lists);

//                // Act
//                var result = await _sut.Create(newOrder_Lists);

//                // Assert
//                Assert.NotNull(result);
//                Assert.IsType<Order_ListsResponse>(result);
//                Assert.Equal(Order_Lists.OrderListId, result.OrderListId);
//                Assert.Equal(Order_Lists.order_date_time, result.order_date_time);

//            }

//            [Fact]
//            public async void Update_ShouldReturnUpdatedOrder_ListsResponse_WhenUpdateIsSuccess()
//            {
//                // Arrange
//                UpdateOrder_Lists updateOrder_Lists = new UpdateOrder_Lists
//                {
//                    order_date_time = DateTime.Parse("2020-12-21 12:57:00")
//                };

//                int OrderListId = 1;

//                Order_ListsResponse Order_ListsResponse = new Order_ListsResponse
//                {
//                    OrderListId = OrderListId,
//                    order_date_time = DateTime.Parse("2020-12-21 12:57:00")
//                };

//                Order_Lists Order_Lists = new Order_Lists
//                {
//                    OrderListId = OrderListId,
//                    order_date_time = DateTime.Parse("2020-12-21 12:57:00")
//                };

//                _order_ListsRepository
//                    .Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Order_Lists>()))
//                    .ReturnsAsync(Order_Lists);

//                // Act
//                var result = await _sut.Update(OrderListId, updateOrder_Lists);

//                // Assert
//                Assert.NotNull(result);
//                Assert.IsType<Order_ListsResponse>(result);
//                Assert.Equal(Order_Lists.OrderListId, result.OrderListId);
//                Assert.Equal(Order_Lists.order_date_time, result.order_date_time);

//            }

//            [Fact]
//            public async void Update_ShouldReturnNull_WhenOrder_ListsDoesNotExist()
//            {
//                // Arrange
//                UpdateOrder_Lists updateOrder_Lists = new UpdateOrder_Lists
//                {
//                    order_date_time = DateTime.Parse("2020-12-21 12:57:00")
//                };

//                int OrderListId = 1;

//                _order_ListsRepository
//                    .Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Order_Lists>()))
//                    .ReturnsAsync(() => null);

//                // Act
//                var result = await _sut.Update(OrderListId, updateOrder_Lists);

//                // Assert
//                Assert.Null(result);
//            }

//            [Fact]
//            public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccess()
//            {
//                // Arrange
//                int OrderListId = 1;

//                Order_Lists Order_Lists = new Order_Lists
//                {
//                    OrderListId = OrderListId,
//                    order_date_time = DateTime.Parse("2020-12-21 12:57:00")
//                };

//                _order_ListsRepository
//                    .Setup(a => a.Delete(It.IsAny<int>()))
//                    .ReturnsAsync(Order_Lists);

//                // Act
//                var result = await _sut.Delete(OrderListId);

//                // Assert
//                Assert.True(result);
//            }
//        }
//    }
//}
