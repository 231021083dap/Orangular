using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
// Orangular
using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Login.Requests;
using OrangularAPI.DTO.Users.Responses;
using OrangularAPI.Helpers;
using OrangularAPI.Repositories.users;
using OrangularAPI.Services.users;
// Orangular

namespace OrangularTests.UserTest
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
        // -----------------------------------------------------------------------------------------------------------------------
        // Authenticate Tests
        [Fact]
        public async Task Authenticate_ShouldReturnLoginResponse_WhenAuthenticateIsSuccess()
        {
            // Arrange
            // Act
            // Assert
        }
        [Fact]
        public async Task Authenticate_ShouldReturnNull_WhenEmailIsNull()
        {
            // Arrange
            // Act
            // Assert
        }
        [Fact]
        public async Task Authenticate_ShouldReturnNull_WhenPasswordIsNull()
        {
            // Arrange
            // Act
            // Assert
        }

        // -----------------------------------------------------------------------------------------------------------------------
        // GetAll Tests
        [Fact]
        public async Task GetAll_ShouldReturnListOfUserResponses_WhenUsersExists()
        {
            // Arrange
            List<Users> user = new();
            user.Add(new Users
            {
                users_id = 1,
                email = "Test1@Mail.com",
                role = Role.User,
                order_lists = new List<Order_Lists> { },
                addresses = new List<Addresses> { }

            });
            user.Add(new Users
            {
                users_id = 2,
                email = "Test2@Mail.com",
                role = Role.User,
                order_lists = new List<Order_Lists> { },
                addresses = new List<Addresses> { }
            });
            _userRepository.Setup(u => u.GetAll()).ReturnsAsync(user);
            // Act
            var result = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<UsersResponse>>(result);
        }
        [Fact]
        public async Task GetAll_ShouldReturnEmptyListOfUsers_WhenNoUsersExists()
        {
            // Arrange
            List<Users> user = new();
            _userRepository.Setup(a => a.GetAll()).ReturnsAsync(user);
            // Act
            var result = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<UsersResponse>>(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetById Tests
        [Fact]
        public async Task GetById_ShouldReturnUserResponse_WhenUserExists()
        {
            // Arrange
            int userId = 1;
            Users user = new Users
            {
                users_id = userId,
                email = "Test1@Mail.com",
                role = Role.User
            };
            _userRepository.Setup(u => u.GetById(It.IsAny<int>())).ReturnsAsync(user);
            // Act
            var result = await _sut.GetById(userId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<UsersResponse>(result);
            Assert.Equal(user.users_id, result.users_id);
            Assert.Equal(user.email, result.email);
            Assert.Equal(user.role, result.role);
        }
        [Fact]
        public async Task GetById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            int userId = 1;
            _userRepository.Setup(u => u.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.GetById(userId);
            // Assert
            Assert.Null(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Create Tests
        [Fact]
        public async Task Create_ShouldReturnUserResponse_WhenCreateIsSuccess()
        {
            // Arrange
            NewUser newUser = new NewUser // vi sender ind
            {
                Email = "Test1@Mail.com",
                Password = "Passw0rd"
            };
            int userId = 1;
            Users user = new Users // vi forventer at få tilbage
            {
                users_id = userId,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Role.User
            };
            _userRepository.Setup(a => a.Create(It.IsAny<Users>())).ReturnsAsync(user);
            // Act
            var result = await _sut.Create(newUser);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<UsersResponse>(result);
            Assert.Equal(userId, result.users_id);
            Assert.Equal(newUser.Email, result.email);
            Assert.Equal(newUser.Password, result.password);
            Assert.Equal(Role.User, result.role);
        }
        [Fact]
        public async Task Create_ShouldReturnNull_WhenCreatedUserIsNull()
        {
            // Arrange
            NewUser newUser = new NewUser
            {
                Email = "Test1@Mail.com",
                Password = "Passw0rd"
            };
            _userRepository.Setup(u => u.Create(It.IsAny<Users>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.Create(newUser);
            // Assert
            Assert.Null(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Update Tests
        [Fact]
        public async Task Update_ShouldReturnUpdatedUserResponse_WhenUpdateIsSuccess()
        {
            // Arrange
            int userId = 1;
            UpdateUser updateUser = new UpdateUser // sendes til update metoden
            {
                Email = "Test1@Mail.com",
                Password = "Passw0rd",
                Role = Role.User
            };
            Users user = new Users // sendes til repository
            {
                users_id = userId,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Role.User
            };
            _userRepository.Setup(u => u.Update(It.IsAny<int>(), It.IsAny<Users>())).ReturnsAsync(user);
            // Act
            var result = await _sut.Update(userId, updateUser);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<UsersResponse>(result);
            Assert.Equal(userId, result.users_id);
            Assert.Equal(updateUser.Email, result.email);
            Assert.Equal(updateUser.Password, result.password);
            Assert.Equal(updateUser.Role, result.role);
        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            UpdateUser updateUser = new UpdateUser
            {
                Email = "Test1@Mail.com",
                Password = "Passw0rd",
                Role = Role.User
            };
            int userId = 1;
            _userRepository.Setup(u => u.Update(It.IsAny<int>(), It.IsAny<Users>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.Update(userId, updateUser);
            // Assert
            Assert.Null(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Delete Tests
        [Fact]
        public async Task Delete_ShouldReturnTrue_WhenDeleteIsSuccess()
        {
            // Arrange
            int userId = 1;
            Users user = new Users
            {
                users_id = userId,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Role.User,
            };
            _userRepository.Setup(a => a.Delete(It.IsAny<int>())).ReturnsAsync(user);
            // Act
            var result = await _sut.Delete(userId);
            // Assert
            Assert.True(result);
        }
        [Fact]
        public async Task Delete_ShouldReturnFalse_WhenDeleteIsUnsuccessfull()
        {
            // Arrange
            int userId = 1;
            Users user = new Users
            {
                users_id = userId,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Role.User,
            };
            _userRepository.Setup(a => a.Delete(It.IsAny<int>())).ReturnsAsync(() => null);
            // Act
            var result = await _sut.Delete(userId);
            // Assert
            Assert.False(result);
        }
    }
}
