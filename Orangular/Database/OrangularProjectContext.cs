using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using LibraryProject.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Orangular.Database.Entities
{
    public class OrangularProjectContext : DbContext
    {
        public OrangularProjectContext() { }
        public OrangularProjectContext(DbContextOptions<OrangularProjectContext> options) : base(options) { }

        // ----- Alle entities ----- Victor //
        // Opretter tabeller
        public DbSet<Users> Users { get; set; }
        public DbSet<Order_Lists> Order_Lists { get; set; }
        public DbSet<Orders_Items> Order_Items { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        // ----- Alle entities ----- Victor //
    }
}
