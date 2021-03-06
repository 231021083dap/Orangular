using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Orangular.Controllers;
using OrangularAPI.DTO.Category.Requests;
using OrangularAPI.DTO.Category.Responses;
using OrangularAPI.Services.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.CategoryTests
{
    public class CategoryControllerTests
    {
        private readonly CategoryController _systemUnderTest;
        private readonly Mock<ICategoryService> _categoryService = new Mock<ICategoryService>();

        public CategoryControllerTests()
        {
            _systemUnderTest = new CategoryController(_categoryService.Object);
        }

        [Fact]
        public async void GetAll_shouldReturnStatusCode200_whenDataExists()
        {



            List<CategoryResponse> CategoryResponses = new();
            CategoryResponses.Add(new CategoryResponse
            {
                Id = 1,
                CategoryName = "hunde",
            });

            CategoryResponses.Add(new CategoryResponse
            {
                Id = 2,
                CategoryName = "Katte",
            });

            _categoryService
                .Setup(s => s.GetAll())
                .ReturnsAsync(CategoryResponses);

            var result = await _systemUnderTest.GetAll();


            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_shouldReturnStatusCode204_whenNoDataExists()
        {


            List<CategoryResponse> CategoryResponses = new();


            _categoryService
                .Setup(s => s.GetAll())
                .ReturnsAsync(CategoryResponses);

            var result = await _systemUnderTest.GetAll();


            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_shouldReturnStatusCode500_whenNullIsReturnedFromService()
        {
            _categoryService
                .Setup(s => s.GetAll())
                .ReturnsAsync(() => null);

            //storing the data in variable store
            var result = await _systemUnderTest.GetAll();


            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_shouldReturnStatusCode204_whenExceptionIsRaised()
        {

            _categoryService
                .Setup(s => s.GetAll())
                .ReturnsAsync(() => throw new Exception("a exception"));
            var result = await _systemUnderTest.GetAll();
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void create_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            int Id = 1;

            NewCategory newCategory = new NewCategory
            {
                categoryName = "Katte"
            };

            CategoryResponse Category = new CategoryResponse
            {
                Id = Id,
                CategoryName = "Katte"
            };

            _categoryService
                .Setup(s => s.Create(It.IsAny<NewCategory>()))
                .ReturnsAsync(Category);

            var result = await _systemUnderTest.Create(newCategory);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void create_ShouldReturnStatusCode500_WhenExceptisonIsRaised()
        {
            NewCategory newCategory = new NewCategory
            {
                categoryName = "Katte"
            };

            _categoryService
               .Setup(s => s.Create(It.IsAny<NewCategory>()))
               .ReturnsAsync(() => throw new System.Exception("This is an exeption"));

            var result = await _systemUnderTest.Create(newCategory);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);


        }
        [Fact]
        public async void update_ShouldReturnStatusCode200_WhenDataIsSaved()
        {
            int Id = 1;

            UpdateCategory updateCategory = new UpdateCategory
            {
                categoryName = "Hunde"
            };

            CategoryResponse Category = new CategoryResponse
            {
                Id = Id,
                CategoryName = "Hunde"
            };

            _categoryService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateCategory>()))
                .ReturnsAsync(Category);

            var result = await _systemUnderTest.Update(Id, updateCategory);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);


        }
        [Fact]
        public async void update_ShouldReturnStatusCode500_WhenExceptisonIsRaised()
        {
            int Id = 1;

            UpdateCategory updateCategory = new UpdateCategory
            {
                categoryName = "Hunde"
            };

            _categoryService
                .Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateCategory>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exeption"));

            var result = await _systemUnderTest.Update(Id, updateCategory);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void delete_ShouldReturnStatusCode204_WhenDataIsDeleted()
        {
            int Id = 1;

            _categoryService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(true);

            var result = await _systemUnderTest.Delete(Id);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void delete_ShouldReturnStatusCode500_WhenExceptisonIsRaised()
        {
            int Id = 1;

            _categoryService
                .Setup(s => s.Delete(It.IsAny<int>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exeption"));

            var result = await _systemUnderTest.Delete(Id);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
