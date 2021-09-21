using Orangular.Database.Entities;
using Orangular.DTO.Addresses.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Orangular.Services.addresses
{
    interface IAddressesService
    {
        Task<List<AddressesResponse>> getAll();
        Task<AddressesResponse> getById(int addressesId);
        Task<AddressesResponse> create(Addresses addresses);
        Task<AddressesResponse> update(int addressesId, Addresses addresses);
        Task<bool> delete(int addressesId);
    }
}
