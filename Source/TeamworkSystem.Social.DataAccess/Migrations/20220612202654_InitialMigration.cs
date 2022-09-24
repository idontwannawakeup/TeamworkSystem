using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamworkSystem.Social.DataAccess.Migrations
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
                name: "Friends",
                columns: table => new
                {
                    SecondId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.SecondId, x.FirstId });
                    table.ForeignKey(
                        name: "FK_Friends_UserProfiles_FirstId",
                        column: x => x.FirstId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friends_UserProfiles_SecondId",
                        column: x => x.SecondId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_ToId",
                        column: x => x.ToId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
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
                table: "Ratings",
                columns: new[] { "Id", "Comment", "FromId", "Punctuality", "Responsibility", "Skills", "Social", "ToId" },
                values: new object[] { new Guid("05fa2b57-f3cb-4053-bd7a-d4a3669b596f"), "Just a great person", new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"), 4, 5, 5, 5, new Guid("61dfb9e3-1c27-424a-9963-9586ca110220") });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FirstId",
                table: "Friends",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ToId",
                table: "Ratings",
                column: "ToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
