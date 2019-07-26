using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class Seedusersdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Status], [Designation]) VALUES (N'88e99b95-dd47-438c-a81a-80f4cad6cc3f', N'itadmin@gmail.com', N'ITADMIN@GMAIL.COM', N'itadmin@gmail.com', N'ITADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEIGdDmAUPzINyipFrMCcAm3K5mI7WoSCbU06vLGdllPPOk96iu6vPcQAjCwLVVGWCA==', N'I3NV2GEEMCG5TJDQGADOPIOPDC5YBCP2', N'57f5b22c-7c44-416e-bc3a-7087873d017b', NULL, 0, 0, NULL, 1, 0, N'Technology', 1, N'ItAdmin')"
                +@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4f1b0e84-3764-4912-a3e8-9558a2a595c6', N'ItAdmin', N'ITADMIN', N'40968c14-a260-40fc-a30d-350087e88a60')"
             +@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'88e99b95-dd47-438c-a81a-80f4cad6cc3f', N'4f1b0e84-3764-4912-a3e8-9558a2a595c6')
            
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
