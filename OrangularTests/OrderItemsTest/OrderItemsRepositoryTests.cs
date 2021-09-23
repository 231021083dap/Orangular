using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using OrangularAPI.Repositories.order_items;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OrangularTests.OrderItemsTest
{
    public class OrderItemsRepositoryTests
    {
        private readonly OrderItemsRepository _sut;
        private readonly OrangularProjectContext _context;
        private readonly DbContextOptions<OrangularProjectContext> _options;
        public OrderItemsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<OrangularProjectContext>()
                .UseInMemoryDatabase(databaseName: "OrangularOrderItemsDatabase")
                .Options;
            _context = new OrangularProjectContext(_options);
            _sut = new OrderItemsRepository(_context);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetAll Tests
        [Fact]
        public async Task GetAll_ShouldReturnListOfOrderItems_WhenOrderItemsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            _context.Order_Items.Add(new Order_Items
            { 
                order_items_id = 1, 
                price = 1,
                quantity = 1,
                order_list = new Order_Lists { },
                product = new Products { }
            });
            _context.Order_Items.Add(new Order_Items
            {
                order_items_id = 2,
                price = 1,
                quantity = 1,
                order_list = new Order_Lists{},
                product = new Products{}
            });
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Order_Items>>(result);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task GetAll_ShouldReturnEmptyListOfOrderItems_WhenNoOrderItemsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            // Act
            var result = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Order_Items>>(result);
            Assert.Empty(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // ById Tests
        [Fact]
        public async Task GetById_ShouldReturnOrderItem_IfOrderItemExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int orderItemId = 1;
            _context.Order_Items.Add(new Order_Items
            {
                order_items_id = orderItemId,
                price = 1,
                quantity = 1,
                order_list = new Order_Lists { },
                product = new Products { }
            });
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.GetById(orderItemId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_Items>(result);
            Assert.Equal(orderItemId, result.order_items_id);
        }
        [Fact]
        public async Task GetById_ShouldReturnNull_IfOrderItemDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int orderItemId = 1;
            // Act
            var result = await _sut.GetById(orderItemId);
            // Assert
            Assert.Null(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Create Tests
        [Fact]
        public async Task Create_ShouldAddIdToOrderItem_WhenSavingToDatabase()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int expectedId = 1;
            Order_Items orderItem = new Order_Items
            {
                order_items_id = expectedId,
                price = 1,
                quantity = 1,
                order_list = new Order_Lists{},
                product = new Products{}
            };
            // Act
            var result = await _sut.Create(orderItem);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_Items>(result);
            Assert.Equal(expectedId, result.order_items_id);
        }
        [Fact]
        public async Task Create_ShouldFailToAddOrderItem_whenAddingOrderItemWithExistingId()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            Order_Items orderItem = new Order_Items
            {
                order_items_id = 1,
                price = 1,
                quantity = 1,
                order_list = new Order_Lists
                {},
                product = new Products
                {}
            };
            _context.Order_Items.Add(orderItem);
            await _context.SaveChangesAsync();
            // Act
            Func<Task> action = async () => await _sut.Create(orderItem);
            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Update Tests
        [Fact]
        public async Task Update_ShouldChangeValuesOnOrderItems_WhenOrderItemsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int orderItemId = 1;
            Order_Items orderItem = new Order_Items
            {
                order_items_id = orderItemId,
                price = 1,
                quantity = 1,
                order_lists_id = 1,
                products_id = 1
            };
            _context.Order_Items.Add(orderItem);
            await _context.SaveChangesAsync();
            Order_Items updateOrderItem = new Order_Items
            {
                order_items_id = orderItemId,
                price = 2,
                quantity = 2,
                order_lists_id = 2,
                products_id = 2
            };
            // Act
            var result = await _sut.Update(orderItemId, updateOrderItem);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_Items>(result);
            Assert.Equal(orderItemId, result.order_items_id);
            Assert.Equal(updateOrderItem.price, result.price);
            Assert.Equal(updateOrderItem.quantity, result.quantity);
            Assert.Equal(updateOrderItem.order_lists_id, result.order_lists_id);
            Assert.Equal(updateOrderItem.products_id, result.products_id);
        }
        [Fact]
        public async Task Update_ShouldNotChangeValues_WhereNoValuesWasPut()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int orderItemId = 1;
            int orderItemPrice = 1;
            int orderItemQuantity = 1;
            int orderItemOrderListsId = 1;
            int orderItemProductsId = 1;
            Order_Items orderItem = new Order_Items // En eksisterende orderItem i vores database
            {
                order_items_id = orderItemId,
                price = orderItemPrice,
                quantity = orderItemQuantity,
                order_lists_id = orderItemOrderListsId,
                products_id = orderItemProductsId
            };
            _context.Order_Items.Add(orderItem);
            await _context.SaveChangesAsync();
            Order_Items updateOrderItem = new Order_Items // Prøver at opdatere uden at skrive inputs
            {
                order_items_id = orderItemId
                // Når der ingen inputs er, laves et int til 0
            };
            // Act
            var result = await _sut.Update(orderItemId, updateOrderItem); 
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_Items>(result);
            // Et if statement tjkker om den ønskede int opdatering er 0, hvis det er tilfældet skippes opdateringen af int.
            Assert.Equal(orderItemId, result.order_items_id);
            Assert.Equal(orderItemPrice, result.price);
            Assert.Equal(orderItem.quantity, result.quantity);
            Assert.Equal(orderItem.order_lists_id, result.order_lists_id);
            Assert.Equal(orderItem.products_id, result.products_id);
        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenOrderItemDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int orderItemId = 1;
            Order_Items updateOrderItem = new Order_Items{};
            // Act
            var result = await _sut.Update(orderItemId, updateOrderItem);
            // Assert
            Assert.Null(result);
        }
    }
}
