using Moq;
using Orangular.Database.Entities;
using Orangular.DTO.Order_Items.Requests;
using Orangular.DTO.Order_Items.Responses;
using Orangular.Repositories.order_items;
using Orangular.Repositories.order_lists;
using Orangular.Repositories.products;
using Orangular.Services.order_items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrangularTests.OrderItemsTest
{
    public class OrderItemsServiceTests
    {
        private readonly OrderItemService _sut;
        private readonly Mock<IOrderItemRepository> _orderItemsRepository = new();
        private readonly Mock<IOrder_ListsRepository> _order_ListsRepository = new();
        private readonly Mock<IProductsRepository> _productsRepository = new();
        public OrderItemsServiceTests()
        {
            _sut = new OrderItemService(_orderItemsRepository.Object, _order_ListsRepository.Object, _productsRepository.Object);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetAll Tests
        [Fact]
        public async void GetAll_ShouldReturnListofOrderItems_WhenOrderItemsExists()
        {
            // Arrange
            List<Order_Items> orderItem = new();
            orderItem.Add(new Order_Items
            {
                order_items_id = 1,
                price = 1,
                quantity = 1,
                order_lists_id = 1,
                order_list = new Order_Lists
                {
                    order_lists_id = 1,
                    order_date_time = DateTime.Now
                },
                products_id = 1,
                product = new Products
                {
                    products_id = 1,
                    breed_name = "Corgi",
                    price = 1,
                    weight = 1,
                    gender = "F",
                    description = "test123"
                }
            });
            orderItem.Add(new Order_Items
            {
                order_items_id = 2,
                price = 1,
                quantity = 1,
                order_lists_id = 2,
                order_list = new Order_Lists
                {
                    order_lists_id = 2,
                    order_date_time = DateTime.Now
                },
                products_id = 2,
                product = new Products
                {
                    products_id = 2,
                    breed_name = "Corgi",
                    price = 1,
                    weight = 1,
                    gender = "F",
                    description = "test123"
                }
            });
            _orderItemsRepository.Setup(a => a.GetAll()).ReturnsAsync(orderItem);
            // Act
            var result = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<Order_ItemsResponse>>(result);
        }
        [Fact]
        public async Task GetAll_ShouldReturnEmptyListOfOrderItemsResponse_WhenNoOrderItemsExists()
        {
            // Arrange
            List<Order_Items> orderItems = new();
            _orderItemsRepository.Setup(a => a.GetAll()).ReturnsAsync(orderItems);
            // Act
            var result = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<Order_ItemsResponse>>(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetById Tests
        [Fact]
        public async Task GetById_ShouldReturnOrderItemsResponse_WhenOrderItemExists()
        {
            // Arrange
            int orderItemId = 1;
            Order_Items orderItem = new Order_Items
            {
                order_items_id = orderItemId,
                price = 1,
                quantity = 1,
                order_lists_id = 1,
                order_list = new Order_Lists
                {
                    order_lists_id = 1,
                    order_date_time = DateTime.Now
                },
                products_id = 1,
                product = new Products
                {
                    products_id = 1,
                    breed_name = "Corgi",
                    price = 1,
                    weight = 1,
                    gender = "F",
                    description = "test123"
                }
            };
            _orderItemsRepository.Setup(a => a.GetById(It.IsAny<int>())).ReturnsAsync(orderItem);
            // Act
            var result = await _sut.GetById(orderItemId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_ItemsResponse>(result);
            Assert.Equal(orderItem.order_items_id, result.order_items_id);
            Assert.Equal(orderItem.order_lists_id, result.Order_Lists.order_lists_id);
            Assert.Equal(orderItem.products_id, result.Products.products_id);
        }
        [Fact]
        public async Task GetById_ShouldReturnNull_WhenOrderItemDoesNotExist()
        {
            // Arrange
            int orderItemId = 1;
            _orderItemsRepository.Setup(a => a.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.GetById(orderItemId);
            // Assert
            Assert.Null(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Create Tests
        [Fact]
        public async Task Create_ShouldReturnOrderItemResponse_WhenCreateIsSuccess()
        {
            // Arrange
            NewOrder_Items newOrderItem = new NewOrder_Items
            {
                price = 1,
                quantity = 1,
                order_lists_id = 1,
                products_id = 1
            };
            int orderItemId = 1;
            Order_Items orderItem = new Order_Items
            {
                order_items_id = orderItemId,
                price = 1,
                quantity = 1,
                order_list = new Order_Lists
                {
                    order_lists_id = 1,
                    order_date_time = DateTime.Now
                },
                product = new Products
                {
                    products_id = 1,
                    breed_name = "vovse",
                    price = 1,
                    weight = 1,
                    gender = "F",
                    description = "Test123"
                }
            };
            _orderItemsRepository.Setup(a => a.Create(It.IsAny<Order_Items>())).ReturnsAsync(orderItem);
            // Act
            var result = await _sut.Create(newOrderItem);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_ItemsResponse>(result);
            Assert.Equal(orderItemId, result.order_items_id);
            Assert.Equal(newOrderItem.price, result.price);
            Assert.Equal(newOrderItem.quantity, result.quantity);
            Assert.Equal(newOrderItem.order_lists_id, result.Order_Lists.order_lists_id);
            Assert.Equal(newOrderItem.products_id, result.Products.products_id);
        }
        [Fact]
        public async Task Create_ShouldReturnNull_WhenCreatedOrderItemIsNull()
        {
            // Arrange
            NewOrder_Items newOrderItem = new NewOrder_Items
            {
                price = 1,
                quantity = 1,
                order_lists_id = 1,
                products_id = 1
            };
            _orderItemsRepository.Setup(a => a.Create(It.IsAny<Order_Items>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.Create(newOrderItem);
            // Assert
            Assert.Null(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Create Tests
        [Fact]
        public async void Update_ShouldReturnUpdatedOrderItemResponse_WhenUpdateIsSuccess()
        {
            // Arrange
            int orderItemId = 1;
            UpdateOrder_Items updateOrderItem = new UpdateOrder_Items
            {
                price = 1,
                quantity = 1,
                order_lists_id = 1,
                products_id = 1
            };
            Order_Items orderItem = new Order_Items
            {
                order_items_id = 1,
                price = 1,
                quantity = 1,
                order_list = new Order_Lists
                {
                    order_lists_id = 1,
                    order_date_time = DateTime.Now
                },
                product = new Products
                {
                    products_id = 1,
                    breed_name = "vovse",
                    price = 1,
                    weight = 1,
                    gender = "F",
                    description = "Test123"
                }
            };
            _orderItemsRepository.Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Order_Items>())).ReturnsAsync(orderItem);
            // Act
            var result = await _sut.Update(orderItemId, updateOrderItem);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_ItemsResponse>(result);
            Assert.Equal(orderItemId, result.order_items_id); 
            Assert.Equal(updateOrderItem.price, result.price);
            Assert.Equal(updateOrderItem.quantity, result.quantity);
            Assert.Equal(updateOrderItem.order_lists_id, result.Order_Lists.order_lists_id);
            Assert.Equal(updateOrderItem.products_id, result.Order_Lists.order_lists_id);
        }
        [Fact]
        public async void Update_ShouldReturnNull_WhenOrderItemDoesNotExist()
        {
            int orderItemId = 1;
            // Arrange
            UpdateOrder_Items updateOrderItem = new UpdateOrder_Items
            {
                price = 1,
                quantity = 1,
                order_lists_id = 1,
                products_id = 1
            };
            _orderItemsRepository.Setup(a => a.Update(It.IsAny<int>(), It.IsAny<Order_Items>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.Update(orderItemId, updateOrderItem);
            // Assert
            Assert.Null(result);
        }
    }
}


