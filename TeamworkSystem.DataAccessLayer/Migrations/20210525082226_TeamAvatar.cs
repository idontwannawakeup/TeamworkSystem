using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamworkSystem.DataAccessLayer.Migrations
{
    public partial class TeamAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78e964b8-cd74-4e51-a3a4-66e991262562", "99276256-def5-40d2-b368-14ae49374744" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a906f06-fc52-417b-bc81-352df8bbe721",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e576c01f-53a9-4c30-a143-cd2005f537dd", "1865d845-aa3b-4efc-881c-b54d6589b4b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b333929-f974-444e-a8d3-68f50a0459c0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "30487bd1-d3a6-4e3c-9b9d-7745ca79787a", "7e39ba04-9d04-4d18-947d-de890ed90e56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b2c643a0-f118-4cfe-a59b-bd1b8ace624e", "12ec1f1e-3194-4895-9394-d925bc5bb5c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61dfb9e3-1c27-424a-9963-9586ca110220",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "799f0bc2-f54b-4618-b56d-4f6b47224cdd", "5ae0377e-83e8-4dab-84a1-425d56c52fae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7484e532-dc8e-4005-8b67-15ad8a421a37",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e1c2c990-1a12-44b3-89e4-947e119b4dad", "4633a032-241a-4dbd-bf58-2be53bf7d922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5d263f3b-b5e0-4128-9506-d84fae26682d", "d362dfe4-06ab-4bf8-9c92-97973691b23d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2637f8ab-b415-4d9c-bf41-1b75ab8f5b45", "27e12c3e-9b28-4799-9165-5e52229b5595" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae557ffc-2906-4913-bd26-40aa98a55570",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8d5ef861-3f7a-469b-b310-77465f784c74", "8ecc0a3e-2662-403b-abfa-c77c26277100" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c5522-0a02-4f23-bb6a-319529716a94",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3eefbd2a-9b44-4a1a-87fb-371ba050e636", "a832cdbd-6eae-4e0e-b8eb-2adf140aba87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a9ee1fa3-988b-4c16-9f55-068a7f3dbf84", "37aeabaa-4d09-477f-9fd2-9ccecab98562" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2021, 5, 25, 11, 22, 24, 884, DateTimeKind.Local).AddTicks(6378));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Teams");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f7f8edb0-f6c7-4ad6-9c75-48a3f53a2d4b", "3b0c059a-7007-4f35-8cf7-857e235a72fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a906f06-fc52-417b-bc81-352df8bbe721",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8fc09eca-f9f4-4436-a52d-3372d310fc4a", "591f7ac7-d2d4-48b9-9383-1f51c34cc518" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b333929-f974-444e-a8d3-68f50a0459c0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e4f87b5c-715f-420f-9476-9d618e0c8b47", "83a04ab2-2166-4456-8723-2ac4f2db4c3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76c92ffb-7a97-4e3a-a2a8-43eae41579ed", "b5460119-e25f-4e64-9d8b-5eba29c78b50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61dfb9e3-1c27-424a-9963-9586ca110220",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4ae280e5-5e47-4ca2-b429-73125871a929", "609f3bbb-7736-456e-aa93-bb0ee83684fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7484e532-dc8e-4005-8b67-15ad8a421a37",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d1b0e1b-113c-4647-af7f-56758e36e472", "2cb62b6d-a311-4de9-ae21-291b20cbbe82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3fed1973-133f-48dc-83f4-e916a0504a34", "cda0cdb3-f982-4c40-a304-1163a2fa913b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "99cbda91-c128-4936-8792-7f74fc74c56a", "45868622-8baa-4930-a933-c59c28f3c35b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae557ffc-2906-4913-bd26-40aa98a55570",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e242880c-ae3d-40c6-aeab-8eb7330c4104", "dc135687-1086-4b12-bbff-d923b722c6d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c5522-0a02-4f23-bb6a-319529716a94",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5f92bd2d-1715-4664-9aa8-7b5d6f28fc8a", "fd11771d-44ad-487b-b872-c09cf775b8bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7713b5b8-32c1-4735-89c4-f43b5fb5e337", "13905638-3911-4443-b155-8415c33256b1" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2021, 5, 25, 2, 10, 4, 544, DateTimeKind.Local).AddTicks(8794));
        }
    }
}
