using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addedPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaldoUsers_AspNetUsers_UserId",
                table: "SaldoUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SaldoUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SaldoUsers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaldoUsers",
                table: "SaldoUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaldoUsers_AspNetUsers_UserId",
                table: "SaldoUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaldoUsers_AspNetUsers_UserId",
                table: "SaldoUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaldoUsers",
                table: "SaldoUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SaldoUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SaldoUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_SaldoUsers_AspNetUsers_UserId",
                table: "SaldoUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
