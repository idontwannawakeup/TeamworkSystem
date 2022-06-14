using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamworkSystem.Content.Persistence.Migrations
{
    public partial class RecentRequestRelationshipFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecentRequests_UserProfiles_UserProfileId",
                table: "RecentRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecentRequests",
                table: "RecentRequests");

            migrationBuilder.DropIndex(
                name: "IX_RecentRequests_UserProfileId",
                table: "RecentRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecentRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserProfileId",
                table: "RecentRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecentRequests",
                table: "RecentRequests",
                columns: new[] { "UserProfileId", "RequestedEntityId", "RecentRequestEntityType" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecentRequests_UserProfiles_UserProfileId",
                table: "RecentRequests",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecentRequests_UserProfiles_UserProfileId",
                table: "RecentRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecentRequests",
                table: "RecentRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserProfileId",
                table: "RecentRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "RecentRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecentRequests",
                table: "RecentRequests",
                columns: new[] { "UserId", "RequestedEntityId", "RecentRequestEntityType" });

            migrationBuilder.CreateIndex(
                name: "IX_RecentRequests_UserProfileId",
                table: "RecentRequests",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecentRequests_UserProfiles_UserProfileId",
                table: "RecentRequests",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }
    }
}
