using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrangularAPI.Migrations
{
    public partial class newBase : Migration
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
                name: "Products",
                columns: table => new
                {
                    products_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories_id = table.Column<int>(type: "int", nullable: false),
                    categorycategories_id = table.Column<int>(type: "int", nullable: true),
                    breed_name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.products_id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categorycategories_id",
                        column: x => x.categorycategories_id,
                        principalTable: "Categories",
                        principalColumn: "categories_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    addresses_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    users_id = table.Column<int>(type: "int", nullable: false),
                    users_id1 = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    zip_code = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    city_name = table.Column<string>(type: "nvarchar(255)", nullable: true)
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
                    users_id1 = table.Column<int>(type: "int", nullable: true),
                    order_date_time = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    order_items_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_lists_id = table.Column<int>(type: "int", nullable: false),
                    order_lists_id1 = table.Column<int>(type: "int", nullable: true),
                    products_id = table.Column<int>(type: "int", nullable: false),
                    products_id1 = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.order_items_id);
                    table.ForeignKey(
                        name: "FK_Order_Items_Order_Lists_order_lists_id1",
                        column: x => x.order_lists_id1,
                        principalTable: "Order_Lists",
                        principalColumn: "order_lists_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Items_Products_products_id1",
                        column: x => x.products_id1,
                        principalTable: "Products",
                        principalColumn: "products_id",
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
                columns: new[] { "order_items_id", "order_lists_id", "order_lists_id1", "price", "products_id", "products_id1", "quantity" },
                values: new object[] { 1, 1, null, 750000, 1, null, 2 });

            migrationBuilder.InsertData(
                table: "Order_Lists",
                columns: new[] { "order_lists_id", "order_date_time", "users_id", "users_id1" },
                values: new object[] { 1, new DateTime(2021, 9, 23, 8, 13, 30, 811, DateTimeKind.Local).AddTicks(9146), 0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "products_id", "breed_name", "categories_id", "categorycategories_id", "description", "gender", "price", "weight" },
                values: new object[] { 1, "chefer hund", 0, null, "Description", "male", 750000, 35000 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "users_id", "email", "password", "role" },
                values: new object[,]
                {
                    { 1, "admin@admins.com", "Passw0rd", 1 },
                    { 2, "user@users.com", "Passw0rd", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_users_id",
                table: "Addresses",
                column: "users_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_users_id1",
                table: "Addresses",
                column: "users_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_order_lists_id1",
                table: "Order_Items",
                column: "order_lists_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_products_id1",
                table: "Order_Items",
                column: "products_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Lists_users_id1",
                table: "Order_Lists",
                column: "users_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categorycategories_id",
                table: "Products",
                column: "categorycategories_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "Order_Lists");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
