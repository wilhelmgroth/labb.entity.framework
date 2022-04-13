using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb1.EntityFramework.Migrations
{
    public partial class HolidayTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "HolidayApplications");

            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                table: "HolidayApplications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HolidayType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayApplications_TypeId",
                table: "HolidayApplications",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayApplications_HolidayType_TypeId",
                table: "HolidayApplications",
                column: "TypeId",
                principalTable: "HolidayType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayApplications_HolidayType_TypeId",
                table: "HolidayApplications");

            migrationBuilder.DropTable(
                name: "HolidayType");

            migrationBuilder.DropIndex(
                name: "IX_HolidayApplications_TypeId",
                table: "HolidayApplications");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "HolidayApplications");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "HolidayApplications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
