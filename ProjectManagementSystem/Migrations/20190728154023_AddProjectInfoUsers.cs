using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class AddProjectInfoUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectInfoUserses",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ProjectInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectInfoUserses", x => new { x.ApplicationUserId, x.ProjectInfoId });
                    table.ForeignKey(
                        name: "FK_ProjectInfoUserses_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectInfoUserses_ProjectInfos_ProjectInfoId",
                        column: x => x.ProjectInfoId,
                        principalTable: "ProjectInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInfoUserses_ProjectInfoId",
                table: "ProjectInfoUserses",
                column: "ProjectInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectInfoUserses");
        }
    }
}
