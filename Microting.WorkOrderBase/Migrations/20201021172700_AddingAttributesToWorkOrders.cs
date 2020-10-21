using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.WorkOrderBase.Migrations
{
    public partial class AddingAttributesToWorkOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckId",
                table: "WorkOrderVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckUId",
                table: "WorkOrderVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MicrotingId",
                table: "WorkOrderVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckId",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckUId",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MicrotingId",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckId",
                table: "WorkOrderVersions");

            migrationBuilder.DropColumn(
                name: "CheckUId",
                table: "WorkOrderVersions");

            migrationBuilder.DropColumn(
                name: "MicrotingId",
                table: "WorkOrderVersions");

            migrationBuilder.DropColumn(
                name: "CheckId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "CheckUId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "MicrotingId",
                table: "WorkOrders");
        }
    }
}
