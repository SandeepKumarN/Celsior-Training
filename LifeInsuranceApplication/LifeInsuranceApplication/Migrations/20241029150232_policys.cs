using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsuranceApplication.Migrations
{
    public partial class policys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId1",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_ClaimTypeId1",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "ClaimTypeId1",
                table: "Claims");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Claims");

            migrationBuilder.AddColumn<int>(
                name: "ClaimTypeId1",
                table: "Claims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimTypeId1",
                table: "Claims",
                column: "ClaimTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId1",
                table: "Claims",
                column: "ClaimTypeId1",
                principalTable: "ClaimTypes",
                principalColumn: "Id");
        }
    }
}
