using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedUserTopUpAndTransactionsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionsNew",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    SaldoAccount = table.Column<decimal>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ClassOfTransaction = table.Column<int>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsNew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionsNew_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsNew_UserId",
                table: "TransactionsNew",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionsNew");
        }
    }
}
