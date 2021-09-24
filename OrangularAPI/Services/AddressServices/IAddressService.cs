using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Addresses.Responses;
using OrangularAPI.DTO.Addresses.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OrangularAPI.Services.AddressServices
{
    public interface IAddressService
    {
        Task<List<AddressResponse>> GetAll();
        Task<AddressResponse> GetById(int addressID);
        Task<AddressResponse> Create(NewAddress address);
        Task<AddressResponse> Update(int addressesID, UpdateAddress address);
        Task<Boolean> Delete(int addressID);
    }
}
