using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Orangular.Controllers;
using Orangular.DTO.Order_Items.Requests;
using Orangular.DTO.Order_Items.Responses;
using Orangular.Services.order_items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.OrderItemsTest
{
   public class OrderItemsControllerTests
    {
        private readonly Order_ItemsController _sut;
        private readonly Mock<IOrderItemService> _orderItemService = new();
        public OrderItemsControllerTests()
        {
            _sut = new Order_ItemsController(_orderItemService.Object);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetAll Tests
        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenDataExists()
        {
            // arrange
            List<Order_ItemsResponse> orderItem = new();
            orderItem.Add(new Order_ItemsResponse
            {
                order_items_id = 1,
                price = 1, 
                quantity = 1,
                Order_Lists = new Order_ItemsOrder_ListsResponse { },
                Products = new Order_ItemsProductsResponse { }
            });
            _orderItemService.Setup(s => s.GetAll()).ReturnsAsync(orderItem);
            // act
            var result = await _sut.GetAll();
            // assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoDataExists()
        {
            // Arrange 
            List<Order_ItemsResponse> orderItem = new();
            _orderItemService.Setup(s => s.GetAll()).ReturnsAsync(orderItem);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            // Arrange 
            List<Order_ItemsResponse> book = new();
            _orderItemService.Setup(s => s.GetAll()).ReturnsAsync(() => null);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetById Tests
        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            // Arrange
            int orderItemId = 1;
            Order_ItemsResponse orderItem = new Order_ItemsResponse
            {
                Order_Lists = new Order_ItemsOrder_ListsResponse{},
                Products = new Order_ItemsProductsResponse { }
            };
            _orderItemService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(orderItem);
            // Act
            var result = await _sut.GetById(orderItemId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenOrderItemDoesNotExist()
        {
            // Arrange
            int orderItemId = 1;
            _orderItemService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.GetById(orderItemId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExeptionIsRaised()
        {
            // Arrange
            _orderItemService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(() => throw new Exception("This is an exception"));
            // Act
            var result = await _sut.GetById(1);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Create Tests
        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            // Arrange
            NewOrder_Items newOrderItem = new NewOrder_Items
            {
                price = 1 ,
                quantity = 1,
                order_lists_id = 1,
                products_id = 1 
            };
            Order_ItemsResponse orderItem = new Order_ItemsResponse
            {
                order_items_id = 1,
                price = 1,
                quantity = 1,
                Order_Lists = new Order_ItemsOrder_ListsResponse
                {
                },
                Products = new Order_ItemsProductsResponse
                {
                }
            };
            _orderItemService.Setup(s => s.Create(It.IsAny<NewOrder_Items>())).ReturnsAsync(orderItem);
            // Act
            var result = await _sut.Create(newOrderItem);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            NewOrder_Items newOrderItem = new NewOrder_Items
            {
                price = 1,
                quantity = 1,
                order_lists_id = 1,
                products_id = 1
            };
            _orderItemService.Setup(s => s.Create(It.IsAny<NewOrder_Items>())).ReturnsAsync(() => throw new Exception("This is an exception :)"));
            // Act
            var result = await _sut.Create(newOrderItem);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Update Tests
        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsSaved()
        {
            // Arrange
            int orderItemId = 1;
            UpdateOrder_Items updateOrderItem = new UpdateOrder_Items
            {
            };
            Order_ItemsResponse orderItem = new Order_ItemsResponse
            {
                Order_Lists = new Order_ItemsOrder_ListsResponse{},
                Products = new Order_ItemsProductsResponse{}
            };
            _orderItemService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrder_Items>())).ReturnsAsync(orderItem);
            // Acts
            var result = await _sut.Update(orderItemId, updateOrderItem);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int orderItemId = 1;
            UpdateOrder_Items updateOrderItem = new UpdateOrder_Items
            {
            };
            Order_ItemsResponse orderItem = new Order_ItemsResponse
            {
                Order_Lists = new Order_ItemsOrder_ListsResponse { },
                Products = new Order_ItemsProductsResponse { }
            };
            _orderItemService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateOrder_Items>())).ReturnsAsync(() => throw new Exception("This is an exception :)"));
            // Acts
            var result = await _sut.Update(orderItemId, updateOrderItem);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
