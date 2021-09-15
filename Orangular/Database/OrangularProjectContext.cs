using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using LibraryProject.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Orangular.API.Helpers;

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
        public DbSet<Order_Items> Order_Items { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        // ----- Alle entities ----- Victor //

        // ----- Fylder data ind i tabellerne ----- Victor //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<Users>().HasData(
            new Users
            {
                users_id = 1,
                email = "victor@reipur.com",
                role = Role.Admin
            },
            new Users
            {
            });

            // Order_Lists
            modelBuilder.Entity<Order_Lists>().HasData(
            new Order_Lists
            {
            },
            new Order_Lists
            {
            });

            // Order_Items
            modelBuilder.Entity<Order_Items>().HasData(
            new Order_Items
            {
            },
            new Order_Items
            {
            });

            // Addresses
            modelBuilder.Entity<Addresses>().HasData(
            new Addresses
            {
            },
            new Addresses
            {
            });

            // Categories
            modelBuilder.Entity<Categories>().HasData(
            new Categories
            {
            },
            new Categories
            {
            });

            // Products
            modelBuilder.Entity<Products>().HasData(
            new Products
            {
            },
            new Products
            {
            });
        }
        // ----- Fylder data ind i tabellerne ----- Victor //
     }

}
