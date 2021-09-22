﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orangular.Database;
using Orangular.Database.Entities;

namespace Orangular.Migrations
{
    [DbContext(typeof(OrangularProjectContext))]
    [Migration("20210921102706_NewBase")]
    partial class NewBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Orangular.Database.Entities.Addresses", b =>
                {
                    b.Property<int>("addresses_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("city_name")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("users_id")
                        .HasColumnType("int");

                    b.Property<int?>("users_id1")
                        .HasColumnType("int");

                    b.Property<string>("zip_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("addresses_id");

                    b.HasIndex("users_id")
                        .IsUnique();

                    b.HasIndex("users_id1");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            addresses_id = 1,
                            address = "TEC Ballerup",
                            users_id = 1,
                            zip_code = "2750"
                        },
                        new
                        {
                            addresses_id = 2,
                            address = "Hjem Helsingør",
                            users_id = 2,
                            zip_code = "3000"
                        });
                });

            modelBuilder.Entity("Orangular.Database.Entities.Categories", b =>
                {
                    b.Property<int>("categories_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("categories_id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            categories_id = 1,
                            category_name = "hund"
                        });
                });

            modelBuilder.Entity("Orangular.Database.Entities.Order_Items", b =>
                {
                    b.Property<int>("order_items_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("order_lists_id")
                        .HasColumnType("int");

                    b.Property<int?>("order_lists_id1")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("products_id")
                        .HasColumnType("int");

                    b.Property<int?>("products_id1")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("order_items_id");

                    b.HasIndex("order_lists_id1");

                    b.HasIndex("products_id1");

                    b.ToTable("Order_Items");

                    b.HasData(
                        new
                        {
                            order_items_id = 1,
                            order_lists_id = 1,
                            price = 750000,
                            products_id = 1,
                            quantity = 2
                        });
                });

            modelBuilder.Entity("Orangular.Database.Entities.Order_Lists", b =>
                {
                    b.Property<int>("order_lists_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("order_date_time")
                        .HasColumnType("datetime2");

                    b.Property<int>("users_id")
                        .HasColumnType("int");

                    b.Property<int?>("users_id1")
                        .HasColumnType("int");

                    b.HasKey("order_lists_id");

                    b.HasIndex("users_id1");

                    b.ToTable("Order_Lists");

                    b.HasData(
                        new
                        {
                            order_lists_id = 1,
                            order_date_time = new DateTime(2021, 9, 21, 12, 27, 5, 786, DateTimeKind.Local).AddTicks(1521),
                            users_id = 0
                        });
                });

            modelBuilder.Entity("Orangular.Database.Entities.Products", b =>
                {
                    b.Property<int>("products_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("breed_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("categories_id")
                        .HasColumnType("int");

                    b.Property<int?>("categorycategories_id")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("products_id");

                    b.HasIndex("categorycategories_id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            products_id = 1,
                            breed_name = "chefer hund",
                            categories_id = 0,
                            description = "Description",
                            gender = "male",
                            price = 750000,
                            weight = 35000
                        });
                });

            modelBuilder.Entity("Orangular.Database.Entities.Users", b =>
                {
                    b.Property<int>("users_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("users_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            users_id = 1,
                            email = "admin@admins.com",
                            password = "Passw0rd",
                            role = 1
                        },
                        new
                        {
                            users_id = 2,
                            email = "user@users.com",
                            password = "Passw0rd",
                            role = 2
                        });
                });

            modelBuilder.Entity("Orangular.Database.Entities.Addresses", b =>
                {
                    b.HasOne("Orangular.Database.Entities.Users", "user")
                        .WithMany("addresses")
                        .HasForeignKey("users_id1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("user");
                });

            modelBuilder.Entity("Orangular.Database.Entities.Order_Items", b =>
                {
                    b.HasOne("Orangular.Database.Entities.Order_Lists", "order_list")
                        .WithMany("order_items")
                        .HasForeignKey("order_lists_id1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Orangular.Database.Entities.Products", "product")
                        .WithMany("order_items")
                        .HasForeignKey("products_id1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("order_list");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Orangular.Database.Entities.Order_Lists", b =>
                {
                    b.HasOne("Orangular.Database.Entities.Users", "user")
                        .WithMany("order_lists")
                        .HasForeignKey("users_id1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("user");
                });

            modelBuilder.Entity("Orangular.Database.Entities.Products", b =>
                {
                    b.HasOne("Orangular.Database.Entities.Categories", "category")
                        .WithMany("products")
                        .HasForeignKey("categorycategories_id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("category");
                });

            modelBuilder.Entity("Orangular.Database.Entities.Categories", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Orangular.Database.Entities.Order_Lists", b =>
                {
                    b.Navigation("order_items");
                });

            modelBuilder.Entity("Orangular.Database.Entities.Products", b =>
                {
                    b.Navigation("order_items");
                });

            modelBuilder.Entity("Orangular.Database.Entities.Users", b =>
                {
                    b.Navigation("addresses");

                    b.Navigation("order_lists");
                });
#pragma warning restore 612, 618
        }
    }
}
