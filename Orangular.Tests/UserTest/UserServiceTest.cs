using Moq;
using Orangular.Authorization;
using Orangular.Database.Entities;
using Orangular.DTO.Users.Responses;
using Orangular.Repositories.users;
using Orangular.Services.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.UserTest
{
    public class UserServiceTest
    {
        private readonly UserService _sut;
        private readonly Mock<IUserRepository> _userRepository = new();
       // private readonly Mock<IJwtUtils> _jwtUtils = new();
        public UserServiceTest()
        {
            _sut = new UserService(_userRepository.Object);
        }
        [Fact]
        public async void GetAll_ShouldReturnListOfUserResponses_WhenUsersExists()
        {
            // Arrange
            List<Users> user = new();
            user.Add(new Users
            {
                users_id = 1,
                email = "Test1@Mail.com",
                role = Helpers.Role.User


            });
            user.Add(new Users
            {
                users_id = 2,
                email = "Test2@Mail.com",
                role = Helpers.Role.User
            });
            _userRepository.Setup(u => u.GetAll()).ReturnsAsync(user);
            // Act
            var result = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<UsersResponse>>(result);
        }



    }
}
