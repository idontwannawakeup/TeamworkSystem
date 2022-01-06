using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamworkSystem.DataAccessLayer.Migrations
{
    public partial class UserNameNormalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "149630ea-0ebb-4214-bd4e-a541dfca0cc3", "USER4", "AQAAAAEAACcQAAAAEGn1LMT3CK1lXMxWm+e+6N0WLq+G7NshGln2F9jG+5qqOgWyzXho9mfa2+jIfXzyQw==", "432078a8-950a-418c-885a-7fd56beb8737" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a906f06-fc52-417b-bc81-352df8bbe721",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "144d68b8-63e2-48c4-acd8-2cd8316d913e", "USER11", "AQAAAAEAACcQAAAAEFnJorInaiPsydUJpWspVvu1NyKPba2pRyOQyA8h50VElR7oNRF5imrZIBFwoTTrcQ==", "e72a035f-af98-4ea7-a9d5-d7c9851f302c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b333929-f974-444e-a8d3-68f50a0459c0",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b1408b9-fe0a-4254-a58e-9f6824325300", "USER1", "AQAAAAEAACcQAAAAECmQEXccJ8B4nTSNZQrWwmjRyh01npelXW2kY6o9Tu8/h/TKfeAvmkHzoheZ9qVe6w==", "4cbd4b33-8036-4a26-9022-c45c1fd7a90e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3eabe644-8de8-4039-995e-ccb992392aad", "USER9", "AQAAAAEAACcQAAAAENowTh1Q4dJtePz0sykjEuOwvk2Nld4R946n48PuqHZcvvM7fZubeovOPtnsQy/yBQ==", "74077240-5b19-4728-ae94-ae16939ff404" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61dfb9e3-1c27-424a-9963-9586ca110220",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8c8a87a-0b7f-49f6-a42c-a30a0599d22b", "USER2", "AQAAAAEAACcQAAAAEKk3MHbV0ei9c6tkscTdakqcgm1zWxcO7snnmI+TKinAwGxcZtqogwe+Nv7F+0EHtQ==", "0631fdd6-c832-46c7-8b3d-b82f44053797" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7484e532-dc8e-4005-8b67-15ad8a421a37",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8426701b-adfb-4abf-b734-ec5cca23f146", "USER8", "AQAAAAEAACcQAAAAEMvZTgKMt0I5gcXM0mneA1wkhuTJf9Gac77TrT9lc7GZNYGtz7/16borf75PJV+f0A==", "39d72ee1-3969-4bb6-8acb-e6197c51fb30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3892a5bf-f922-4b90-86fc-dd4e95dbeb6c", "USER10", "AQAAAAEAACcQAAAAEL7NqxSKl+dOtVN0RoeXrUXhOva47WgM184+JjgFfJ2qyD30sYfCxtTPIol7tZxM2g==", "e4629507-efa8-44fc-a747-062d2a2e3a10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee840b31-951b-4cf3-9666-a32a0366ca66", "USER3", "AQAAAAEAACcQAAAAEAFAKhR8DNNmUQ47mbdElx3FVlYoqOD6F+Zm4QVC/pLvTyPi7w2aTEbT4POsYFiY0g==", "cd687bd4-9de8-4ed0-a994-1b64859b6ba5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae557ffc-2906-4913-bd26-40aa98a55570",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "140bac66-9d46-44a1-b775-389782bedf8b", "USER5", "AQAAAAEAACcQAAAAEGxBHbmtbnTLfmdAQ3iRCYvzm35F2RQ/axglltyvPfU8KciUmomiCXYNkSdCloLK3Q==", "e48ea17b-6d52-4457-8165-01cd2673e973" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c5522-0a02-4f23-bb6a-319529716a94",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5aeebc7f-5fe7-4e0b-bf21-5e1236f8ab4a", "USER7", "AQAAAAEAACcQAAAAEEiUNt1KP+OBBT0DbDrxl1ihnNCWiNeYAFRTkkfUcwH7CYtdO4JIGuZhp0Rdgmy/Aw==", "73ecae9c-d42a-454c-96a7-b986f64a96e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e23b1f8-c6d0-4b92-85f4-7483a3bdd494", "USER6", "AQAAAAEAACcQAAAAEAS2WUlNTCd4GnSBrz/Bp+t3HS71BFbUE+Q5OWw4DryPGaT9zt8EMVSFLA1j5kgdXA==", "224de995-ced3-40de-91d5-13e855c03568" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2021, 6, 21, 20, 37, 50, 96, DateTimeKind.Local).AddTicks(3022));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbfe6b7a-6d17-4eeb-ab9c-ae8cd6536f14", null, "AQAAAAEAACcQAAAAEHPgR5Hc+ihQA67Efszi9hyIx7t/YrUF8YrpcA9P2bqAAYUr7Cg+/HTbl3xkfWl1ng==", "aecde283-7db1-46e8-9299-41f9c8a45acd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a906f06-fc52-417b-bc81-352df8bbe721",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c59635a-2c32-4245-b37d-9104ebf60455", null, "AQAAAAEAACcQAAAAENku2IV7UEIt6JbIdIX+JzWSXtKFfWsPyVkXqFrrluezGvO1sghvX4O9Z/nyRCYAYQ==", "9634b0f8-1e5e-45b9-8e15-723bd7b32800" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b333929-f974-444e-a8d3-68f50a0459c0",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc7cecac-b3a3-4ab2-8250-f9c13a1a1744", null, "AQAAAAEAACcQAAAAEPLZcHMWVpueMkvsnDtaroPQ/KZF6lVpgAa6sk+qBXlZzdlIjarehgQF3hjOvnxlhw==", "289af02b-0438-4969-863f-8156158ea3f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9dd32f9-8a9e-440a-a925-25e1d122223c", null, "AQAAAAEAACcQAAAAEONaEM+/CXcsJ4nYHxPEUx76DosoX7WqK2SfnIkwi/oZYCSQmXbZSB8H0YTqXBtQWA==", "f1009259-2396-47b6-a4db-a1f79e5c011f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61dfb9e3-1c27-424a-9963-9586ca110220",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cea8b126-979a-4d7e-a7f1-694234804247", null, "AQAAAAEAACcQAAAAEKCCLLN22UJDj7FzIXEwJAoK4O9PlS2XhndeR1c82rmgT2iAeAmRZ0NcrYvM6RkKqw==", "4eb51f5f-c0d5-4e46-9563-76fc2c2caa8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7484e532-dc8e-4005-8b67-15ad8a421a37",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60d987b4-045f-4213-adba-ed65354cb746", null, "AQAAAAEAACcQAAAAEMiU01V8zfkYMRdbAB1gNuVQxilRhaw6CgrOVI4+V6GyGgzTCL58ceBFeVJAB3RMbQ==", "771a6724-f037-4004-a980-601dfb32e910" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca5d29b-46ca-44f1-92ba-33cd849ea575", null, "AQAAAAEAACcQAAAAEBKFHtQPTzymXSRBKwqAq8dXqHRtf+71RCYMufNPhJDcISG/9Md92z02pSVLL+h4/A==", "4008e9f5-73ee-425f-b172-fe5ee1fe3b3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84f65ecf-ca5f-487f-9dc1-fa7bcfd2befb", null, "AQAAAAEAACcQAAAAEB+5u1bKlNGCHc/iMXqQ83WxLA+NGgIlBgJoSGSe7QXfforsJnUnK3izvf1bARy7BA==", "5746a5ee-2945-4bf3-903e-afac790b581d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae557ffc-2906-4913-bd26-40aa98a55570",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b94672f3-c461-43f6-a62d-62a151f30a9e", null, "AQAAAAEAACcQAAAAEMQA31d5n9ZJp4gPknAMhTwGjsr1ThMPWlgOxe+Srt1u8sV9b53EMTWaXG1cRFrGtQ==", "00e7872a-d04e-411c-abba-9771d813ab9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c5522-0a02-4f23-bb6a-319529716a94",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "819e89e9-e98f-499b-85b4-15bda3e1df3c", null, "AQAAAAEAACcQAAAAEKrKz0HVqwZH+dd6x8GtpW5yiq6h7vPT3xDfRviaciyB9qI697Ga7l4wN+LAZ6ZRWg==", "ffe78ca5-bcd1-4650-9096-c484eb39cdaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca3d4ec2-65f9-4f18-bf52-d8ec1c52c5c2", null, "AQAAAAEAACcQAAAAEPLyObs8N0P0gP6mo+mERHtDRfpdfd+u+9YeWoIfa2HFub4XiE341B5GrHcR+ToDmA==", "127677c8-1b0d-4858-8e33-ac6c129debc8" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2021, 5, 25, 13, 27, 52, 436, DateTimeKind.Local).AddTicks(7346));
        }
    }
}
