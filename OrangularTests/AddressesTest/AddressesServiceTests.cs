using Orangular.Database.Entities;
using OrangularAPI.DTO.Addresses.Responses;
using OrangularAPI.DTO.Addresses.Requests;
using Orangular.Repositories.addresses;
using Orangular.Services.addresses;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Orangular.Tests.AddressesTest
{
    public class AddressesServiceTests
    {
        private readonly AddressesService _sut;
        private readonly Mock<IAddressesRepository> _addressesRepository = new();

        public AddressesServiceTests()
        {
            _sut = new AddressesService(_addressesRepository.Object);
        }

        // ---- GetAll Tests ---- //
           [Fact]
            public async void GetAll_ShouldReturnListOfAddressesResponses_WhenAddressesExist()
            {
                // Arrange
                List<Addresses> Addresses = new List<Addresses>();

                Addresses.Add(new Addresses
                {
                    addresses_id = 1,
                    users_id = 1,
                    address = "TEC Ballerup",
                    zip_code = 2750
                });
                Addresses.Add(new Addresses
                {
                    addresses_id = 2,
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000
                });

                _addressesRepository
                    .Setup(a => a.GetAll())
                    .ReturnsAsync(Addresses);

                // Act
                var result = await _sut.getAll();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
                Assert.IsType<List<AddressesResponse>>(result); // vi forventer en liste af typen AddressesResponse
            } 
        
            [Fact]
            public async void GetAll_ShouldReturnEmptyListOfAddressesResponses_WhenNoAddressesExists()
            {

            // Arrange
            List<Addresses> Addresses = new List<Addresses>();

            _addressesRepository
                .Setup(a => a.GetAll())
                .ReturnsAsync(Addresses);

            // Act
            var result = await _sut.getAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<AddressesResponse>>(result);
            }
        // ---- GetAll Tests ---- //

        // ---- GetById Tests ---- //
            [Fact]
            public async void GetById_ShouldReturnAnAddressesResponse_WhenAddressesExists()
            {
                // Arrange
                int search_id = 1;

                Addresses address = new Addresses
                {
                    addresses_id = 1,
                    users_id = 1,
                    address = "TEC Ballerup",
                    zip_code = 2750
                };

                _addressesRepository
                    .Setup(a => a.GetById(It.IsAny<int>()))
                    .ReturnsAsync(address);

                // Act
                var result = await _sut.getById(search_id);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<AddressesResponse>(result);
                Assert.Equal(address.addresses_id, result.addresses_id);
            }

            [Fact]
            public async void GetById_ShouldReturnNull_WhenAddressesDoesNotExist()
            {
                // Arrange
                int search_id = 1;

                _addressesRepository
                    .Setup(a => a.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
                
                // Act
                var result = await _sut.getById(search_id);

                // Assert
                Assert.Null(result);
            }
        // ---- GetById Tests ---- //

        // ---- Create Tests ---- //
            [Fact]
            public async void Create_ShouldReturnAddressesResponse_WhenCreateIsSuccess()
            {
                // Arrange
                int search_id = 1;

                Addresses addressssss = new Addresses
                {

                };

                NewAddresses newAddress = new NewAddresses
                {
                    users_id = 1,
                    address = "TEC Ballerup",
                    zip_code = 2750
                };

                _addressesRepository
                    .Setup(a => a.Create(It.IsAny<Addresses>()))
                .ReturnsAsync(addressssss);

                // Act
                var result = await _sut.create(newAddress);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<AddressesResponse>(result);

        }
        // ---- Create Tests ---- //

        // ---- Update Tests ---- //
            [Fact]
            public async void Update_ShouldReturnUpdatedAddressesResponse_WhenUpdateIsSuccess()
            {
                // Arrange
                int search_id = 1;

                UpdateAddresses updateAddress = new UpdateAddresses
                {
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000,
                    city_name = "Helsingør"
                };

                Addresses address = new Addresses
                {
                    addresses_id = 1,
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000,
                    city_name = "Helsingør"
                };

                // Opstiller address service typen så den retunere 'address' instancen. 
                _addressesRepository
                    .Setup(lambda => lambda.Update(It.IsAny<int>(), It.IsAny<Addresses>()))
                    .ReturnsAsync(address);

                // Act - vi forventer en autherResponse
                var result = await _sut.update(1, updateAddress);

                // Assert
                Assert.NotNull(result);
                Assert.IsType<AddressesResponse>(result);
                Assert.Equal(search_id, result.addresses_id);
                Assert.Equal(updateAddress.address, result.address);
                Assert.Equal(updateAddress.zip_code, result.zip_code);
            }

            [Fact]
            public async void Update_ShouldReturnNull_WhenAddressesDoesNotExist()
            {
                // Arrange
                int search_id = 1;

                UpdateAddresses updateAddress = new UpdateAddresses
                {
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000,
                    city_name = "Helsingør"
                };

            // Opstiller 
            _addressesRepository
                .Setup(lambda => lambda.Update(It.IsAny<int>(), It.IsAny<Addresses>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _sut.update(1, updateAddress);

            // Assert
            Assert.Null(result);
        }
        // ---- Update Tests ---- //

        // ---- Delete Tests ---- //
            [Fact]
            public async void Delete_ShouldReturnTrue_WhenDeleteIsSuccess()
            {
                // Arrange
                int search_id = 1;

                Addresses address = new Addresses
                {
                    addresses_id = 1,
                    users_id = 2,
                    address = "Hjem Helsingør",
                    zip_code = 3000,
                    city_name = "Helsingør"
                };

                // Opstiller 
                _addressesRepository
                    .Setup(a => a.Delete(It.IsAny<int>()))
                    .ReturnsAsync(true);


                // Act
                var result = await _sut.delete(1);

                // Assert
                Assert.True(result);
        }
        // ---- Delete Tests ---- //
    }
}