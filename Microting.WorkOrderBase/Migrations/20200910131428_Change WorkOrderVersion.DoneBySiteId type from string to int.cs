using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.WorkOrderBase.Migrations
{
    public partial class ChangeWorkOrderVersionDoneBySiteIdtypefromstringtoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DoneBySiteId",
                table: "WorkOrderVersions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DoneBySiteId",
                table: "WorkOrderVersions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
