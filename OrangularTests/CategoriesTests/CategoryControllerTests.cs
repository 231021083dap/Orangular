using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Orangular.Controllers;
using Orangular.DTO.Categories.Requests;
using Orangular.DTO.Categories.Responses;
using Orangular.Services.categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.CategoriesTests
{
    public class CategoryControllerTests
    {
        private readonly CategoriesController _systemUnderTest;
        private readonly Mock<ICategoryService> _categoryService = new Mock<ICategoryService>();

        public CategoryControllerTests()
        {
            _systemUnderTest = new CategoriesController(_categoryService.Object);
        }

        [Fact]
        public async void GetAll_shouldReturnStatusCode200_whenDataExists()
        {


      
            List<CategoriesResponse> categoriesResponses = new();
            categoriesResponses.Add(new CategoriesResponse
            {
                categories_id = 1,
                category_name ="hunde",
            });

            categoriesResponses.Add(new CategoriesResponse
            {
                categories_id = 2,
                category_name = "Katte",
            });

            _categoryService
                .Setup(s => s.getAll())
                .ReturnsAsync(categoriesResponses);

            var result = await _systemUnderTest.getAll();


            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_shouldReturnStatusCode204_whenNoDataExists()
        {

           
            List<CategoriesResponse> categoriesResponses = new();


            _categoryService
                .Setup(s => s.getAll())
                .ReturnsAsync(categoriesResponses);
            
            var result = await _systemUnderTest.getAll();


            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_shouldReturnStatusCode500_whenNullIsReturnedFromService()
        {
            _categoryService
                .Setup(s => s.getAll())
                .ReturnsAsync(() => null);

            //storing the data in variable store
            var result = await _systemUnderTest.getAll();


            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_shouldReturnStatusCode204_whenExceptionIsRaised()
        {
 
            _categoryService
                .Setup(s => s.getAll())
                .ReturnsAsync(() => throw new Exception("a exception"));
            var result = await _systemUnderTest.getAll();
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void create_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            int categories_id = 1;

            NewCategories newCategories = new NewCategories
            {
                category_name = "Katte"
            };

            CategoriesResponse categories = new CategoriesResponse
            {
                categories_id = categories_id,
                category_name = "Katte"
            };

            _categoryService
                .Setup(s => s.create(It.IsAny<NewCategories>()))
                .ReturnsAsync(categories);

            var result = await _systemUnderTest.create(newCategories);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void create_ShouldReturnStatusCode500_WhenExceptisonIsRaised()
        {
            NewCategories newCategories = new NewCategories
            {
                category_name = "Katte"
            };

            _categoryService
               .Setup(s => s.create(It.IsAny<NewCategories>()))
               .ReturnsAsync(() => throw new System.Exception("This is an exeption"));

            var result = await _systemUnderTest.create(newCategories);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);


        }
        [Fact]
        public async void update_ShouldReturnStatusCode200_WhenDataIsSaved()
        {
            int categories_Id = 1;

            UpdateCategories updateCategories = new UpdateCategories
            {
                category_name = "Hunde"
            };

            CategoriesResponse categories = new CategoriesResponse
            {
                categories_id = categories_Id,
                category_name = "Hunde"
            };

            _categoryService
                .Setup(s => s.update(It.IsAny<int>(), It.IsAny<UpdateCategories>()))
                .ReturnsAsync(categories);

            var result = await _systemUnderTest.update(categories_Id, updateCategories);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);


        }
        [Fact]
        public async void update_ShouldReturnStatusCode500_WhenExceptisonIsRaised()
        {
            int categories_Id = 1;

            UpdateCategories updateCategories = new UpdateCategories
            {
                category_name = "Hunde"
            };
            
            _categoryService
                .Setup(s => s.update(It.IsAny<int>(), It.IsAny<UpdateCategories>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exeption"));

            var result = await _systemUnderTest.update(categories_Id, updateCategories);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void delete_ShouldReturnStatusCode204_WhenDataIsDeleted()
        {
            int categories_id = 1;

            _categoryService
                .Setup(s => s.delete(It.IsAny<int>()))
                .ReturnsAsync(true);

            var result = await _systemUnderTest.delete(categories_id);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void delete_ShouldReturnStatusCode500_WhenExceptisonIsRaised()
        {
            int categories_id = 1;

            _categoryService
                .Setup(s => s.delete(It.IsAny<int>()))
                .ReturnsAsync(() => throw new System.Exception("This is an exeption"));

            var result = await _systemUnderTest.delete(categories_id);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
