using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrangularAPI.DTO.Addresses.Responses;
using OrangularAPI.DTO.Addresses.Requests;
using OrangularAPI.Repositories.AddressesRepository;

namespace OrangularAPI.Services.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressesRepository)
        {
            _addressRepository = addressesRepository;
        }
        
        // Retunere en liste med alle adresser
        public async Task<List<AddressResponse>> GetAll()
        {
            // Henter alle addresser fra database
            List<Addresses> addresses = await _addressRepository.GetAll();

            // addresses_id = 1,
            // users_id = 1,
            // address = "TEC Ballerup",
            // zip_code = 2750

            // Retuner listen med addresses
            return addresses == null ? null : addresses.Select(
            a => new AddressResponse
            {
                AddressID = a.addresses_id,
                Address = a.address,
                ZipCode = a.zip_code,
                CityName = null,
                User = null
            }).ToList();
        }

        public async Task<AddressResponse> GetById(int addressesId)
        {
            Addresses addresses = await _addressRepository.GetById(addressesId);

            return addresses == null ? null : new AddressResponse
            {
                AddressID=  addresses.addresses_id,
                Address =  addresses.address,
                ZipCode =  addresses.zip_code,
                CityName = addresses.city_name,
                User = null
            };
        }

        public async Task<AddressResponse> Create(NewAddress input_address)
        {
            Addresses address = new Addresses
            {
           
                users_id = input_address.UserID,
                address = input_address.Address,
                zip_code = input_address.ZipCode,
                city_name = input_address.CityName
            };


            address = await _addressRepository.Create(address);

            return address == null ? null : new AddressResponse
            {
                AddressID =  address.addresses_id,
                Address =  address.address,
                ZipCode =  address.zip_code,
                CityName = null,
                User = null
            };
        }

        public async Task<AddressResponse> Update(int input_address_id, UpdateAddress input_address)
        {
            Addresses address = new Addresses
            {
                users_id = input_address.userID,
                address = input_address.Address,
                zip_code = input_address.ZipCode,
                city_name = input_address.CityName
            };

            address = await _addressRepository.Update(input_address_id, address);



            return address == null ? null : new AddressResponse
            {
                AddressID =  address.addresses_id,
                Address =  address.address,
                ZipCode =  address.zip_code,
                CityName = address.city_name,
                User = null
            };
        }

        public async Task<bool> Delete(int input_address_id)
        {
            Boolean result = await _addressRepository.Delete(input_address_id);

            return result;
        }
    }
}
