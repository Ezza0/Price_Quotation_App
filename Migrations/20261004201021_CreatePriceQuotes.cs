using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Price_Quotation_App.Migrations
{
    /// <inheritdoc />
    public partial class CreatePriceQuotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceQuotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Slug = table.Column<string>(type: "TEXT", nullable: false),
                    Subtotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceQuotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PriceQuotes",
                columns: new[] { "Id", "CreatedAtUtc", "DiscountAmount", "DiscountPercent", "Slug", "Subtotal", "Total" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), 10m, 10m, "quote-1", 100m, 90m },
                    { 2, new DateTime(2025, 1, 2, 12, 0, 0, 0, DateTimeKind.Utc), 37.50m, 15m, "quote-2", 250m, 212.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceQuotes_Slug",
                table: "PriceQuotes",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceQuotes");
        }
    }
}
