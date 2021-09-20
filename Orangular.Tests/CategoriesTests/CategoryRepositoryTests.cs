using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using Orangular.Repositories.categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.CategoriesTests
{
 public   class CategoryRepositoryTests
    {

        private readonly CategoryRepository _systemUnderTest;

        private readonly OrangularProjectContext _context;

        private readonly DbContextOptions<OrangularProjectContext> _DBoptions;

        public CategoryRepositoryTests()
        {

            //new instance of in MemoryADatabase using the DbcontextOptionBuilder
            _DBoptions = new DbContextOptionsBuilder<OrangularProjectContext>()
                .UseInMemoryDatabase(databaseName: "Categories")
                .Options;

            _context = new OrangularProjectContext(_DBoptions);

            _systemUnderTest = new CategoryRepository(_context);
        }

        //------------ Test scenario for getAll-method ---------------//

        [Fact]
        public async Task getAll_ShouldReturnListOfCategories_WhenCategoriesExist()
        {
            
            await _context.Database.EnsureDeletedAsync();
            _context.Categories.Add(new Categories
            {
                categories_id = 1,
                category_name = "Hunde"
            });
            _context.Categories.Add(new Categories {
                categories_id = 2,
                category_name = "Katte"
            });

            await _context.SaveChangesAsync();
            var result = await _systemUnderTest.getAll();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<Categories>>(result);
        }

        [Fact]
        public async Task getAll_ShouldReturnEmptyListOfCategories_WhenCategorisNOTExist()
        {
            await _context.Database.EnsureDeletedAsync();
            var result = await _systemUnderTest.getAll();
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<Categories>>(result);

        }

        //------------ Test scenario for create-method ---------------//

        [Fact]
        public async Task create_ShouldAddIDToCategories_WhenSavingANewCategoryRecordToDatabase()
        {
            await _context.Database.EnsureDeletedAsync();

            int expectedID = 1;

            Categories categories = new Categories
            {
                category_name = "Hunde",
            };

            var result = await _systemUnderTest.create(categories);
            Assert.NotNull(result);
            Assert. IsType<Categories>(result);
            Assert.Equal(expectedID, result.categories_id);


        }
        //------------ Test scenario for update-method ---------------//

        [Fact]
        public async Task update_ShouldChangeValuesOnCategories_WhenCategoryExist()
        {

            await _context.Database.EnsureDeletedAsync();
            int categoriesId = 1;
            Categories categories = new Categories
            {
                categories_id = categoriesId,
                category_name = "Aber"
            };

            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();

            Categories Updatedcategories = new Categories
            {
                categories_id = categoriesId,
                category_name = "Kaniner"

            };

            var result = await _systemUnderTest.update(categoriesId, Updatedcategories);

            Assert.NotNull(result);
            Assert.IsType<Categories>(result);
            Assert.Equal(categoriesId, result.categories_id);
            Assert.Equal(Updatedcategories.category_name, result.category_name);
           
        }

        [Fact]
        public async Task update_ShouldReturnNull_WhenCategoryDataDoesNotExist()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoriesId = 1;

            Categories updatedCategories = new Categories
            {
                categories_id = categoriesId,
                category_name = "Hunde"
             };

            var result = await _systemUnderTest.update(categoriesId, updatedCategories);

            Assert.Null(result);
        }

        //------------ Test scenario for delete-method ---------------//
        [Fact]
        public async Task delete_ShouldReturNull_WhenCategoryDoesNotDeleted()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoriesId = 1;
            var result = await _systemUnderTest.delete(categoriesId);
            Assert.Null(result);
        }

        [Fact]
        public async Task delete_ShouldReturnDeletedAuthor_WhenAuthorIsDeleteSuccessed()
        {
            await _context.Database.EnsureDeletedAsync();
            int categoryId = 1;

            Categories categories = new Categories
            {
                categories_id = categoryId,
                category_name = "Hund"
            };
            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();

            var result = await _systemUnderTest.delete(categoryId);
            var catories = await _systemUnderTest.getAll();

            Assert.NotNull(result);
            Assert.IsType<Categories>(result);
            Assert.Equal(categoryId, result.categories_id);
            Assert.Empty(catories);


        }

    }
}