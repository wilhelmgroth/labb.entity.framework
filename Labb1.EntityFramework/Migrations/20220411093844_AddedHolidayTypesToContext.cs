using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb1.EntityFramework.Migrations
{
    public partial class AddedHolidayTypesToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayApplications_HolidayType_TypeId",
                table: "HolidayApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HolidayType",
                table: "HolidayType");

            migrationBuilder.RenameTable(
                name: "HolidayType",
                newName: "HolidayTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HolidayTypes",
                table: "HolidayTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayApplications_HolidayTypes_TypeId",
                table: "HolidayApplications",
                column: "TypeId",
                principalTable: "HolidayTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayApplications_HolidayTypes_TypeId",
                table: "HolidayApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HolidayTypes",
                table: "HolidayTypes");

            migrationBuilder.RenameTable(
                name: "HolidayTypes",
                newName: "HolidayType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HolidayType",
                table: "HolidayType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayApplications_HolidayType_TypeId",
                table: "HolidayApplications",
                column: "TypeId",
                principalTable: "HolidayType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
