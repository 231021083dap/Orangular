using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orangular.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Orangular.Helpers;

namespace Orangular.Database
{
    public class OrangularProjectContext : DbContext
    {
        public OrangularProjectContext() { }
        public OrangularProjectContext(DbContextOptions<OrangularProjectContext> options) : base(options) { }

        // ----- Alle entities ----- Victor //
        // Opretter tabeller
        public DbSet<Users> Users { get; set; } // DbSet fortæller navnet på databasen User
        public DbSet<Order_Lists> Order_Lists { get; set; } // Order_list
        public DbSet<Order_Items> Order_Items { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        // ----- Alle entities ----- Victor //

        // ----- Fylder data ind i tabellerne ----- Victor //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Users>()
            //    .HasOne(a => a.address).WithMa(b => b.user)                
            //    .HasForeignKey<Addresses>(e => e.users_id);
            //modelBuilder.Entity<Users>().ToTable("Users");
            //modelBuilder.Entity<Addresses>().ToTable("Users");

            // --- Users Foreign keys opførsel --- //
            // Forhindre at slette brugeren, hvis bruger har ordre liggende i systemet.
            modelBuilder.Entity<Order_Lists>()
                .HasOne(lambda => lambda.user)
                .WithMany(lambda => lambda.order_lists)
                .OnDelete(DeleteBehavior.Restrict);

            // Når brugeren slettes, slettes tilknyttet addresse også.
            modelBuilder.Entity<Addresses>()
                .HasOne(lambda => lambda.user)
                .WithMany(lambda => lambda.addresses)
                .OnDelete(DeleteBehavior.Cascade);

            // Gør så at en bruger kun kan have en addresse
            modelBuilder.Entity<Addresses>()
                .HasIndex(u => u.users_id)
                .IsUnique();
            // --- Users Foreign keys opførsel --- Victor //



            // --- Order_Lists Foreign keys opførsel --- //
            modelBuilder.Entity<Order_Items>()
               .HasOne(lambda => lambda.order_list)
               .WithMany(lambda => lambda.order_items)
               .OnDelete(DeleteBehavior.Restrict);

            // --- Order_Lists Foreign keys opførsel --- //


            // --- Categories Foreign keys opførsel --- //
            // On delete restrict
            modelBuilder.Entity<Products>()
                .HasOne(lambda => lambda.category)
                .WithMany(lambda => lambda.products)
                .OnDelete(DeleteBehavior.Restrict);
            // --- Categories Foreign keys opførsel --- //

            // --- Products Foreign keys opførsel --- //
            // On delete restrict
            modelBuilder.Entity<Order_Items>()
                .HasOne(lambda => lambda.product)
                .WithMany(lambda => lambda.order_items)
                .OnDelete(DeleteBehavior.Restrict);
            // --- Products Foreign keys opførsel --- //



            // Users
            modelBuilder.Entity<Users>().HasData(
            new Users
            {
                users_id = 1,
                email = "admin@admins.com",
                password = "Passw0rd",
                role = Role.Admin
            },
            new Users
            {
                users_id = 2,
                email = "user@users.com",
                password = "Passw0rd",
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
                description = "Description"
            });
        }
        // ----- Fylder data ind i tabellerne ----- Victor //
     }

}
