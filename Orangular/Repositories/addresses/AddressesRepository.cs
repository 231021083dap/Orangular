
using Microsoft.EntityFrameworkCore;
using Orangular.Database;
using Orangular.Database.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.addresses
{

    public interface IAddressesRepository
    {
        Task<List<Addresses>> GetAll();
        Task<Addresses> GetById(int addressesId);
        Task<Addresses> Create(Addresses addresses);
        Task<Addresses> Update(int addressesId, Addresses addresses);
        Task<bool> Delete(int addressesId);
    }


    public class AddressesRepository : IAddressesRepository
    {
        private readonly OrangularProjectContext _context;

        // Bruges af AddressesRespositoryTests - xunit
        public AddressesRepository(OrangularProjectContext context)
        {
            _context = context;
        }

        public async Task<List<Addresses>> GetAll()
        {
            // Retunere en liste af alle objekter af typen Addresses
            return await _context.Addresses
            .Include(users => users.user) // henter user objekt i forhold til foreign key
            .ToListAsync();
        }

        public async Task<Addresses> GetById(int addressesId)
        {
            // retunere et objekt af typen Addresses med id'et addressesId
            return await _context.Addresses
                .FirstOrDefaultAsync(lambdaVar => lambdaVar.addresses_id == addressesId);
        }

        public async Task<Addresses> Create(Addresses addresses)
        {
            // Retunere samme input xD
            _context.Addresses.Add(addresses);
            await _context.SaveChangesAsync();
            return addresses;
        }

        public async Task<Addresses> Update(int updateTargetAddressId, Addresses updateThisAddress)
        {
            Addresses updatedAddress = await _context.Addresses
                .FirstOrDefaultAsync(address => address.addresses_id == updateTargetAddressId);

            if (updatedAddress != null)
            {
                updatedAddress.users_id = updateThisAddress.users_id;
                updatedAddress.address = updateThisAddress.address;
                updatedAddress.zip_code = updateThisAddress.zip_code;
                await _context.SaveChangesAsync();

                return updatedAddress;
            }

            return null;

        }
    
        public async Task<bool> Delete(int addressId)
        {

            Addresses address = await _context.Addresses.FirstOrDefaultAsync(
                address => address.addresses_id == addressId);

            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
