using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.Domain.Migrations
{
    public partial class CurrencyLogging_AddConvertedAmountColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConvertedAmount",
                table: "CurrencyLogging",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConvertedAmount",
                table: "CurrencyLogging");
        }
    }
}
