using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orangular.Migrations
{
    public partial class NewBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categories_id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    order_items_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_lists_id = table.Column<int>(type: "int", nullable: false),
                    products_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.order_items_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    products_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories_id = table.Column<int>(type: "int", nullable: false),
                    breed_name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.products_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    users_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.users_id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    addresses_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    users_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    zip_code = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    city_name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    users_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.addresses_id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_users_id1",
                        column: x => x.users_id1,
                        principalTable: "Users",
                        principalColumn: "users_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Lists",
                columns: table => new
                {
                    order_lists_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    users_id = table.Column<int>(type: "int", nullable: false),
                    order_date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    users_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Lists", x => x.order_lists_id);
                    table.ForeignKey(
                        name: "FK_Order_Lists_Users_users_id1",
                        column: x => x.users_id1,
                        principalTable: "Users",
                        principalColumn: "users_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "addresses_id", "address", "city_name", "users_id", "users_id1", "zip_code" },
                values: new object[,]
                {
                    { 1, "TEC Ballerup", null, 1, null, "2750" },
                    { 2, "Hjem Helsingør", null, 2, null, "3000" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categories_id", "category_name" },
                values: new object[] { 1, "hund" });

            migrationBuilder.InsertData(
                table: "Order_Items",
                columns: new[] { "order_items_id", "order_lists_id", "price", "products_id", "quantity" },
                values: new object[] { 1, 1, 750000, 1, 2 });

            migrationBuilder.InsertData(
                table: "Order_Lists",
                columns: new[] { "order_lists_id", "order_date_time", "users_id", "users_id1" },
                values: new object[] { 1, new DateTime(2021, 9, 16, 10, 49, 13, 151, DateTimeKind.Local).AddTicks(5701), 0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "products_id", "breed_name", "categories_id", "description", "gender", "price", "weight" },
                values: new object[] { 1, "chefer hund", 0, "\r\n                Tamhunden (Canis lupus familiaris) er det husdyr,\r\n                som tidligst blev tæmmet af mennesket,\r\n                og som derfor har den længste historie til fælles med os.\r\n                Den har gennem historien været brugt til jagt, som vagthund,\r\n                krigshund (eks. anti-tank-hunde), sporhund, redningshund, eller som 'følgesvend'.\r\n                Desuden som servicehund for blinde og handicappede, som politi- og redningshund, \r\n                som narkohund eller som terapihund.\r\n                Hunde kan også lugte sig frem til kræftsvulster,[2] termitangreb og forudsige epilepsianfald.\r\n                ", "male", 750000, 35000 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "users_id", "email", "password", "role" },
                values: new object[,]
                {
                    { 1, "admin@admins.com", "Passw0rd", 0 },
                    { 2, "user@users.com", "Passw0rd", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_users_id1",
                table: "Addresses",
                column: "users_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Lists_users_id1",
                table: "Order_Lists",
                column: "users_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "Order_Lists");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
