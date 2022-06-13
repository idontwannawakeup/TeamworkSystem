using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamworkSystem.Content.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_UserProfiles_NotifiedUserId",
                        column: x => x.NotifiedUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecentRequests",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecentRequestEntityType = table.Column<int>(type: "int", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentRequests", x => new { x.UserId, x.RequestedEntityId, x.RecentRequestEntityType });
                    table.ForeignKey(
                        name: "FK_RecentRequests_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "NotificationTemplates",
                columns: new[] { "Id", "Message", "Title" },
                values: new object[,]
                {
                    { 0, "{FullName}, you were assigned to ticket: {TicketTitle}", "New ticket" },
                    { 1, "{FullName}, deadline for assigned ticket is soon: {TicketTitle}, {TicketDeadline}", "Deadline reminder" },
                    { 2, "{FullName}, you have new friend request!", "New friend" },
                    { 3, "{FullName}, description of ticket changed: {TicketTitle}", "Ticket description changed" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Avatar", "FirstName", "LastName", "Profession", "Specialization" },
                values: new object[,]
                {
                    { new Guid("013a2014-4a25-4a3d-9fae-e0f783d42ef9"), null, "Marlyn", "Hendry", "Artist", null },
                    { new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"), null, "Eric", "Lincoln", "Designer", null },
                    { new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"), null, "Esmaralda", "Voigt", "Developer", "Frontend" },
                    { new Guid("3f036c83-88e8-4aeb-ad33-290d60cf6b66"), null, "Nadezhda", "Haynes", null, null },
                    { new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), null, "Ostap", "Nice", "Developer", "Backend" },
                    { new Guid("7484e532-dc8e-4005-8b67-15ad8a421a37"), null, "Chas", "Hope", "Designer", null },
                    { new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"), null, "Sonny", "Gibb", "Tester", null },
                    { new Guid("a36b02e1-81a9-47f4-89b6-d33c4f40ed5f"), null, "Sophia", "Beringer", null, "Fullstack" },
                    { new Guid("ae557ffc-2906-4913-bd26-40aa98a55570"), null, "Vlasi", "Arterberry", "Designer", "Interier" },
                    { new Guid("bc0c5522-0a02-4f23-bb6a-319529716a94"), null, "Seraphina", "Salmon", "Developer", "Backend" },
                    { new Guid("e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2"), null, "Chasity", "Ilbert", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotifiedUserId",
                table: "Notifications",
                column: "NotifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecentRequests_UserProfileId",
                table: "RecentRequests",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationTemplates");

            migrationBuilder.DropTable(
                name: "RecentRequests");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
