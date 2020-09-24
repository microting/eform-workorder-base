using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.WorkOrderBase.Migrations
{
    public partial class AddingCaseIdToAssignedSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "AssignedSiteVersions",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "AssignedSites",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "AssignedSiteVersions");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "AssignedSites");
        }
    }
}
