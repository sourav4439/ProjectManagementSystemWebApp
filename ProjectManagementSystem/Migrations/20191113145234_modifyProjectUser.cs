using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class modifyProjectUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectInfoUserses_AspNetUsers_ApplicationUserId",
                table: "ProjectInfoUserses");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ProjectInfoUserses",
                newName: "ApplicationUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectInfoUserses_AspNetUsers_ApplicationUsersId",
                table: "ProjectInfoUserses",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectInfoUserses_AspNetUsers_ApplicationUsersId",
                table: "ProjectInfoUserses");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                table: "ProjectInfoUserses",
                newName: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectInfoUserses_AspNetUsers_ApplicationUserId",
                table: "ProjectInfoUserses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
