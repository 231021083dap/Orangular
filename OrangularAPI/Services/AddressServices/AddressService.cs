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
                addressID = a.addresses_id,
                address = a.address,
                zipCode = a.zip_code,
                cityName = null,
                users = null
            }).ToList();
        }

        public async Task<AddressResponse> GetById(int addressesId)
        {
            Addresses addresses = await _addressRepository.GetById(addressesId);

            return addresses == null ? null : new AddressResponse
            {
                addressID=  addresses.addresses_id,
                address =  addresses.address,
                zipCode =  addresses.zip_code,
                cityName = addresses.city_name,
                users = null
            };
        }

        public async Task<AddressResponse> Create(NewAddress input_address)
        {
            Addresses address = new Addresses
            {
           
                users_id = input_address.userID,
                address = input_address.address,
                zip_code = input_address.zipCode,
                city_name = input_address.cityName
            };


            address = await _addressRepository.Create(address);

            return address == null ? null : new AddressResponse
            {
                addressID =  address.addresses_id,
                address =  address.address,
                zipCode =  address.zip_code,
                cityName = null,
                users = null
            };
        }

        public async Task<AddressResponse> Update(int input_address_id, UpdateAddress input_address)
        {
            Addresses address = new Addresses
            {
                users_id = input_address.users_id,
                address = input_address.address,
                zip_code = input_address.zip_code,
                city_name = input_address.city_name
            };

            address = await _addressRepository.Update(input_address_id, address);



            return address == null ? null : new AddressesResponse
            {
                addresses_id =  address.addresses_id,
                address =  address.address,
                zip_code =  address.zip_code,
                city_name = address.city_name,
                Users = null
            };
        }

        public async Task<bool> Delete(int input_address_id)
        {
            Boolean result = await _addressRepository.Delete(input_address_id);

            return result;
        }
    }
}
