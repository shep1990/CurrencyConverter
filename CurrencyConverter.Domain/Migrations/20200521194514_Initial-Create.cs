using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrencyName = table.Column<string>(nullable: true),
                    CurrencyRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyLogging",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyLogging", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyLogging_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyLogging_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_Id",
                table: "Currency",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLogging_CurrencyId",
                table: "CurrencyLogging",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLogging_Id",
                table: "CurrencyLogging",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLogging_UserId",
                table: "CurrencyLogging",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyLogging");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
