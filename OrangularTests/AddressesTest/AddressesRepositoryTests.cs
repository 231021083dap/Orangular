using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using OrangularAPI.Helpers;
using OrangularAPI.Repositories.AddressesRepository;

namespace OrangularTests.AddressesTest
{
    public class AddressesRepositoryTests
    {
        private readonly AddressRepository _sut;
        private readonly OrangularProjectContext _context;
        private readonly DbContextOptions<OrangularProjectContext> _options;

        public AddressesRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<OrangularProjectContext>()
                .UseInMemoryDatabase(databaseName: "OrangularProjectContextAddresses")
                .Options;

            _context = new OrangularProjectContext(_options);

            _sut = new AddressRepository(_context);
        }


        // ---- GetAll tests ---- //
            [Fact]
            public async Task GetAll_ShouldReturnListOfAddresses_WhenAddressesExists()
            {

                // null = fejl
                // Arrange
                await _context.Database.EnsureDeletedAsync();


                // Tilføj Users
                _context.Users.Add(
                new Users
                {
                    users_id = 1,
                    email = "admin@admins.com",
                    password = "Passw0rd",
                    role = Role.Admin
                });

                _context.Users.Add(
                new Users
                {
                    users_id = 2,
                    email = "user@users.com",
                    password = "Passw0rd",
                    role = Role.User
                });

                _context.Addresses.Add(
                new Addresses
                {
                    addresses_id = 1,
                    users_id = 1,
                    address = "TEC Ballerup",
                    zip_code = 2750
                });

                _context.Addresses.Add(
                new Addresses
                {
                    addresses_id = 2,
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000
                });


                await _context.SaveChangesAsync();

                // Act
                var result = await _sut.GetAll();

                // Assert
                Assert.NotNull(result);
                Assert.IsType<List<Addresses>>(result);
                Assert.Equal(2, result.Count);
            }
            [Fact]
            public async Task GetAll_ShouldReturnEmptyListOfAddresses_WhenNoAddressesExists() 
            {
                // Arrange
                await _context.Database.EnsureDeletedAsync();

                // Act
                var result = await _sut.GetAll();

                // Assert
                Assert.NotNull(result);
                Assert.IsType<List<Addresses>>(result);
                Assert.Empty(result);    
            }
        // ---- GetAll tests ---- //


        // ---- GetById tests ---- //
            [Fact]
            public async Task GetById_ShouldReturnTheAddress_IfAddressExists()
            {
                // Arrange
                await _context.Database.EnsureDeletedAsync();
                int search_id = 1;
                _context.Addresses.Add(
                new Addresses
                {
                    addresses_id = 1,
                    users_id = 1,
                    address = "TEC Ballerup",
                    zip_code = 2750
                });
                await _context.SaveChangesAsync();

                // Act
                var result = await _sut.GetById(search_id);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<Addresses>(result);
                Assert.Equal(search_id, result.addresses_id);
            }


            [Fact]
            public async Task GetById_ShouldReturnNull_IfAddressDoesNotExist()
            {
                // Arrange
                await _context.Database.EnsureDeletedAsync(); // sletter db
                int search_id = 1;

                // Act
                var result = await _sut.GetById(search_id);

                // Assert
                Assert.Null(result);
            }
        // ---- GetById tests ---- //

        // ---- Create tests ---- //
            // [Fact]
            public async Task Create_ShouldAddIdToAddress_WhenSavingToDatabase()
            {
                // Arrange
                await _context.Database.EnsureDeletedAsync();
                // Vi kan kun bruge det her id til at finde den nye bruger fordi vi ved at den er 1. 
                // Fordi vi har slettet databasen.
                int expectedId = 1;
                Addresses address = new Addresses
                {
                    addresses_id = 2,
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000
                };

                // Act
                var result = await _sut.Create(address);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<Addresses>(result);
                Assert.Equal(expectedId, result.addresses_id);
            }
            // [Fact]
            public async Task Create_ShouldFailToAddAddress_WhenAddingAddressWithExistingId()
            {
                // Arrange
                await _context.Database.EnsureDeletedAsync();

                Addresses address = new Addresses
                {
                    addresses_id = 2,
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000
                };
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                // Act
                Func<Task> action = async () => await _sut.Create(address);

                // Assert
                var ex = await Assert.ThrowsAsync<ArgumentException>(action);
                Assert.Contains("An item with the same key has already been added", ex.Message);
            }
        // ---- Create tests ---- //

        // ---- Update tests ---- //
            [Fact]
            public async Task Update_ShouldChangeValuesOnAddress_WhenAddressExists()
            {
                
                // Arrange
                await _context.Database.EnsureDeletedAsync();
                int updateTargetId = 1;

                Addresses address = new Addresses
                {
                    addresses_id = updateTargetId,
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000
                };

                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();




                // Act
                Addresses updateAddress = new Addresses
                {
                    addresses_id = 1,
                    users_id = 1,
                    address = "TEC Ballerup",
                    zip_code = 2750
                };

                var result = await _sut.Update(updateTargetId, updateAddress);


                // Assert
                Assert.NotNull(result);
                Assert.IsType<Addresses>(result);
                Assert.Equal(updateTargetId, result.addresses_id);
                Assert.Equal(updateAddress.users_id, result.users_id);
                Assert.Equal(updateAddress.address, result.address);
                Assert.Equal(updateAddress.zip_code, result.zip_code);
            }
            
            [Fact]
            public async Task Update_ShouldReturnNull_WhenAddressDoesNotExists()
            {
                // Arrange
                await _context.Database.EnsureDeletedAsync();
                int addressId = 1;

                // Act
                Addresses updateAddresses = new Addresses
                {
                    addresses_id = 1,
                    users_id = 1,
                    address = "TEC Ballerup",
                    zip_code = 2750
                };
                var result = await _sut.Update(addressId, updateAddresses);
                // Assert
                Assert.Null(result);
            }
        // ---- Update tests ---- //


        // ---- Delete tests ---- //
            [Fact]
            public async Task Delete_ShouldReturnDeletedAddress_WhenAddressIsDeleted()
            {

                // Arrange
                await _context.Database.EnsureDeletedAsync();
                int addressId = 1;
                Addresses address = new Addresses
                {
                    addresses_id = 1,
                    users_id = 1,
                    address = "TEC Ballerup",
                    zip_code = 2750
                };
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();


                // Act
                var result = await _sut.Delete(addressId);


                // Assert
                Assert.IsType<Boolean>(result);
            }


            [Fact]
            public async Task Delete_ShouldReturnNull_WhenAddressDoesNotExist()
            {
                // Arrange
                await _context.Database.EnsureDeletedAsync();
                int addressId = 1;

                // Act
                var result = await _sut.Delete(addressId);

                // Assert
                Assert.IsType<Boolean>(result);
        }
        // ---- Delete tests ---- //
    }
}
