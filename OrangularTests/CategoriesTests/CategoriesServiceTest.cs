using Moq;
using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Category.Requests;
using OrangularAPI.DTO.Category.Responses;
using OrangularAPI.Repositories.CategoryRepository;
using OrangularAPI.Services.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.CategoryTests
{
    public class CategoryServiceTest
    {
        private readonly CategoryService _systemUnderTest;
        private readonly Mock<ICategoryRepository> _categoryRepository = new Mock<ICategoryRepository>();

        public CategoryServiceTest()
        {
            _systemUnderTest = new CategoryService(_categoryRepository.Object);
        }

        // arrange
        // act
        // assert

        [Fact]
        public async void getAll_ShouldAReturnListOfCategoryResponse_WhenCategoryExist()
        {
            List<Category> category = new List<Category>();

            category.Add(new Category
            {
                Id = 1,
                CategoryName = "Hunde"

            });
            category.Add(new Category
            {
                Id = 2,
                CategoryName = "Katte",
            });

            _categoryRepository
                .Setup(c => c.GetAll())
                .ReturnsAsync(category);

            var result = await _systemUnderTest.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<CategoryResponse>>(result);
        }
        [Fact]
        public async void getAll_ShouldReturnEmptyListOfCategoryResponse_WhenNoCategoryExists()
        {
            List<Category> Category = new List<Category>();

            _categoryRepository
                .Setup(c => c.GetAll())
                .ReturnsAsync(Category);

            var result = await _systemUnderTest.GetAll();

            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<CategoryResponse>>(result);


        }
        [Fact]
        public async void getbyID_ShouldReturnAnCategoryResponse_WhenCategoryExists()
        {
            int categoryId = 1;

            Category Category = new Category
            {
                Id = categoryId,
                CategoryName = "Katte",

            };

            _categoryRepository
               .Setup(c => c.GetById(It.IsAny<int>()))
               .ReturnsAsync(Category);

            var result = await _systemUnderTest.GetById(categoryId);



            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(categoryId, result.categoryID);
            Assert.Equal(Category.CategoryName, result.categoryName);


        }
        [Fact]
        public async void getbyID_ShouldReturnNull_WhenNoAuthorExists()
        {
            int categoryId = 1;

            _categoryRepository
                .Setup(c => c.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            var result = await _systemUnderTest.GetById(categoryId);

            Assert.Null(result);
        }
        [Fact]
        public async void create_ShouldReturnCategoryResponse_whenCreateIsSucces()
        {

            NewCategory newCategory = new NewCategory
            {
                categoryName = "Katte",

            };
            int categoryId = 1;

            Category Category = new Category
            {
                Id = categoryId,
                CategoryName = "Katte"
            };

            _categoryRepository
                .Setup(a => a.Create(It.IsAny<Category>()))
                .ReturnsAsync(Category);
            var result = await _systemUnderTest.Create(newCategory);

            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(categoryId, result.categoryID);
            //Assert.Equal(newCategory.CategoryName, result.CategoryName);      
        }
        [Fact]
        public async void delete_shouldReturnTrue_WhenDeleteIsSuccess()
        {
            int categoryId = 1;
            Category Category = new Category
            {
                Id = categoryId,
                CategoryName = "Hunde"

            };

            _categoryRepository
                .Setup(a => a.Delete(It.IsAny<int>()))
                .ReturnsAsync(Category);

            var result = await _systemUnderTest.Delete(categoryId);

            Assert.True(result);
        }

        [Fact]
        public async void Update_ShouldReturnAuthorResponse_whenUpdateIsSucces()
        {

            UpdateCategory updateCategory = new UpdateCategory
            {
                categoryName = "Katte"
            };
            int categoryId = 1;

            Category Category = new Category
            {
                Id = categoryId,
                CategoryName = "Katte"
            };

            _categoryRepository
                .Setup(c => c.Update(It.IsAny<int>(), It.IsAny<Category>()))
                .ReturnsAsync(Category);

            var result = await _systemUnderTest.Update(categoryId, updateCategory);
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(categoryId, result.categoryID);
            Assert.Equal(updateCategory.categoryName, result.categoryName);




        }

    }
}
