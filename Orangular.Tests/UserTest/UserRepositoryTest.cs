using Microsoft.EntityFrameworkCore;
using Orangular.Database;
using Orangular.Database.Entities;
using Orangular.Repositories.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Orangular.Tests.UserTest
{
   public class UserRepositoryTest
    {
        private readonly UserRepository _sut;
        private readonly OrangularProjectContext _context;
        private readonly DbContextOptions<OrangularProjectContext> _options;
        public UserRepositoryTest()
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
        // GetByEmail Tests
        [Fact]
        public async Task GetByEmail_ShouldReturnEmail_IfEmailExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            string userEmail = "Test1@Mail.com";
            _context.Users.Add(new Users
            {
                users_id = 1,
                email = userEmail,
                password = "Passw0rd",
                role = Helpers.Role.Admin
            });
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.GetByEmail(userEmail);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Users>(result);
            Assert.Equal(userEmail, result.email);
        }
        [Fact]
        public async Task GetByEmail_ShouldReturnNull_IfEmailDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            string userEmail = "Test1@Mail.com";
            // Act
            var result = await _sut.GetByEmail(userEmail);
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
        public async Task Create_ShouldFailToAddUser_WhenPasswordAndOrEmailIsNull()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            Users user = new Users
            {
                users_id = 1,
                role = Helpers.Role.User
            };
            // Act
            Func<Task> action = async () => await _sut.Create(user);
            // Assert
            var ex = await Assert.ThrowsAsync<Exception>(action);
            Assert.Contains("You must enter an email and a password to create a user", ex.Message);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Update Tests
        [Fact]
        public async Task Update_ShouldChangeValuesOnUser_WhenUserExists()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int userId = 1;
            Users user = new Users
            {
                users_id = userId,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            Users userUpdate = new Users
            {
                users_id = userId,
                email = "est1@Mail.com",
                password = "assw0rd",
                role = Helpers.Role.Admin
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.Update(userId, userUpdate);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Users>(result);
            Assert.Equal(userId, result.users_id);
            Assert.Equal(userUpdate.email, result.email);
            Assert.Equal(userUpdate.password, result.password);
            Assert.Equal(userUpdate.role, result.role);
        }
        [Fact]
        public async Task Update_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int userId = 1;
            Users userUpdate = new Users
            {
                users_id = userId,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            // Act
            var result = await _sut.Update(userId, userUpdate);
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task Update_ShouldFailToUpdateUser_WhenUpdatingEmailToExistingEmail()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int user1Id = 1;
            Users user1 = new Users
            {
                users_id = user1Id,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            Users user2 = new Users
            {
                users_id = 2,
                email = "Test2@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.Admin
            };
            _context.Users.Add(user1); 
            _context.Users.Add(user2);
            await _context.SaveChangesAsync();
            Users user1Update = new Users
            {
                users_id = user1Id,
                email = "Test2@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            // Act
            Func<Task> action = async () => await _sut.Update(user1Id, user1Update);
            // Assert
            var ex = await Assert.ThrowsAsync<Exception>(action);
            Assert.Contains("Email " + user2.email + " is already taken", ex.Message);
        }
        // -----------------------------------------------------------------------------------------------------------------------
        // Delete Tests
        [Fact]
        public async Task Delete_ShouldReturnDeletedUser_WhenUserIsDeleted()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int userId = 1;
            Users user = new Users
            {
                users_id = userId,
                email = "Test1@Mail.com",
                password = "Passw0rd",
                role = Helpers.Role.User
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // Act
            var result = await _sut.Delete(userId);
            var users = await _sut.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Users>(result);
            Assert.Equal(userId, result.users_id);
            Assert.Empty(users);
        }
        [Fact]
        public async Task Delete_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            int userId = 1;
            // Act
            var result = await _sut.Delete(userId);
            // Assert
            Assert.Null(result);
        }

    }
}
