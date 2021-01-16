using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.WorkOrderBase.Migrations
{
    public partial class RefactoringMoreAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckUId",
                table: "WorkOrderVersions",
                "CheckMicrotingUid");

            migrationBuilder.RenameColumn(
                name: "CaseUId",
                table: "WorkOrdersTemplateCaseVersions",
                "CaseMicrotingUid");

            migrationBuilder.RenameColumn(
                name: "CheckUId",
                table: "WorkOrdersTemplateCaseVersions",
                newName: "CheckMicrotingUid");

            migrationBuilder.RenameColumn(
                name: "SdkSiteId",
                table: "WorkOrdersTemplateCaseVersions",
                "SdkSiteMicrotingUid");

            migrationBuilder.RenameColumn(
                name: "CaseUId",
                table: "WorkOrdersTemplateCases",
                newName: "CaseMicrotingUid");

            migrationBuilder.RenameColumn(
                name: "CheckUId",
                table: "WorkOrdersTemplateCases",
                "CheckMicrotingUid");

            migrationBuilder.RenameColumn(
                name: "SdkSiteId",
                table: "WorkOrdersTemplateCases",
                "SdkSiteMicrotingUid");

            migrationBuilder.RenameColumn(
                name: "CheckUId",
                table: "WorkOrders",
                "CheckMicrotingUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckMicrotingUid",
                table: "WorkOrderVersions");

            migrationBuilder.DropColumn(
                name: "CaseMicrotingUid",
                table: "WorkOrdersTemplateCaseVersions");

            migrationBuilder.DropColumn(
                name: "CheckMicrotingUid",
                table: "WorkOrdersTemplateCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkSiteMicrotingUid",
                table: "WorkOrdersTemplateCaseVersions");

            migrationBuilder.DropColumn(
                name: "CaseMicrotingUid",
                table: "WorkOrdersTemplateCases");

            migrationBuilder.DropColumn(
                name: "CheckMicrotingUid",
                table: "WorkOrdersTemplateCases");

            migrationBuilder.DropColumn(
                name: "SdkSiteMicrotingUid",
                table: "WorkOrdersTemplateCases");

            migrationBuilder.DropColumn(
                name: "CheckMicrotingUid",
                table: "WorkOrders");

            migrationBuilder.AddColumn<int>(
                name: "CheckUId",
                table: "WorkOrderVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CaseUId",
                table: "WorkOrdersTemplateCaseVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckUId",
                table: "WorkOrdersTemplateCaseVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SdkSiteId",
                table: "WorkOrdersTemplateCaseVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CaseUId",
                table: "WorkOrdersTemplateCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckUId",
                table: "WorkOrdersTemplateCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SdkSiteId",
                table: "WorkOrdersTemplateCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckUId",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
