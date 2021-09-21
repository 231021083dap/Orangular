using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Orangular.Controllers;
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
    }
}
