using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application.Interfaces.IDatabaseService.Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Interfaces.IDatabaseService.Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Interfaces.IDatabaseService.Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Interfaces.IDatabaseService.Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Interfaces.IDatabaseService.Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Interfaces.IDatabaseService.Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Interfaces.IDatabaseService.Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Interfaces.IDatabaseService.Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Interfaces.IDatabaseService.Sales_Application.Interfaces.IDatabaseService.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Application.Interfaces.IDatabaseService.Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Interfaces.IDatabaseService.Sales_Application.Interfaces.IDatabaseService.Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Application.Interfaces.IDatabaseService.Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application.Interfaces.IDatabaseService.Sales_Application.Interfaces.IDatabaseService.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Application.Interfaces.IDatabaseService.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Application.Interfaces.IDatabaseService.Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Moudakir Hamza" },
                    { 2, "Dardouri khalid" },
                    { 3, "Elmolaoui Amine" }
                });

            migrationBuilder.InsertData(
                table: "Application.Interfaces.IDatabaseService.Employees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "El baz Rachid" },
                    { 2, "El baz hicham" },
                    { 3, "El baz abdelhack" }
                });

            migrationBuilder.InsertData(
                table: "Application.Interfaces.IDatabaseService.Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Spaghetti", 90m },
                    { 2, "Pizza", 80m },
                    { 3, "Fish soup", 40m }
                });

            migrationBuilder.InsertData(
                table: "Application.Interfaces.IDatabaseService.Sales",
                columns: new[] { "Id", "CustomerId", "Date", "EmployeeId", "ProductId", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 5m, 90m },
                    { 2, 2, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 20m, 80m },
                    { 3, 3, new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 3, 45m, 40m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application.Interfaces.IDatabaseService.Sales_CustomerId",
                table: "Application.Interfaces.IDatabaseService.Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Interfaces.IDatabaseService.Sales_EmployeeId",
                table: "Application.Interfaces.IDatabaseService.Sales",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Application.Interfaces.IDatabaseService.Sales_ProductId",
                table: "Application.Interfaces.IDatabaseService.Sales",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application.Interfaces.IDatabaseService.Sales");

            migrationBuilder.DropTable(
                name: "Application.Interfaces.IDatabaseService.Customers");

            migrationBuilder.DropTable(
                name: "Application.Interfaces.IDatabaseService.Employees");

            migrationBuilder.DropTable(
                name: "Application.Interfaces.IDatabaseService.Products");
        }
    }
}
