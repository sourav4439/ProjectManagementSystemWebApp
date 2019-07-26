using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class SeedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'026a8369-8c63-4437-9daf-af2c3d5b1640', N'TeamLead', N'TEAMLEAD', N'22eecc2b-01da-407a-aef8-06d1bbc48f92')
            " +
                @"INSERT INTO[dbo].[AspNetRoles]([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES(N'1e8c3659-62e4-4b47-aace-db1916393d75', N'Projectmanager', N'PROJECTMANAGER', N'940d7ae9-6e2d-49fa-8932-6fcf132d3246')
            " +
                @"INSERT INTO[dbo].[AspNetRoles]([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES(N'4fd37e59-ef4b-4c34-8230-47e79a9699b6', N'Developer', N'DEVELOPER', N'e67e249a-a298-40cf-a216-07c371354960')
           " +
                @"INSERT INTO[dbo].[AspNetRoles]([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES(N'a7b292f9-0fda-4abc-af8c-801cfb02c329', N'UxEngineer', N'UXENGINEER', N'73f9a427-6127-41d3-b4ff-a2a6efbf967b')
           " +
                @"INSERT INTO[dbo].[AspNetRoles]([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES(N'c41a8b96-5baf-4299-a88b-efd2022fe062', N'QaEngineer', N'QAENGINEER', N'fad4ed61-54f5-4748-a147-7f03e0866551')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
