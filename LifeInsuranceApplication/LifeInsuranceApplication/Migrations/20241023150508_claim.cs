using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeInsuranceApplication.Migrations
{
    public partial class claim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Policies_PolicyId1",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_PolicyId1",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "PolicyId1",
                table: "Claims");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Claims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ClaimTypeId1",
                table: "Claims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimTypeId",
                table: "Claims",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimTypeId1",
                table: "Claims",
                column: "ClaimTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PolicyId",
                table: "Claims",
                column: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId",
                table: "Claims",
                column: "ClaimTypeId",
                principalTable: "ClaimTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId1",
                table: "Claims",
                column: "ClaimTypeId1",
                principalTable: "ClaimTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Policies_PolicyId",
                table: "Claims",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId1",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Policies_PolicyId",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_ClaimTypeId",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_ClaimTypeId1",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Claims_PolicyId",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "ClaimTypeId1",
                table: "Claims");

            migrationBuilder.AlterColumn<string>(
                name: "PolicyId",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PolicyId1",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PolicyId1",
                table: "Claims",
                column: "PolicyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Policies_PolicyId1",
                table: "Claims",
                column: "PolicyId1",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
