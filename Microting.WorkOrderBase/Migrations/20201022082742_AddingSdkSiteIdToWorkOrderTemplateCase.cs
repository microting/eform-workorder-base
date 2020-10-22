using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.WorkOrderBase.Migrations
{
    public partial class AddingSdkSiteIdToWorkOrderTemplateCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SdkSiteId",
                table: "WorkOrdersTemplateCases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkOrdersTemplateCaseVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    CaseId = table.Column<int>(nullable: false),
                    CaseUId = table.Column<int>(nullable: false),
                    CheckId = table.Column<int>(nullable: false),
                    CheckUId = table.Column<int>(nullable: false),
                    WorkOrderId = table.Column<int>(nullable: false),
                    SdkSiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrdersTemplateCaseVersions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrdersTemplateCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkSiteId",
                table: "WorkOrdersTemplateCases");
        }
    }
}
