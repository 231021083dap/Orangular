using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using OrangularAPI.Repositories.order_lists;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OrangularTests.OrderListsTest
{
    public class Order_ListsRepositoryTests
    {
        private readonly Order_ListsRepository _sut;
        private readonly OrangularProjectContext _context;
        private readonly DbContextOptions<OrangularProjectContext> _options;

        public Order_ListsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<OrangularProjectContext>()
                .UseInMemoryDatabase(databaseName: "OrangularProject")
                .Options;

            _context = new OrangularProjectContext(_options);

            _sut = new Order_ListsRepository(_context);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfOrder_Lists_WhenOrder_ListsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            _context.Order_Lists.Add(new Order_Lists
            {
                order_lists_id = 1,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")

            });
            _context.Order_Lists.Add(new Order_Lists
            {
                order_lists_id = 2,
                order_date_time = DateTime.Parse("2020-12-21 12:57:00")
            });
            await _context.SaveChangesAsync();
            int expectedSize = 2;

            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Order_Lists>>(result);
            Assert.Equal(expectedSize, result.Count);
        }

        [Fact]
        public async Task GetAll_ShouldReturnEmptyListOfOrder_Lists_WhenNoOrder_ListsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Order_Lists>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnTheOrder_Lists_IfOrder_ListsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int order_lists_id = 1;
            _context.Order_Lists.Add(new Order_Lists
            {
                order_lists_id = order_lists_id,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _sut.GetById(order_lists_id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_Lists>(result);
            Assert.Equal(order_lists_id, result.order_lists_id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_IfOrder_ListsDoesNotExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int order_lists_id = 1;

            // Act
            var result = await _sut.GetById(order_lists_id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Create_ShouldAddIdToOrder_Lists_WhenSavingToDatabase()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int expectedId = 1;
            Order_Lists Order_Lists = new Order_Lists
            {
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            // act
            var result = await _sut.Create(Order_Lists);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_Lists>(result);
            Assert.Equal(expectedId, result.order_lists_id);
        }

        [Fact]
        public async Task Create_ShouldFailToAddOrder_Lists_WhenAddingOrder_ListsWithExistingId()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            Order_Lists Order_Lists = new Order_Lists
            {
                order_lists_id = 1,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            _context.Order_Lists.Add(Order_Lists);
            await _context.SaveChangesAsync();

            // act
            Func<Task> action = async () => await _sut.Create(Order_Lists);

            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async Task Update_ShouldChangeValuesOnOrder_Lists_WhenOrder_ListsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int order_lists_id = 1;
            Order_Lists Order_Lists = new Order_Lists
            {
                order_lists_id = order_lists_id,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")

            };
            _context.Order_Lists.Add(Order_Lists);
            await _context.SaveChangesAsync();

            Order_Lists updateOrder_Lists = new Order_Lists
            {
                order_lists_id = order_lists_id,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00"),

            };

            // Act
            var result = await _sut.Update(order_lists_id, updateOrder_Lists);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_Lists>(result);
            Assert.Equal(order_lists_id, result.order_lists_id);
            Assert.Equal(updateOrder_Lists.order_date_time, result.order_date_time);

        }

        [Fact]
        public async Task Update_ShouldReturnNull_WhenOrder_ListsDoesNotExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int order_lists_id = 1;
            Order_Lists updateOrder_Lists = new Order_Lists
            {
                order_lists_id = order_lists_id,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")
            };

            // Act
            var result = await _sut.Update(order_lists_id, updateOrder_Lists);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnDeletedOrder_Lists_WhenOrder_ListsIsDeleted()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int order_lists_id = 1;
            Order_Lists order_Lists = new Order_Lists
            {
                order_lists_id = order_lists_id,
                order_date_time = DateTime.Parse("2021-12-21 12:55:00")

            };
            _context.Order_Lists.Add(order_Lists);
            await _context.SaveChangesAsync();

            var result = await _sut.Delete(order_lists_id);
            var Order_Lists = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Order_Lists>(result);
            Assert.Equal(order_lists_id, result.order_lists_id);

            Assert.Empty(Order_Lists);
        }

        [Fact]
        public async Task Delete_ShouldReturnNull_WhenOrder_ListsDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int order_lists_id = 1;

            // Act
            var result = await _sut.Delete(order_lists_id);

            // Assert
            Assert.Null(result);
        }
    }
}
