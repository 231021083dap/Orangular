using Orangular.Database.Entities;
using Orangular.DTO.Addresses.Responses;
using Orangular.DTO.Addresses.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Orangular.Services.addresses
{
    public interface IAddressesService
    {
        Task<List<AddressesResponse>> getAll();
        Task<AddressesResponse> getById(int addressesId);
        Task<AddressesResponse> create(NewAddresses addresses);
        Task<AddressesResponse> update(int addressesId, UpdateAddresses addresses);
        Task<Boolean> delete(int addressesId);
    }
}
