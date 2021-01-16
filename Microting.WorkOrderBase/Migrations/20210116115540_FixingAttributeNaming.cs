using Microsoft.EntityFrameworkCore.Migrations;
using Microting.WorkOrderBase.Infrastructure.Data.Entities;

namespace Microting.WorkOrderBase.Migrations
{
    public partial class FixingAttributeNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "CaseId",
                "AssignedSiteVersions",
                "CaseMicrotingUid");

            migrationBuilder.RenameColumn(
                "SiteId",
                "AssignedSiteVersions",
                "SiteMicrotingUid");

            migrationBuilder.RenameColumn(
                "CaseId",
                "AssignedSites",
                "CaseMicrotingUid");

            migrationBuilder.RenameColumn(
                "SiteId",
                "AssignedSites",
                "SiteMicrotingUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignedSiteVersions_SiteMicrotingUid",
                table: "AssignedSiteVersions");

            migrationBuilder.DropIndex(
                name: "IX_AssignedSites_SiteMicrotingUid",
                table: "AssignedSites");

            migrationBuilder.DropColumn(
                name: "CaseMicrotingUid",
                table: "AssignedSiteVersions");

            migrationBuilder.DropColumn(
                name: "SiteMicrotingUid",
                table: "AssignedSiteVersions");

            migrationBuilder.DropColumn(
                name: "CaseMicrotingUid",
                table: "AssignedSites");

            migrationBuilder.DropColumn(
                name: "SiteMicrotingUid",
                table: "AssignedSites");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "AssignedSiteVersions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "AssignedSiteVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "AssignedSites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "AssignedSites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AssignedSiteVersions_SiteId",
                table: "AssignedSiteVersions",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedSites_SiteId",
                table: "AssignedSites",
                column: "SiteId");
        }
    }
}
