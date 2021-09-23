using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Addresses.Responses;
using OrangularAPI.DTO.Addresses.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OrangularAPI.Services.AddressService
{
    public interface IAddressService
    {
        Task<List<AddressesResponse>> GetAll();
        Task<AddressesResponse> GetById(int addressesId);
        Task<AddressesResponse> Create(NewAddresses addresses);
        Task<AddressesResponse> Update(int addressesId, UpdateAddresses addresses);
        Task<Boolean> Delete(int addressesId);
    }
}
