using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addedkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaldoUsers_AspNetUsers_UserId",
                table: "SaldoUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SaldoUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_SaldoUsers_AspNetUsers_UserId",
                table: "SaldoUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaldoUsers_AspNetUsers_UserId",
                table: "SaldoUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SaldoUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SaldoUsers_AspNetUsers_UserId",
                table: "SaldoUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
