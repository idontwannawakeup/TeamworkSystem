using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamworkSystem.DataAccessLayer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    SecondId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.SecondId, x.FirstId });
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_FirstId",
                        column: x => x.FirstId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_SecondId",
                        column: x => x.SecondId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Social = table.Column<int>(type: "int", nullable: false),
                    Skills = table.Column<int>(type: "int", nullable: false),
                    Responsibility = table.Column<int>(type: "int", nullable: false),
                    Punctuality = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.UniqueConstraint("AK_Ratings_FromId_ToId", x => new { x.FromId, x.ToId });
                    table.ForeignKey(
                        name: "FK_Ratings_FromId",
                        column: x => x.FromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_ToId",
                        column: x => x.ToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LeaderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    About = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsMembers", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TeamsMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ExecutorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        principalTable: "AspNetUsers",
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Profession", "SecurityStamp", "Specialization", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b333929-f974-444e-a8d3-68f50a0459c0", 0, null, "e4f87b5c-715f-420f-9476-9d618e0c8b47", null, false, "Esmaralda", "Voigt", false, null, null, null, null, null, false, "Developer", "83a04ab2-2166-4456-8723-2ac4f2db4c3f", "Frontend", false, "User1" },
                    { "61dfb9e3-1c27-424a-9963-9586ca110220", 0, null, "4ae280e5-5e47-4ca2-b429-73125871a929", null, false, "Ostap", "Bleier", false, null, null, null, null, null, false, "Tester", "609f3bbb-7736-456e-aa93-bb0ee83684fb", "Backend", false, "User2" },
                    { "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f", 0, null, "99cbda91-c128-4936-8792-7f74fc74c56a", null, false, "Sophia", "Beringer", false, null, null, null, null, null, false, null, "45868622-8baa-4930-a933-c59c28f3c35b", "Fullstack", false, "User3" },
                    { "013a2014-4a25-4a3d-9fae-e0f783d42ef9", 0, null, "f7f8edb0-f6c7-4ad6-9c75-48a3f53a2d4b", null, false, "Marlyn", "Hendry", false, null, null, null, null, null, false, "Artist", "3b0c059a-7007-4f35-8cf7-857e235a72fe", null, false, "User4" },
                    { "ae557ffc-2906-4913-bd26-40aa98a55570", 0, null, "e242880c-ae3d-40c6-aeab-8eb7330c4104", null, false, "Vlasi", "Arterberry", false, null, null, null, null, null, false, "Designer", "dc135687-1086-4b12-bbff-d923b722c6d4", "Interier", false, "User5" },
                    { "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2", 0, null, "7713b5b8-32c1-4735-89c4-f43b5fb5e337", null, false, "Chasity", "Ilbert", false, null, null, null, null, null, false, null, "13905638-3911-4443-b155-8415c33256b1", null, false, "User6" },
                    { "bc0c5522-0a02-4f23-bb6a-319529716a94", 0, null, "5f92bd2d-1715-4664-9aa8-7b5d6f28fc8a", null, false, "Seraphina", "Salmon", false, null, null, null, null, null, false, "Developer", "fd11771d-44ad-487b-b872-c09cf775b8bc", "Backend", false, "User7" },
                    { "7484e532-dc8e-4005-8b67-15ad8a421a37", 0, null, "0d1b0e1b-113c-4647-af7f-56758e36e472", null, false, "Chas", "Hope", false, null, null, null, null, null, false, "Designer", "2cb62b6d-a311-4de9-ae21-291b20cbbe82", null, false, "User8" },
                    { "3f036c83-88e8-4aeb-ad33-290d60cf6b66", 0, null, "76c92ffb-7a97-4e3a-a2a8-43eae41579ed", null, false, "Nadezhda", "Haynes", false, null, null, null, null, null, false, null, "b5460119-e25f-4e64-9d8b-5eba29c78b50", null, false, "User9" },
                    { "7ad5c481-f391-45bb-a79c-cfcb1adb448b", 0, null, "3fed1973-133f-48dc-83f4-e916a0504a34", null, false, "Sonny", "Gibb", false, null, null, null, null, null, false, "Tester", "cda0cdb3-f982-4c40-a304-1163a2fa913b", null, false, "User10" },
                    { "0a906f06-fc52-417b-bc81-352df8bbe721", 0, null, "8fc09eca-f9f4-4436-a52d-3372d310fc4a", null, false, "Eric", "Lincoln", false, null, null, null, null, null, false, "Designer", "591f7ac7-d2d4-48b9-9383-1f51c34cc518", null, false, "User11" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Comment", "FromId", "Punctuality", "Responsibility", "Skills", "Social", "ToId" },
                values: new object[] { 1, "Just a great person", "3b333929-f974-444e-a8d3-68f50a0459c0", 4, 5, 5, 5, "61dfb9e3-1c27-424a-9963-9586ca110220" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "About", "LeaderId", "Name", "Specialization" },
                values: new object[,]
                {
                    { 7, "We are the warriors", "3b333929-f974-444e-a8d3-68f50a0459c0", "Warriors", null },
                    { 8, "We are the defenders", "3b333929-f974-444e-a8d3-68f50a0459c0", "Defenders", "Tests" },
                    { 3, "Lazy guys", "61dfb9e3-1c27-424a-9963-9586ca110220", "Lazy Guys", "Design" },
                    { 9, "We are writing bugs, fear us", "61dfb9e3-1c27-424a-9963-9586ca110220", "Thunder", "Writing bugs" },
                    { 1, "Young and ambitious", "013a2014-4a25-4a3d-9fae-e0f783d42ef9", "Amigos", "Web Development" },
                    { 5, null, "3f036c83-88e8-4aeb-ad33-290d60cf6b66", "Legends", null },
                    { 6, null, "7ad5c481-f391-45bb-a79c-cfcb1adb448b", "Shakedown", null },
                    { 2, null, "0a906f06-fc52-417b-bc81-352df8bbe721", "Heatwave", "OblEnergo" },
                    { 4, null, "0a906f06-fc52-417b-bc81-352df8bbe721", "Champions", null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "TeamId", "Title", "Type", "Url" },
                values: new object[] { 1, "Just a simple blog from small team", 9, "Blog", "Website", null });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreationTime", "Deadline", "Description", "ExecutorId", "Priority", "ProjectId", "Status", "Title", "Type" },
                values: new object[] { 1, new DateTime(2021, 5, 25, 2, 10, 4, 544, DateTimeKind.Local).AddTicks(8794), null, "There's unknown bug. Just fix it.", "61dfb9e3-1c27-424a-9963-9586ca110220", "Medium", 1, "Backlog", "Fix bug", "Epic" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FirstId",
                table: "Friends",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ToId",
                table: "Ratings",
                column: "ToId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "TeamsMembers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
