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
                email = "admin@admins.com",
                role = Role.Admin
            },
            new Users
            {
                users_id = 2,
                email = "user@users.com",
                role = Role.User
            });

            // Addresses
            modelBuilder.Entity<Addresses>().HasData(
            new Addresses
            {
                addresses_id = 1,
                users_id = 1,
                address = "TEC Ballerup",
                zip_code = 2750
            },
            new Addresses
            {
                addresses_id = 2,
                users_id = 2,
                address = "Hjem Helsingør",
                zip_code = 3000
            });

            // Order_Lists
            modelBuilder.Entity<Order_Lists>().HasData(
            new Order_Lists
            {
                order_lists_id = 1,
                order_date_time = DateTime.Now
            });

            // Order_Items
            modelBuilder.Entity<Order_Items>().HasData(
            new Order_Items
            {
                order_items_id = 1,
                order_lists_id = 1,
                products_id = 1,
                price = 750000,
                quantity = 2
            });

            // Categories
            modelBuilder.Entity<Categories>().HasData(
            new Categories
            {
                categories_id = 1,
                category_name = "hund"
            });

            // Products
            modelBuilder.Entity<Products>().HasData(
            new Products
            {
                products_id = 1,
                breed_name = "chefer hund",
                price = 750000,
                weight = 35000,
                gender = "male",
                description =
                @"
                Tamhunden (Canis lupus familiaris) er det husdyr,
                som tidligst blev tæmmet af mennesket,
                og som derfor har den længste historie til fælles med os.
                Den har gennem historien været brugt til jagt, som vagthund,
                krigshund (eks. anti-tank-hunde), sporhund, redningshund, eller som 'følgesvend'.
                Desuden som servicehund for blinde og handicappede, som politi- og redningshund, 
                som narkohund eller som terapihund.
                Hunde kan også lugte sig frem til kræftsvulster,[2] termitangreb og forudsige epilepsianfald.
                "
            });
        }
        // ----- Fylder data ind i tabellerne ----- Victor //
     }

}
