using Microsoft.EntityFrameworkCore;
using Orangular.Database;
using Orangular.Database.Entities;
using Orangular.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests
{
    public class ProductsRepositoryTests
    {
        private readonly ProductsRepository _sut;
        private readonly OrangularProjectContext _context;
        private readonly DbContextOptions<OrangularProjectContext> _options;

        public ProductsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<OrangularProjectContext>()
                .UseInMemoryDatabase(databaseName: "OrangularProjectProductsRepositoryTests")
                .Options;

            _context = new OrangularProjectContext(_options);

            _sut = new ProductsRepository(_context);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfProducts_WhenProductsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            _context.Products.Add(new Products
            {
                products_id = 1,
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            });
            _context.Products.Add(new Products
            {
                products_id = 2,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            });
            await _context.SaveChangesAsync();
            int expectedSize = 2;

            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Products>>(result);
            Assert.Equal(expectedSize, result.Count);
        }

        [Fact]
        public async Task GetAll_ShouldReturnEmptyListOfProducts_WhenNoProductsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Products>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnTheProducts_IfProductsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int products_Id = 1;
            _context.Products.Add(new Products
            {
                products_id = products_Id,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _sut.GetById(products_Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Products>(result);
            Assert.Equal(products_Id, result.products_id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_IfProductsDoesNotExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int products_Id = 1;

            // Act
            var result = await _sut.GetById(products_Id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Create_ShouldAddIdToProducts_WhenSavingToDatabase()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int expectedId = 1;
            Products Products = new Products
            {
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            // act
            var result = await _sut.Create(Products);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Products>(result);
            Assert.Equal(expectedId, result.products_id);
        }

        [Fact]
        public async Task Create_ShouldFailToAddProducts_WhenAddingProductsWithExistingId()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            Products Products = new Products
            {
                products_id = 1,
                breed_name = "Cane Corso",
                price = 3000,
                weight = 30000,
                gender = "Male",
                description = "Test test"
            };

            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            // act
            Func<Task> action = async () => await _sut.Create(Products);

            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async Task Update_ShouldChangeValuesOnProducts_WhenProductsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
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
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            Products updateProducts = new Products
            {
                products_id = products_Id,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            // Act
            var result = await _sut.Update(products_Id, updateProducts);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Products>(result);
            Assert.Equal(products_Id, result.products_id);
            Assert.Equal(updateProducts.breed_name, result.breed_name);
            Assert.Equal(updateProducts.price, result.price);
            Assert.Equal(updateProducts.weight, result.weight);
            Assert.Equal(updateProducts.gender, result.gender);
            Assert.Equal(updateProducts.description, result.description);
        }

        [Fact]
        public async Task Update_ShouldReturnNull_WhenProductsDoesNotExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int products_Id = 1;
            Products updateProducts = new Products
            {
                products_id = products_Id,
                breed_name = "Beetle",
                price = 1000,
                weight = 10000,
                gender = "Male",
                description = "Test test"
            };

            // Act
            var result = await _sut.Update(products_Id, updateProducts);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnDeletedProducts_WhenProductsIsDeleted()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
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
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            var result = await _sut.Delete(products_Id);
            var products = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Products>(result);
            Assert.Equal(products_Id, result.products_id);

            Assert.Empty(products);
        }

        [Fact]
        public async Task Delete_ShouldReturnNull_WhenProductsDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int products_Id = 1;

            // Act
            var result = await _sut.Delete(products_Id);

            // Assert
            Assert.Null(result);
        }
    }
}
