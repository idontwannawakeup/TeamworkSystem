﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamworkSystem.Identity.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Profession", "SecurityStamp", "Specialization", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("013a2014-4a25-4a3d-9fae-e0f783d42ef9"), 0, null, "9bf32f13-7700-49e6-86db-2a5061d23dac", "user4@gmail.com", true, "Marlyn", "Hendry", false, null, "USER4@GMAIL.COM", "USER4", "AQAAAAEAACcQAAAAEGLBS07wW/31unmQo+9CzPpddy9CAQ9MoJMctGizdmQGkV5wbs8AfOqY4junLa3EHw==", null, false, "Artist", "f7cca86c-9d2a-416e-b80c-2c8433bb799d", null, false, "User4" },
                    { new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"), 0, null, "a8e49c32-6b6a-4e06-ac96-f683fa8a0df5", "user11@gmail.com", true, "Eric", "Lincoln", false, null, "USER11@GMAIL.COM", "USER11", "AQAAAAEAACcQAAAAEMYbmSdr5+9v1sDNj+0f+c1+DmI0ugPnbtFMx3ONkWszAGHfFhZdWO4XZvvDjemq1w==", null, false, "Designer", "370697bb-d75e-42da-9560-b182cb28aaa3", null, false, "User11" },
                    { new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"), 0, null, "e50a9022-d52a-4380-b83d-f0a475fbf14a", "user2@gmail.com", true, "Esmaralda", "Voigt", false, null, "USER2@GMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEL2BIy+jkeBhvgGn5KGCTBlCMZLv1a/3No9TNsIy4cK+hZX72njK6pgL1GgqPM0PKw==", null, false, "Developer", "b1b368ca-830b-4d51-9088-cca805dbae10", "Frontend", false, "User2" },
                    { new Guid("3f036c83-88e8-4aeb-ad33-290d60cf6b66"), 0, null, "94cb97ce-bd4e-4a74-912b-fb0562cf8d98", "user9@gmail.com", true, "Nadezhda", "Haynes", false, null, "USER9@GMAIL.COM", "USER9", "AQAAAAEAACcQAAAAEMujOiZ+xyXQzQ0BQaFPacbSywrVpM/kUyOVkLpqjnyqpNL5iPFSh4pQuXALTAzDzg==", null, false, null, "7c33daa4-c288-436c-9f48-d5316bdf21f7", null, false, "User9" },
                    { new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"), 0, null, "f44736ce-d7d2-41f5-89f7-95919ba4b4fa", "user1@gmail.com", true, "Ostap", "Nice", false, null, "USER1@GMAIL.COM", "USER1", "AQAAAAEAACcQAAAAEHIJxNS71yM2C19K8pJktzIg+gOfmz3ySn59bRPhmSrkabIMpXGGzKjZjhnEjFKqSA==", null, false, "Developer", "c58ae9db-4ab1-41d9-acbf-dbd162586983", "Backend", false, "User1" },
                    { new Guid("7484e532-dc8e-4005-8b67-15ad8a421a37"), 0, null, "dc22b52f-696d-43a2-aadc-5cd3127af882", "user8@gmail.com", true, "Chas", "Hope", false, null, "USER8@GMAIL.COM", "USER8", "AQAAAAEAACcQAAAAEDMlNkhUX9Tv8m1WoKR/a5ih0hIAz/YvPiN4O33OyOtaFmYU4AkLWH5rDE1KbqgfBQ==", null, false, "Designer", "66c2ff61-d8df-44d0-b0bf-20da42d4dda8", null, false, "User8" },
                    { new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"), 0, null, "e5197c13-324a-4de3-814f-fbd0466b4a3c", "user10@gmail.com", true, "Sonny", "Gibb", false, null, "USER10@GMAIL.COM", "USER10", "AQAAAAEAACcQAAAAEBpXFqORoIAZzf4ecLwpafHOApLBaIaX+GKlPCrl5uUpwZVtE9ihjJv0JFsq9/ObLw==", null, false, "Tester", "3c9bec94-dd50-4ee4-8f5e-be1e84ea8c86", null, false, "User10" },
                    { new Guid("a36b02e1-81a9-47f4-89b6-d33c4f40ed5f"), 0, null, "337bed17-84eb-40fd-b054-8143c3f2a395", "user3@gmail.com", true, "Sophia", "Beringer", false, null, "USER3@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEO/UmfH8XG+WTNv1ObFBISr3QPkLEIioSGoSE624sdtPr/n0R2CF0QHAxj3nJ20tVQ==", null, false, null, "fd9d63cf-b341-4a41-9bea-eee95a727210", "Fullstack", false, "User3" },
                    { new Guid("ae557ffc-2906-4913-bd26-40aa98a55570"), 0, null, "0f9a4766-ce0c-4212-83e3-b5aa91766e41", "user5@gmail.com", true, "Vlasi", "Arterberry", false, null, "USER5@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAEAR2JdvRPd1tVc+laO+tHhsGmRUodkuSHxiLnsMAu0UEiPSWpOMNOgelabUN5IY8mg==", null, false, "Designer", "2b429c9a-051e-4853-b1b9-109e9ea1c800", "Interier", false, "User5" },
                    { new Guid("bc0c5522-0a02-4f23-bb6a-319529716a94"), 0, null, "a5c49d1a-19e7-45fe-8dd9-9f9554aa5e45", "user7@gmail.com", true, "Seraphina", "Salmon", false, null, "USER7@GMAIL.COM", "USER7", "AQAAAAEAACcQAAAAEFUDlk3bKxR8CoowzB76pDuzWh5oSL0xvqSGV4iNfPzeUkWLW33K7gDPtSGkkPb5sg==", null, false, "Developer", "486d413e-645c-4682-80ef-ff00375c60b1", "Backend", false, "User7" },
                    { new Guid("e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2"), 0, null, "6a6db53c-46af-4c60-a447-033fd6a1f1c5", "user6@gmail.com", true, "Chasity", "Ilbert", false, null, "USER6@GMAIL.COM", "USER6", "AQAAAAEAACcQAAAAECR6b8CpecXVogmitbfkvTOt2PWxVi3+f8ITWxYl8mJ3w4KAcPVV2hHnEZ3oMW1T1A==", null, false, null, "b4bdbefd-5d8f-4ccd-aa24-5930aa75aa68", null, false, "User6" }
                });

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
