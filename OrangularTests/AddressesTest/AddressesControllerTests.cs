using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Addresses.Responses;
using OrangularAPI.DTO.Addresses.Requests;
using OrangularAPI.Repositories.addresses;
using OrangularAPI.Services.addresses;
using Moq;
using System.Collections.Generic;
using Xunit;
using OrangularAPI.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace OrangularTests.AddressesTest
{
    public class AddressesControllerTests
    {
        private readonly AddressesController _sut;

        private readonly Mock<IAddressesService> _addressesService = new();

        public AddressesControllerTests()
        {
            _sut = new AddressesController(_addressesService.Object);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode200_WhenDataExists()
        {
            // Arrange
            List<AddressesResponse> addresses = new();

            addresses.Add(new AddressesResponse
            {
                addresses_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            });

            addresses.Add(new AddressesResponse
            {
                addresses_id = 2,
                address = "Kusør",
                zip_code = 1234,
                city_name = "Kagerup"
            });


            _addressesService.Setup(s => s.getAll()).ReturnsAsync(addresses);


            // Act
            var result = await _sut.GetAll();

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode204_WhenNoElementExists()
        {
            // Arrange
            List<AddressesResponse> addresses = new();

            _addressesService.Setup(s => s.getAll()).ReturnsAsync(addresses);

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
            _addressesService.Setup(s => s.getAll()).ReturnsAsync(() => null);
            // Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAll_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            _addressesService.Setup(s => s.getAll()).ReturnsAsync(() => throw new System.Exception("This is an exeption"));
            // Act
            var result = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode200_WhenDataExists()
        {
            // Arrange
            AddressesResponse address = new AddressesResponse
            {
                addresses_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };


            _addressesService.Setup(s => s.getById(1)).ReturnsAsync(address);


            // Act
            var result = await _sut.GetById(1);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetById_ShouldReturnStatusCode404_WhenAddressDoesNotExist()
        {
            // Arrange
            AddressesResponse address = new AddressesResponse
            {
                addresses_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };


            _addressesService.Setup(s => s.getById(1)).ReturnsAsync(() => null);


            // Act
            var result = await _sut.GetById(1);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async void GetById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            AddressesResponse address = new AddressesResponse
            {
                addresses_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };


            _addressesService.Setup(s => s.getById(1)).ReturnsAsync(() => throw new System.Exception("This is an exeption"));


            // Act
            var result = await _sut.GetById(1);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Create_ShouldReturnStatusCode200_WhenDataIsCreated()
        {
            // Arrange
            NewAddresses newAddress = new NewAddresses
            {
                users_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };

            AddressesResponse addressResponse = new AddressesResponse
            {
                addresses_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };
            _addressesService.Setup(s => s.create(newAddress)).ReturnsAsync(addressResponse);

            // Act
            var result = await _sut.Create(newAddress);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);


        }

        [Fact]
        public async void Create_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            NewAddresses newAddress = new NewAddresses
            {
                users_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };

            _addressesService.Setup(s => s.create(It.IsAny<NewAddresses>())).ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Create(newAddress);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void Update_ShouldReturnStatusCode200_WhenDataIsSaved()
        {
            // Arrange
            UpdateAddresses updateAddress = new UpdateAddresses
            {
                users_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };

            AddressesResponse addressResponse = new AddressesResponse
            {
                addresses_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };

            _addressesService.Setup(s => s.update(1,updateAddress)).ReturnsAsync(addressResponse);

            // Act
            var result = await _sut.Update(1,updateAddress);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);


        }

        [Fact]
        public async void Update_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            UpdateAddresses updateAddress = new UpdateAddresses
            {
                users_id = 1,
                address = "Vinkelvej",
                zip_code = 2800,
                city_name = "Lyngby"
            };

            _addressesService.Setup(s => s.update(It.IsAny<int>(), It.IsAny<UpdateAddresses>())).ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Update(1, updateAddress);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Delete_ShouldReturnStatusCode204_WhenAddressIsDeleted()
        {
            // Arrange
            int search_id = 1;

            _addressesService.Setup(s => s.delete(It.IsAny<int>())).ReturnsAsync(() => true);

            // Act
            var result = await _sut.Delete(1);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Delete_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            // Arrange
            int search_id = 1;

            _addressesService.Setup(s => s.delete(It.IsAny<int>())).ReturnsAsync(() => throw new System.Exception("This is an exception"));

            // Act
            var result = await _sut.Delete(1);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
