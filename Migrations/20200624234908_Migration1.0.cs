using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAS_projekt.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<string>(nullable: false),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    SupercategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_SupercategoryId",
                        column: x => x.SupercategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desktop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    NumberOfItemsInStock = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desktop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desktop_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laptop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    NumberOfItemsInStock = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    MaximumBatteryLife = table.Column<int>(nullable: false),
                    DisplaySize = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptop_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferredAddressId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Addresses_PreferredAddressId",
                        column: x => x.PreferredAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<double>(nullable: false),
                    DateOfEmployment = table.Column<DateTime>(nullable: false),
                    DateOfDismissal = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<long>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CanceledOrRejected = table.Column<DateTime>(nullable: true),
                    ClientId = table.Column<long>(nullable: false),
                    ReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApartmentNumber", "City", "HouseNumber", "PostalCode", "Street" },
                values: new object[] { 1, null, "Warszawa", "1A", "00-001", "Marszałkowska" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SupercategoryId" },
                values: new object[] { 1, "Komputery", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SupercategoryId" },
                values: new object[] { 2, "Komputery stacjonarne", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SupercategoryId" },
                values: new object[] { 3, "Laptopy", 1 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, 1, new DateTime(2000, 6, 25, 1, 49, 7, 423, DateTimeKind.Local).AddTicks(5479), "test@test.com", "Jan", "Kowalski", "1234567890" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "PersonId", "PreferredAddressId" },
                values: new object[] { 1L, 1, null });

            migrationBuilder.InsertData(
                table: "Desktop",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "Name", "NumberOfItemsInStock", "Price", "Type" },
                values: new object[] { 1, "DELL", 2, "Komputer stacjonarny DELL Inspiron", "Inspiron", 10, 1399.99, "Biznesowy" });

            migrationBuilder.InsertData(
                table: "Laptop",
                columns: new[] { "Id", "Brand", "CategoryId", "Description", "DisplaySize", "MaximumBatteryLife", "Name", "NumberOfItemsInStock", "Price", "Type" },
                values: new object[] { 2, "Alienware", 3, "Laptoop Alienware Areea 51m", 17.0, 120, "AREA", 15, 7999.9899999999998, "Gamingowy" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CanceledOrRejected", "ClientId", "Created", "OrderNumber", "ReportId", "State" },
                values: new object[] { 1, null, 1L, new DateTime(2020, 6, 15, 1, 49, 7, 430, DateTimeKind.Local).AddTicks(5480), 56789L, null, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CanceledOrRejected", "ClientId", "Created", "OrderNumber", "ReportId", "State" },
                values: new object[] { 2, null, 1L, new DateTime(2020, 6, 22, 1, 49, 7, 430, DateTimeKind.Local).AddTicks(5480), 1234567L, null, 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "OrderId", "ShoppingCartId" },
                values: new object[] { 1, 3, 1, null });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "OrderId", "ShoppingCartId" },
                values: new object[] { 2, 1, 1, null });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "OrderId", "ShoppingCartId" },
                values: new object[] { 3, 3, 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SupercategoryId",
                table: "Categories",
                column: "SupercategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PersonId",
                table: "Clients",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PreferredAddressId",
                table: "Clients",
                column: "PreferredAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Desktop_CategoryId",
                table: "Desktop",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonId",
                table: "Employees",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId",
                table: "Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingCartId",
                table: "Items",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptop_CategoryId",
                table: "Laptop",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReportId",
                table: "Orders",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ClientId",
                table: "ShoppingCarts",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desktop");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Laptop");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
