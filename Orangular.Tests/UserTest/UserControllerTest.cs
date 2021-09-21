using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Orangular.Controllers;
using Orangular.DTO.Users.Responses;
using Orangular.Services.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.UserTest
{
    public class UserControllerTest
    {
        private readonly UserController _sut;
        private readonly Mock<IUserService> _userService = new();
        public UserControllerTest()
        {
            _sut = new UserController(_userService.Object);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetAll Tests
        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenDataExists()
        {
            // Arrange
            List<UsersResponse> user = new();
            user.Add(new UsersResponse
            {
                users_id = 1,
                email = "Test1@Mail.com",
                role = Helpers.Role.User
            });
            user.Add(new UsersResponse
            {
                users_id = 1,
                email = "Test1@Mail.com",
                role = Helpers.Role.User,
            });
            _userService.Setup(u => u.GetAll()).ReturnsAsync(user);
            // Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoDataExists()
        {
            // Arrange
            List<UsersResponse> user = new();
            _userService.Setup(u => u.GetAll()).ReturnsAsync(user);
            // Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenNullIsReturnedFromService()
        {
            // Arrange
            List<UsersResponse> user = new();
            _userService.Setup(u => u.GetAll()).ReturnsAsync(() => null);
            // Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsReturnedFromService()
        { 
            // Arrange
            List<UsersResponse> user = new();
            _userService.Setup(s => s.GetAll()).ReturnsAsync(() => throw new Exception("This is an Exception"));
            // Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
            //Func<Task> action = async () => await _sut.GetById(userId);
            //var ex = await Assert.ThrowsAsync<Exception>(action);
            //Assert.Contains("Email " + user2.email + " is already taken", ex.Message);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetById Tests
        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            // Arrange
            int userId = 1;
            UsersResponse user = new UsersResponse {};
            _userService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(user);
            // Act
            var result = await _sut.GetById(userId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenUserDoesNotExist()
        {
            // Arrange
            int userId = 1;
            _userService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.GetById(userId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            _userService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(() => throw new Exception("This is an exception")); ;
            // Act
            var result = await _sut.GetById(1);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
