using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryAppV1.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_orderItems_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItems_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "AdminId", "Email", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[] { 1, "admin@example.com", "SuperAdmin", "admin@123", "1234567890", "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "Address", "CustomerName", "Email", "PhoneNumber", "password" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "John Doe", "john@example.com", "9876543210", "john@123" },
                    { 2, "456 South Avenue", "Jane Smith", "jane@example.com", "5554443322", "jane@123" }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "ItemId", "Description", "IsAvailable", "ItemName", "Price" },
                values: new object[,]
                {
                    { 1, "Classic cheese pizza", true, "Margherita Pizza", 9.99m },
                    { 2, "Delicious burger with veggie patty", true, "Veggie Burger", 7.49m },
                    { 3, "Pizza with pepperoni toppings", true, "Pepperoni Pizza", 10.99m },
                    { 4, "Juicy chicken burger", true, "Chicken Burger", 8.49m },
                    { 5, "Crispy golden fries", true, "French Fries", 3.49m }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDateTime", "Price", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 10, 13, 0, 10, 0, 0, DateTimeKind.Local), 9.99m, 1 },
                    { 2, 2, new DateTime(2025, 10, 13, 0, 25, 0, 0, DateTimeKind.Local), 7.49m, 2 },
                    { 3, 1, new DateTime(2025, 10, 13, 0, 32, 0, 0, DateTimeKind.Local), 10.98m, 2 },
                    { 4, 2, new DateTime(2025, 10, 13, 0, 45, 0, 0, DateTimeKind.Local), 10.99m, 1 },
                    { 5, 2, new DateTime(2025, 10, 13, 0, 45, 0, 0, DateTimeKind.Local), 10.98m, 3 },
                    { 6, 1, new DateTime(2025, 10, 13, 0, 50, 0, 0, DateTimeKind.Local), 10.99m, 3 }
                });

            migrationBuilder.InsertData(
                table: "orderItems",
                columns: new[] { "OrderItemId", "ItemId", "OrderId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 9.99m },
                    { 2, 2, 2, 1, 7.49m },
                    { 3, 2, 3, 1, 7.49m },
                    { 4, 5, 3, 1, 3.49m },
                    { 5, 3, 4, 1, 10.99m },
                    { 6, 2, 5, 1, 7.49m },
                    { 7, 5, 5, 1, 3.49m },
                    { 8, 3, 6, 1, 10.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ItemId",
                table: "orderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
