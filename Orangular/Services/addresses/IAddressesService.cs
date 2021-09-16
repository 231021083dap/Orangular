using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.addresses
{
    interface IAddressesService
    {
        Task<List<Addresses>> getAll();
        Task<Addresses> getById(int addressesId);
        Task<Addresses> create(Addresses addresses);
        Task<Addresses> update(int addressesId, Addresses addresses);
        Task<bool> delete(int addressesId);
    }
}
