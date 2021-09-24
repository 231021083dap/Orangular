using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrangularAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using OrangularAPI.Helpers;

namespace OrangularAPI.Database
{
    public class OrangularProjectContext : DbContext
    {
        public OrangularProjectContext() { }
        public OrangularProjectContext(DbContextOptions<OrangularProjectContext> options) : base(options) { }

        // ----- Alle entities ----- Victor //
        // Opretter tabeller
        public DbSet<User> User { get; set; } // DbSet fortæller navnet på databasen User
        public DbSet<OrderList> OrderList { get; set; } // Order_list
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Address> Address { get; set; }
        // ----- Alle entities ----- Victor //

        // ----- Fylder data ind i tabellerne ----- Victor //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Users>()
            //    .HasOne(a => a.address).WithMa(b => b.user)                
            //    .HasForeignKey<Addresses>(e => e.users_id);
            //modelBuilder.Entity<Users>().ToTable("Users");
            //modelBuilder.Entity<Addresses>().ToTable("Users");

            //// --- Users Foreign keys opførsel --- //
            //// Forhindre at slette brugeren, hvis bruger har ordre liggende i systemet.
            //modelBuilder.Entity<OrderList>()
            //    .HasOne(lambda => lambda.User)
            //    .WithMany(lambda => lambda.OrderList)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// Når brugeren slettes, slettes tilknyttet addresse også.
            //modelBuilder.Entity<Address>()
            //    .HasOne(lambda => lambda.User)
            //    .WithMany(lambda => lambda.Address)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// Gør så at en bruger kun kan have en addresse
            //modelBuilder.Entity<Address>()
            //    .HasIndex(u => u.UserId)
            //    .IsUnique();
            //// --- Users Foreign keys opførsel --- Victor //



            //// --- Order_Lists Foreign keys opførsel --- //
            //modelBuilder.Entity<OrderItem>()
            //   .HasOne(lambda => lambda.OrderList)
            //   .WithMany(lambda => lambda.OrderItem)
            //   .OnDelete(DeleteBehavior.Restrict);

            //// --- Order_Lists Foreign keys opførsel --- //


            //// --- Categories Foreign keys opførsel --- //
            //// On delete restrict
            //modelBuilder.Entity<Product>()
            //    .HasOne(lambda => lambda.Category)
            //    .WithMany(lambda => lambda.Product)
            //    .OnDelete(DeleteBehavior.Restrict);
            //// --- Categories Foreign keys opførsel --- //

            //// --- Products Foreign keys opførsel --- //
            //// On delete restrict
            //modelBuilder.Entity<OrderItem>()
            //    .HasOne(lambda => lambda.Product)
            //    .WithMany(lambda => lambda.OrderItem)
            //    .OnDelete(DeleteBehavior.Restrict);
            //// --- Products Foreign keys opførsel --- //



            // Users
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Email = "admin@admins.com",
                Password = "Passw0rd",
                Role = Role.Admin,
            },
            new User
            {
                Id = 2,
                Email = "user@users.com",
                Password = "Passw0rd",
                Role = Role.User
            });

            // Addresses
            modelBuilder.Entity<Address>().HasData(
            new Address
            {
                Id = 1,
                AddressName = "TEC Ballerup",
                ZipCode = 2750,
                CityName = "Ballerup",
                UserId = 1,
            },
            new Address
            {
                Id = 2,
                AddressName = "Hjem Helsingør",
                ZipCode = 3000,
                CityName = "Helsingør",
                UserId = 2
            });

            // Order_Lists
            modelBuilder.Entity<OrderList>().HasData(
            new OrderList
            {
                Id = 1,
                OrderDateTime = DateTime.Now,
                UserId = 1
            });

            // Order_Items
            modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem
            {
                Id = 1,
                Price = 750000,     // F.eks to hunde købt til 7500 kr stykket
                Quantity = 2,
                OrderListId = 1,    // reference til køberen
                ProductId = 1       // reference til produktet (hunden)
            });

            // Categories
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                CategoryName = "hund"
            });

            // Products
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                BreedName = "chefer hund",
                Price = 750000,
                Weight = 35000,
                Gender = "male",
                Description = "Description",
                CategoryId = 1
            });
        }
        // ----- Fylder data ind i tabellerne ----- Victor //
     }

}
