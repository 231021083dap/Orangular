using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using Orangular.Repositories.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.UsersTests
{
   public class UsersRepositoryTests
    {
        private readonly UserRepository _sut;
        private readonly OrangularProjectContext _context;
        private readonly DbContextOptions<OrangularProjectContext> _options;
        public UsersRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<OrangularProjectContext>()
            .UseInMemoryDatabase(databaseName: "OrangularUsersDatabase")
            .Options;
            _context = new OrangularProjectContext(_options);
            _sut = new UserRepository(_context);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetAll Tests
        [Fact]
        public async Task GetAll_ShouldReturnListOfUsers_WhenUsersExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            _context.Users.Add(new Users
            {
                users_id = 1,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.Admin
            });
            _context.Users.Add(new Users
            {
                users_id = 2,
                email = "Test2@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            });
            await _context.SaveChangesAsync();
            //Act
            var result = await _sut.GetAll();
            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<Users>>(result);
        }
        [Fact]
        public async Task GetAll_ShouldReturnEmptyListOfUsers_WhenNoUsersExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _sut.GetAll();
            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<Users>>(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // GetById Tests
        [Fact]
        public async Task GetById_ShouldReturnUser_IfUserExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int userId = 1;
            _context.Users.Add(new Users
            {
                users_id = userId,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.Admin
            });
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.GetById(userId);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Users>(result);
            Assert.Equal(userId, result.users_id);
        }
        [Fact]
        public async Task GetById_ShouldReturnNull_IfUserDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int userId = 1;
            // Act
            var result = await _sut.GetById(userId);
            // Assert
            Assert.Null(result);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Create Tests
        [Fact]
        public async Task Create_ShouldAddIdToUser_WhenSavingToDatabase()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int expectedId = 1;
            Users user = new Users
            {
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            // Act
            var result = await _sut.Create(user);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Users>(result);
            Assert.Equal(expectedId, result.users_id);
        }
        [Fact]
        public async Task Create_ShouldFailToAddUser_WhenAddingUserWithExistingId()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            Users user = new Users
            {
                users_id = 1,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // Act
            Func<Task> action = async () => await _sut.Create(user);
            // Assert
            var ex = await Assert.ThrowsAsync<Exception>(action);
            Assert.Contains("Nice try, userId " + user.users_id + " already Exists", ex.Message);
        }
        [Fact]
        public async Task Create_ShouldFailToAddUser_WhenAddingUserWithExistingEmail()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            Users user1 = new Users
            {
                users_id = 1,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            Users user2 = new Users
            {
                users_id = 2,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            _context.Users.Add(user1);
            await _context.SaveChangesAsync();
            // Act
            Func<Task> action = async () => await _sut.Create(user2);
            // Assert
            var ex = await Assert.ThrowsAsync<Exception>(action);
            Assert.Contains("Email " + user1.email + " is already taken", ex.Message);
        }
        [Fact]
        public async Task Create_ShouldFailToAddUser_WhenPasswordIsNull()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            Users user = new Users
            {
                users_id = 1,
                email = "Test1@Mail.com",
                role = Helpers.Role.User
            };
            // Act
            Func<Task> action = async () => await _sut.Create(user);
            // Assert
            var ex = await Assert.ThrowsAsync<Exception>(action);
            Assert.Contains("You must enter a password", ex.Message);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Update Tests
        [Fact]
        public async Task Update_ShouldChangeValuesOnUser_WhenUserExists()
        {
            await _context.Database.EnsureDeletedAsync();
            int userId = 1;
            Users user1 = new Users
            {
                users_id = 1,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Delete Tests
    }
}
