using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.Domain.Migrations
{
    public partial class CurrencyLogging_UpdatedRelationshipDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLogging_SourceCurrencyId",
                table: "CurrencyLogging",
                column: "SourceCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyLogging_Currency_SourceCurrencyId",
                table: "CurrencyLogging",
                column: "SourceCurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyLogging_Currency_SourceCurrencyId",
                table: "CurrencyLogging");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyLogging_SourceCurrencyId",
                table: "CurrencyLogging");
        }
    }
}
