using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrangularAPI.Repositories.addresses;
using OrangularAPI.DTO.Addresses.Responses;
using OrangularAPI.DTO.Addresses.Requests;

namespace OrangularAPI.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly IAddressesRepository _addressRepository;

        public AddressService(IAddressesRepository addressesRepository)
        {
            _addressRepository = addressesRepository;
        }
        
        // Retunere en liste med alle adresser
        public async Task<List<AddressesResponse>> GetAll()
        {
            // Henter alle addresser fra database
            List<Addresses> addresses = await _addressRepository.GetAll();

            // addresses_id = 1,
            // users_id = 1,
            // address = "TEC Ballerup",
            // zip_code = 2750

            // Retuner listen med addresses
            return addresses == null ? null : addresses.Select(
            a => new AddressesResponse
            {
                addresses_id = a.addresses_id,
                address = a.address,
                zip_code = a.zip_code,
                city_name = null,
                Users = null
            }).ToList();
        }

        public async Task<AddressesResponse> GetById(int addressesId)
        {
            Addresses addresses = await _addressRepository.GetById(addressesId);

            return addresses == null ? null : new AddressesResponse
            {
                addresses_id =  addresses.addresses_id,
                address =  addresses.address,
                zip_code =  addresses.zip_code,
                city_name = addresses.city_name,
                Users = null

            };
        }

        public async Task<AddressesResponse> Create(NewAddresses input_address)
        {
            Addresses address = new Addresses
            {
           
                users_id = input_address.users_id,
                address = input_address.address,
                zip_code = input_address.zip_code,
                city_name = input_address.city_name
            };


            address = await _addressRepository.Create(address);

            return address == null ? null : new AddressesResponse
            {
                addresses_id =  address.addresses_id,
                address =  address.address,
                zip_code =  address.zip_code,
                city_name = null,
                Users = null
            };
        }

        public async Task<AddressesResponse> Update(int input_address_id, UpdateAddresses input_address)
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
