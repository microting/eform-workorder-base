using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.WorkOrderBase.Migrations
{
    public partial class AddingMissingAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedArea",
                table: "WorkOrderVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedWorker",
                table: "WorkOrderVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedArea",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedWorker",
                table: "WorkOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedArea",
                table: "WorkOrderVersions");

            migrationBuilder.DropColumn(
                name: "AssignedWorker",
                table: "WorkOrderVersions");

            migrationBuilder.DropColumn(
                name: "AssignedArea",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "AssignedWorker",
                table: "WorkOrders");
        }
    }
}
