using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    public partial class MergeGeneralIntoModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralInfoTags");

            migrationBuilder.DropTable(
                name: "GeneralInformation");

            migrationBuilder.AddColumn<string>(
                name: "BasicIdea",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassLevel",
                table: "Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LaborIntensity",
                table: "Modules",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProblemQuestion",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => new { x.ModuleId, x.Value });
                    table.ForeignKey(
                        name: "FK_Tags_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "BasicIdea",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ClassLevel",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "LaborIntensity",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ProblemQuestion",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Modules");

            migrationBuilder.CreateTable(
                name: "GeneralInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BasicIdea = table.Column<string>(type: "text", nullable: true),
                    ClassLevel = table.Column<int>(type: "integer", nullable: false),
                    Course = table.Column<string>(type: "text", nullable: true),
                    LaborIntensity = table.Column<double>(type: "double precision", nullable: false),
                    ModuleId = table.Column<int>(type: "integer", nullable: false),
                    ProblemQuestion = table.Column<string>(type: "text", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false)
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
                name: "GeneralInfoTags",
                columns: table => new
                {
                    GeneralInformationId = table.Column<int>(type: "integer", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralInfoTags", x => new { x.GeneralInformationId, x.Tag });
                    table.ForeignKey(
                        name: "FK_GeneralInfoTags_GeneralInformation_GeneralInformationId",
                        column: x => x.GeneralInformationId,
                        principalTable: "GeneralInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralInformation_ModuleId",
                table: "GeneralInformation",
                column: "ModuleId",
                unique: true);
        }
    }
}
