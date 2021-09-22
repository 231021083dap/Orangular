using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Orangular.Controllers;
using Orangular.Database.Entities;
using Orangular.DTO.Login.Requests;
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
        // -----------------------------------------------------------------------------------------------------------------------
        // Create Tests
        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenUserWasCreated()
        {
            // Arrange
            NewUser newUser = new NewUser
            {
                Email = "Test1@Mail.com",
                Password = "Passw0rd"
            };
            UsersResponse userResponse = new UsersResponse
            {
                users_id = 1,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User,
                Order_Lists = new List<UsersOrder_ListsResponse>(),
                Addresses = new List<UsersAddressesResponse>()
            };
            _userService.Setup(s => s.Create(It.IsAny<NewUser>())).ReturnsAsync(userResponse) ;
            // Act
            var result = await _sut.Create(newUser);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Create_ShouldReturnStatusCode500_ExceptionIsRaised()
        {
            // Arrange
            NewUser newUser = new NewUser
            {
                Email = "Test1@Mail.com",
                Password = "Passw0rd"
            };
            _userService.Setup(s => s.Create(It.IsAny<NewUser>())).ReturnsAsync(() => throw new Exception("This is an exception"));
            // Act
            var result = await _sut.Create(newUser);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Update Tests
        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenUserDataIsSaved()
        {
            // Arrange
            int userId = 1;
            UpdateUser updateUser = new UpdateUser
            {
            };
            UsersResponse userResponse = new UsersResponse
            {
            };
            _userService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateUser>())).ReturnsAsync(userResponse);
            // Act
            var result = await _sut.Update(userId, updateUser);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Update_ShouldReturnStatusCode500_ExceptionIsRaised()
        {
            // Arrange
            int userId = 1;
            UpdateUser updateUser = new UpdateUser{};
            _userService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<UpdateUser>())).ReturnsAsync(() => throw new Exception("This is an exception"));
            // Act
            var result = await _sut.Update(userId, updateUser);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Delete Tests
        [Fact]
        public async void Delete_ShouldReturnStatusCode204_WhenUserIsDeleted()
        {
            // Arrange
            int userId = 1;
            _userService.Setup(s => s.Delete(It.IsAny<int>())).ReturnsAsync(true);
            // Act
            var result = await _sut.Delete(userId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int userId = 1;
            _userService.Setup(s => s.Delete(It.IsAny<int>())).ReturnsAsync(() => throw new Exception("HEY Exception over here!"));
            // Act
            var result = await _sut.Delete(userId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
