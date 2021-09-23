using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.AddressesRepository
{
    public interface IAddressRepository
    {
        Task<List<Addresses>> GetAll();
        Task<Addresses> GetById(int addressesId);
        Task<Addresses> Create(Addresses addresses);
        Task<Addresses> Update(int addressesId, Addresses addresses);
        Task<bool> Delete(int addressesId);
    }
}