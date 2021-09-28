using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using OrangularAPI.Repositories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.CategoryTests
{
    public class CategoryRepositoryTests
    {

        private readonly CategoryRepository _systemUnderTest;

        private readonly OrangularProjectContext _context;

        private readonly DbContextOptions<OrangularProjectContext> _DBoptions;

        public CategoryRepositoryTests()
        {

            //new instance of in MemoryADatabase using the DbcontextOptionBuilder
            _DBoptions = new DbContextOptionsBuilder<OrangularProjectContext>()
                .UseInMemoryDatabase(databaseName: "Category")
                .Options;

            _context = new OrangularProjectContext(_DBoptions);

            _systemUnderTest = new CategoryRepository(_context);
        }

        // arrange
        // act
        // assert


        //------------ Test scenario for getAll-method ---------------//

        [Fact]
        public async Task getAll_ShouldReturnListOfCategory_WhenCategoryExist()
        {

            await _context.Database.EnsureDeletedAsync();
            _context.Category.Add(new Category
            {
                Id = 1,
                CategoryName = "Hunde"
            });
            _context.Category.Add(new Category
            {
                Id = 2,
                CategoryName = "Katte"
            });

            await _context.SaveChangesAsync();
            var result = await _systemUnderTest.GetAll();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<Category>>(result);
        }

        [Fact]
        public async Task getAll_ShouldReturnEmptyListOfCategory_WhenCategorisNOTExist()
        {
            await _context.Database.EnsureDeletedAsync();
            var result = await _systemUnderTest.GetAll();
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<Category>>(result);

        }

        //------------ Test scenario for create-method ---------------//

        [Fact]
        public async Task create_ShouldAddIDToCategory_WhenSavingANewCategoryRecordToDatabase()
        {
            await _context.Database.EnsureDeletedAsync();

            int expectedID = 1;

            Category Category = new Category
            {
                CategoryName = "Hunde",
            };

            var result = await _systemUnderTest.Create(Category);
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(expectedID, result.Id);


        }
        //------------ Test scenario for update-method ---------------//

        [Fact]
        public async Task update_ShouldChangeValuesOnCategory_WhenCategoryExist()
        {

            await _context.Database.EnsureDeletedAsync();
            int CategoryId = 1;
            Category Category = new Category
            {
                Id = CategoryId,
                CategoryName = "Aber"
            };

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            Category UpdatedCategory = new Category
            {
                Id = CategoryId,
                CategoryName = "Kaniner"

            };

            var result = await _systemUnderTest.Update(CategoryId, UpdatedCategory);

            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(CategoryId, result.Id);
            Assert.Equal(UpdatedCategory.CategoryName, result.CategoryName);

        }

        [Fact]
        public async Task update_ShouldReturnNull_WhenCategoryDataDoesNotExist()
        {
            await _context.Database.EnsureDeletedAsync();
            int CategoryId = 1;

            Category updatedCategory = new Category
            {
                Id = CategoryId,
                CategoryName = "Hunde"
            };

            var result = await _systemUnderTest.Update(CategoryId, updatedCategory);

            Assert.Null(result);
        }

        //------------ Test scenario for delete-method ---------------//
        [Fact]
        public async Task delete_ShouldReturNull_WhenCategoryDoesNotDeleted()
        {
            await _context.Database.EnsureDeletedAsync();
            int CategoryId = 1;
            var result = await _systemUnderTest.Delete(CategoryId);
            Assert.Null(result);
        }

        [Fact]
        public async Task delete_ShouldReturnDeletedAuthor_WhenAuthorIsDeleteSuccessed()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoryId = 1;

            Category Category = new Category
            {
                Id = categoryId,
                CategoryName = "Hund"
            };
            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            var result = await _systemUnderTest.Delete(categoryId);
            var catories = await _systemUnderTest.GetAll();

            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(categoryId, result.Id);
            Assert.Empty(catories);


        }

    }
}