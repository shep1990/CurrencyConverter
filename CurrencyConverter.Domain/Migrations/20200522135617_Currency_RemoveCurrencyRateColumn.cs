using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.Domain.Migrations
{
    public partial class Currency_RemoveCurrencyRateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "Currency");

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[,]
                {
                    { new Guid("2a980cb3-82cf-4b88-88e3-58c486c6d939"), "GBP" },
                    { new Guid("3132922e-224f-40df-98d8-cb62cd282e96"), "USD" },
                    { new Guid("f9eb8cd0-3c14-4480-aa93-0056f51c4ee4"), "AUD" },
                    { new Guid("2d115204-059a-4018-ae21-d9c53bdad589"), "EUR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2a980cb3-82cf-4b88-88e3-58c486c6d939"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2d115204-059a-4018-ae21-d9c53bdad589"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("3132922e-224f-40df-98d8-cb62cd282e96"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("f9eb8cd0-3c14-4480-aa93-0056f51c4ee4"));

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyRate",
                table: "Currency",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
