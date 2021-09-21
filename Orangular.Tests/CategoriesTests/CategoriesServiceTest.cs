using Moq;
using Orangular.Database.Entities;
using Orangular.DTO.Categories.Requests;
using Orangular.DTO.Categories.Responses;
using Orangular.Repositories.categories;
using Orangular.Services.categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.CategoriesTests
{
    public class CategoriesServiceTest
    {
        private readonly CategoryService _systemUnderTest;
        private readonly Mock<ICategoryRepository> _categoryRepository = new Mock<ICategoryRepository>();

        public CategoriesServiceTest()
        {
            _systemUnderTest = new CategoryService(_categoryRepository.Object);
        }

        [Fact]
        public async void getAll_ShouldAReturnListOfCategoryResponse_WhenCategoryExist()
        {
            List<Categories> categories = new List<Categories>();

            categories.Add(new Categories
            {
                categories_id = 1,
                category_name = "Hunde"
                
            });
            categories.Add(new Categories
            {
                categories_id = 2,
                category_name = "Katte",
            });

            _categoryRepository
                .Setup(c => c.getAll())
                .ReturnsAsync(categories);

            var result = await _systemUnderTest.getAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<CategoriesResponse>>(result);
        }

        [Fact]
        public async void getAll_ShouldReturnEmptyListOfCategoryResponse_WhenNoCategoryExists()
        {
            List<Categories> categories = new List<Categories>();

            _categoryRepository
                .Setup(c => c.getAll())
                .ReturnsAsync(categories);

            var result = await _systemUnderTest.getAll();

            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<CategoriesResponse>>(result);


        }
        [Fact]
        public async void getbyID_ShouldReturnAnCategoryResponse_WhenCategoryExists()
        {
            int categoryId = 1;

            Categories categories = new Categories
            {
                categories_id = categoryId,
                category_name = "Katte",
              
            };

            _categoryRepository
               .Setup(c => c.getById(It.IsAny<int>()))
               .ReturnsAsync(categories);

            var result = await _systemUnderTest.getById(categoryId);



            Assert.NotNull(result);
            Assert.IsType<CategoriesResponse>(result);
            Assert.Equal(categoryId, result.categories_id);
            Assert.Equal(categories.category_name, result.category_name);
     

        }

        [Fact]
        public async void getbyID_ShouldReturnNull_WhenNoAuthorExists()
        {
            int categoryId = 1;

            _categoryRepository
                .Setup(c => c.getById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            var result = await _systemUnderTest.getById(categoryId);

            Assert.Null(result);
        }
   [Fact]
      public async void create_ShouldReturnCategoryResponse_whenCreateIsSucces()
        {

            NewCategories newCategories = new NewCategories
            {
                category_name = "Katte",
                
            };
            int categoryId = 1;

            Categories categories = new Categories
            {
              categories_id = categoryId,
              category_name = "Katte"
            };

            _categoryRepository
                .Setup(a => a.create(It.IsAny<Categories>()))
                .ReturnsAsync(categories);
            var result = await _systemUnderTest.create(newCategories);

            Assert.NotNull(result);
            Assert.IsType<CategoriesResponse>(result);
            Assert.Equal(categoryId, result.categories_id);
            Assert.Equal(newCategories.category_name, result.category_name);      
        }
     [Fact]
        public async void delete_shouldReturnTrue_WhenDeleteIsSuccess()
        {
            int categoryId = 1;
            Categories categories = new Categories
            {
                categories_id = categoryId,
                category_name ="Hunde"

            };

            _categoryRepository
                .Setup(a => a.delete(It.IsAny<int>()))
                .ReturnsAsync(categories);

            var result = await _systemUnderTest.delete(categoryId);

            Assert.True(result);
        }

    }
}
