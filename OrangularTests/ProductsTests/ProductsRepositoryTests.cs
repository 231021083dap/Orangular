using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Xunit;
// Orangular
using OrangularAPI.Database.Entities;
using OrangularAPI.Repositories;
using OrangularAPI.Database;
using OrangularAPI.Repositories.ProductsRepository;
// Orangular




namespace OrangularTests.ProductsTests
{
    public class ProductsRepositoryTests
    {
        private readonly ProductRepository _sut;
        private readonly OrangularProjectContext _context;
        private readonly DbContextOptions<OrangularProjectContext> _options;

        public ProductsRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<OrangularProjectContext>()
                .UseInMemoryDatabase(databaseName: "OrangularProjectProductsRepositoryTests")
                .Options;

            _context = new OrangularProjectContext(_options);

            _sut = new ProductRepository(_context);
        }

        [Fact]
        public async Task GetAll_ShouldReturnListOfProducts_WhenProductsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            _context.Product.Add(new Product
            {
                Id = 1,
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test",
                Category = new()
                
            });
            _context.Product.Add(new Product
            {
                Id = 2,
                BreedName = "Beetle",
                Price = 1000,
                Weight = 10000,
                Gender = "Male",
                Description = "Test test",
                Category = new()
            });
            await _context.SaveChangesAsync();
            int expectedSize = 2;

            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Product>>(result);
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
            Assert.IsType<List<Product>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnTheProducts_IfProductsExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int ProductId = 1;
            _context.Product.Add(new Product
            {
                Id = ProductId,
                BreedName = "Beetle",
                Price = 1000,
                Weight = 10000,
                Gender = "Male",
                Description = "Test test",
                Category = new ()
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _sut.GetById(ProductId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
            Assert.Equal(ProductId, result.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_IfProductsDoesNotExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int ProductId = 1;

            // Act
            var result = await _sut.GetById(ProductId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Create_ShouldAddIdToProducts_WhenSavingToDatabase()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int expectedId = 1;
            Product Products = new Product
            {
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test"
            };

            // act
            var result = await _sut.Create(Products);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
            Assert.Equal(expectedId, result.Id);
        }

        [Fact]
        public async Task Create_ShouldFailToAddProducts_WhenAddingProductsWithExistingId()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();

            Product Products = new Product
            {
                Id = 1,
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test"
            };

            _context.Product.Add(Products);
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
            int ProductId = 1;
            Product Products = new Product
            {
                Id = ProductId,
                BreedName = "Cane Corso",
                Price = 3000,
                Weight = 30000,
                Gender = "Male",
                Description = "Test test"
            };
            _context.Product.Add(Products);
            await _context.SaveChangesAsync();

            Product updateProducts = new Product
            {
                Id = ProductId,
                BreedName = "Beetle",
                Price = 1000,
                Weight = 10000,
                Gender = "Male",
                Description = "Test test"
            };

            // Act
            var result = await _sut.Update(ProductId, updateProducts);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
            Assert.Equal(ProductId, result.Id);
            Assert.Equal(updateProducts.BreedName, result.BreedName);
            Assert.Equal(updateProducts.Price, result.Price);
            Assert.Equal(updateProducts.Weight, result.Weight);
            Assert.Equal(updateProducts.Gender, result.Gender);
            Assert.Equal(updateProducts.Description, result.Description);
        }

        [Fact]
        public async Task Update_ShouldReturnNull_WhenProductsDoesNotExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int ProductId = 1;
            Product updateProducts = new Product
            {
                Id = ProductId,
                BreedName = "Beetle",
                Price = 1000,
                Weight = 10000,
                Gender = "Male",
                Description = "Test test"
            };

            // Act
            var result = await _sut.Update(ProductId, updateProducts);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnDeletedProducts_WhenProductsIsDeleted()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int ProductId = 1;
            Product Products = new Product
            {
                Id = ProductId,
                BreedName = "Beetle",
                Price = 1000,
                Weight = 10000,
                Gender = "Male",
                Description = "Test test"
            };
            _context.Product.Add(Products);
            await _context.SaveChangesAsync();

            var result = await _sut.Delete(ProductId);
            var products = await _sut.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
            Assert.Equal(ProductId, result.Id);

            Assert.Empty(products);
        }

        [Fact]
        public async Task Delete_ShouldReturnNull_WhenProductsDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int ProductId = 1;

            // Act
            var result = await _sut.Delete(ProductId);

            // Assert
            Assert.Null(result);
        }
    }
}
