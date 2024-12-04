using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShoppingApp.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "admins");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_UserId",
                table: "admins",
                newName: "IX_admins_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.RenameTable(
                name: "admins",
                newName: "Admin");

            migrationBuilder.RenameIndex(
                name: "IX_admins_UserId",
                table: "Admin",
                newName: "IX_Admin_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");
        }
    }
}
