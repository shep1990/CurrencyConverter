using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.Domain.Migrations
{
    public partial class CurrencyLogging_AddDateColumnAndUpdateCurrencyColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyLogging_Currency_CurrencyId",
                table: "CurrencyLogging");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyLogging_User_UserId",
                table: "CurrencyLogging");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyLogging_CurrencyId",
                table: "CurrencyLogging");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CurrencyLogging",
                newName: "TargetCurrencyId");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "CurrencyLogging",
                newName: "SourceCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CurrencyLogging_UserId",
                table: "CurrencyLogging",
                newName: "IX_CurrencyLogging_TargetCurrencyId");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "CurrencyLogging",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLogged",
                table: "CurrencyLogging",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "CurrencyLogging",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2a980cb3-82cf-4b88-88e3-58c486c6d939"),
                column: "CurrencyName",
                value: "GBP");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyLogging_Currency_TargetCurrencyId",
                table: "CurrencyLogging",
                column: "TargetCurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyLogging_Currency_TargetCurrencyId",
                table: "CurrencyLogging");

            migrationBuilder.DropColumn(
                name: "DateLogged",
                table: "CurrencyLogging");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "CurrencyLogging");

            migrationBuilder.RenameColumn(
                name: "TargetCurrencyId",
                table: "CurrencyLogging",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SourceCurrencyId",
                table: "CurrencyLogging",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CurrencyLogging_TargetCurrencyId",
                table: "CurrencyLogging",
                newName: "IX_CurrencyLogging_UserId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CurrencyLogging",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2a980cb3-82cf-4b88-88e3-58c486c6d939"),
                column: "CurrencyName",
                value: "GPB");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLogging_CurrencyId",
                table: "CurrencyLogging",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyLogging_Currency_CurrencyId",
                table: "CurrencyLogging",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyLogging_User_UserId",
                table: "CurrencyLogging",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
