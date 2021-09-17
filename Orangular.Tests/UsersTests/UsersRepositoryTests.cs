using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using Orangular.Repositories.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangular.Tests.UsersTests
{
    class UsersRepositoryTests
    {
        private readonly UserRepository _sut;
        private readonly OrangularProjectContext _context;
        private readonly DbContextOptions<OrangularProjectContext> _options;
        public UsersRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<OrangularProjectContext>()
                .UseInMemoryDatabase(databaseName "")
        }
    }
}
