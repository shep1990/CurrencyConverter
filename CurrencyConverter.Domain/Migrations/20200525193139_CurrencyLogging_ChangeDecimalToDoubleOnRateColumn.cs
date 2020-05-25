using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.Domain.Migrations
{
    public partial class CurrencyLogging_ChangeDecimalToDoubleOnRateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "CurrencyLogging",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "CurrencyLogging",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
