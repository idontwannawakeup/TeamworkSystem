using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamworkSystem.WorkManagement.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    About = table.Column<string>(type: "ntext", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamsMembers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsMembers", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TeamsMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsMembers_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tickets_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "About", "Avatar", "LeaderId", "Name", "Specialization" },
                values: new object[,]
                {
                    { new Guid("12b4ec07-1d5f-4baf-9237-a3b19a5b7a68"), "Lazy guys", null, new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), "Lazy Guys", "Design" },
                    { new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9"), "We are writing bugs, fear us", null, new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), "Thunder", "Writing bugs" },
                    { new Guid("29c1751d-6a4b-405d-9268-0863a4b0e196"), null, null, new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"), "Shakedown", null },
                    { new Guid("5b78adfd-017f-4b97-b7a3-06dc54813dc2"), null, null, new Guid("3f036c83-88e8-4aeb-ad33-290d60cf6b66"), "Legends", null },
                    { new Guid("73d936ae-0269-475d-b58f-8b456fafce85"), "Young and ambitious", null, new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), "Amigos", "Web Development" },
                    { new Guid("79d2e324-7cae-4cb5-b039-27d2c07ce517"), null, null, new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"), "Champions", null },
                    { new Guid("7ade466f-f4b1-4bc9-8e41-6fac1a1b8b01"), "We are the warriors", null, new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"), "Warriors", null },
                    { new Guid("80e2fd08-759c-42fa-a25b-ae8252d13ca6"), null, null, new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"), "Heatwave", "OblEnergo" },
                    { new Guid("d08c11eb-ecf6-47b6-9276-bbc46275f919"), "We are the defenders", null, new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"), "Defenders", "Tests" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "TeamId", "Title", "Type", "Url" },
                values: new object[] { new Guid("2f73e5de-7fb3-47c1-9756-ea8a499d8eac"), "Just a simple blog from small team", new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9"), "Blog", "Website", null });

            migrationBuilder.InsertData(
                table: "TeamsMembers",
                columns: new[] { "UserId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"), new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9") },
                    { new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"), new Guid("79d2e324-7cae-4cb5-b039-27d2c07ce517") },
                    { new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"), new Guid("80e2fd08-759c-42fa-a25b-ae8252d13ca6") },
                    { new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"), new Guid("7ade466f-f4b1-4bc9-8e41-6fac1a1b8b01") },
                    { new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"), new Guid("d08c11eb-ecf6-47b6-9276-bbc46275f919") },
                    { new Guid("3f036c83-88e8-4aeb-ad33-290d60cf6b66"), new Guid("5b78adfd-017f-4b97-b7a3-06dc54813dc2") },
                    { new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), new Guid("12b4ec07-1d5f-4baf-9237-a3b19a5b7a68") },
                    { new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9") },
                    { new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), new Guid("73d936ae-0269-475d-b58f-8b456fafce85") },
                    { new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"), new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9") },
                    { new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"), new Guid("29c1751d-6a4b-405d-9268-0863a4b0e196") }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreationTime", "Deadline", "Description", "ExecutorId", "Priority", "ProjectId", "Status", "Title", "Type" },
                values: new object[] { new Guid("61c21020-30a0-47a6-8b9d-607b6b9f68b0"), new DateTime(2022, 6, 1, 13, 57, 3, 0, DateTimeKind.Unspecified), null, "There's unknown bug. Just fix it.", new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), "Medium", new Guid("2f73e5de-7fb3-47c1-9756-ea8a499d8eac"), "Backlog", "Fix bug", "Epic" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsMembers_TeamId",
                table: "TeamsMembers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ExecutorId",
                table: "Tickets",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamsMembers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
