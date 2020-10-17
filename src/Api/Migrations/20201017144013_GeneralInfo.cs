using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    public partial class GeneralInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditTime",
                table: "Modules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GeneralInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Visibility = table.Column<int>(nullable: false),
                    ClassLevel = table.Column<int>(nullable: false),
                    Course = table.Column<string>(nullable: true),
                    LaborIntensity = table.Column<double>(nullable: false),
                    BasicIdea = table.Column<string>(nullable: true),
                    ProblemQuestion = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralInformation_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralInfoToLink",
                columns: table => new
                {
                    GeneralInformationId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralInfoToLink", x => new { x.GeneralInformationId, x.TagId });
                    table.ForeignKey(
                        name: "FK_GeneralInfoToLink_GeneralInformation_GeneralInformationId",
                        column: x => x.GeneralInformationId,
                        principalTable: "GeneralInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralInfoToLink_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralInformation_ModuleId",
                table: "GeneralInformation",
                column: "ModuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralInfoToLink_TagId",
                table: "GeneralInfoToLink",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Value",
                table: "Tags",
                column: "Value",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralInfoToLink");

            migrationBuilder.DropTable(
                name: "GeneralInformation");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "LastEditTime",
                table: "Modules");
        }
    }
}
