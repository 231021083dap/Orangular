using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orangular.Repositories.addresses;
using Orangular.DTO.Addresses.Responses;
using Orangular.DTO.Addresses.Requests;

namespace Orangular.Services.addresses
{
    public class AddressesService : IAddressesService
    {
        private readonly IAddressesRepository _addressRepository;

        public AddressesService(IAddressesRepository addressesRepository)
        {
            _addressRepository = addressesRepository;
        }
        
        // Retunere en liste med alle adresser
        public async Task<List<AddressesResponse>> getAll()
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

        public async Task<AddressesResponse> getById(int addressesId)
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

        public async Task<AddressesResponse> create(NewAddresses input_address)
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

        public async Task<AddressesResponse> update(int input_address_id, UpdateAddresses input_address)
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

        public async Task<bool> delete(int input_address_id)
        {
            Boolean result = await _addressRepository.Delete(input_address_id);

            return result;
        }
    }
}
