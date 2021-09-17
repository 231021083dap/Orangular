using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.addresses
{
    public class AddressesRespository : IAddressesRepository
    {
        private readonly OrangularProjectContext _context;

        // Bruges af AddressesRespositoryTests - xunit
        public AddressesRespository(OrangularProjectContext context)
        {
            _context = context;
        }

        public async Task<List<Addresses>> getAll()
        {
            // Retunere alle addresser
            return await _context.Addresses
            .ToListAsync();
        }

        public Task<Addresses> getById(int addressesId)
        {
            return await _context.Addresses
                .Include(lamdaVar => lamdaVar.Books)
                .FirstOrDefaultAsync(lamdaVar => lamdaVar.Id == authorId);
        }

        public Task<Addresses> create(Addresses addresses)
        {
            throw new NotImplementedException();
        }

        public Task<bool> delete(int addressesId)
        {
            throw new NotImplementedException();
        }

        public Task<Addresses> update(int addressesId, Addresses addresses)
        {
            throw new NotImplementedException();
        }
    }
}
