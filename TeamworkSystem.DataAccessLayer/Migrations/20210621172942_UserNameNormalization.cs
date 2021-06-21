using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                values: new object[] { "689d09a5-5793-471e-ae47-da4c2e790375", "USER4", "AQAAAAEAACcQAAAAEC/JuX9CdJsZ5489y19EefqL5KW+BabDyAwyfF594rIFATve7wM31OzBidKEB84PGw==", "d38277c2-1d2b-4ec7-abbb-498798243976" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a906f06-fc52-417b-bc81-352df8bbe721",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a56878b-042a-4434-af8a-980a67ed2c6f", "USER11", "AQAAAAEAACcQAAAAEKT4RSYR2WPB23ECuB9ANU/6rAXxgzIqL+AAla2WOjwMaz2LdyY9hGZlx6Egy/2j2Q==", "e23022bb-902c-4d80-817f-78c36cba59ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b333929-f974-444e-a8d3-68f50a0459c0",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf20f159-bb03-4c33-8814-acf924d81a0e", "USER1", "AQAAAAEAACcQAAAAELOZVtITf+IQ1i/jCWYXw0nt7cIlx4YbZ/+K46PiJM9FyiylUBZWjGOeaSYE1XvZ5Q==", "5bf3a1e9-c312-4995-b04d-d61b49df7b78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4889cba4-8f30-41a5-aa36-8850de188917", "USER9", "AQAAAAEAACcQAAAAEK9tsdIWIuzxroPRDBwPOKL3K6C6xcn2I3Kk7i9YY92Xu3EPVC9sYtgtY872tlI/tw==", "c57bb0b3-7762-4459-a9d8-dceb6253f215" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61dfb9e3-1c27-424a-9963-9586ca110220",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "841ab518-3341-47ab-9e48-4fee5a1c185f", "USER2", "AQAAAAEAACcQAAAAEKBMWpKba8vDVYKoFj1iDDYiw4/ecRKHsRCqThdd+urqfuOpgNW/FtC00kIyVYNsEA==", "33f4729c-5da2-475b-8701-863195a62a39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7484e532-dc8e-4005-8b67-15ad8a421a37",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41389a79-cb77-489c-aa40-04857e3b14ee", "USER8", "AQAAAAEAACcQAAAAEIDJ+Ab1VJWFZ8XfBw+iGNkjmAbhYZW+me100Z9aizOlXzvoezkoOfkZiM+7V427uA==", "e667828c-ffe6-433d-9418-2d6cb0c3a52e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "349943d8-454f-4d2b-9256-4769fd591809", "USER10", "AQAAAAEAACcQAAAAEIrbjXPqhnjl5RfJ0/GEjuAP2eV7ZXb9t7CiLYxPfAHfz25FO8O/M4hQeOSZ2mBDCQ==", "8dbb6375-d129-4bae-b288-5c87fddc48f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "485caadd-7648-4c33-82fc-825aaa6e0d02", "USER3", "AQAAAAEAACcQAAAAEK5p8Rw11F3O7va+wueUov/5II+hEfWHzE50IZqt1WDUt0ksMKex50l+xrfUu/bb0Q==", "0908e96b-508c-4cd6-97fd-86da0d7ca458" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae557ffc-2906-4913-bd26-40aa98a55570",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcf2c910-a9b2-4cd8-887f-3af77273448b", "USER5", "AQAAAAEAACcQAAAAEGuwe51khfG028AISavMvNeAp6E+eE7nFurHx69uhixcS8f6wfUnL2ojuFFCBIuT8w==", "b46fdb42-81a0-4cfd-a8bb-9fbea41b61a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c5522-0a02-4f23-bb6a-319529716a94",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aec106ff-c321-426e-83a3-9f934a072d67", "USER7", "AQAAAAEAACcQAAAAEAtYQ0GOfH7Zbqi5JU3KpDGZNpa0KvoMRNxznHG2LWvzr5aKpG/5Ct503KefbzzLSw==", "bc2cde77-767a-44eb-b0da-e85116d6fce4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53e7f86e-fa1b-49a1-9d71-2e191ef9dc1a", "USER6", "AQAAAAEAACcQAAAAECgP+YDi0IfnBMrnI8IQdStV1n5EPypSN4nX3DSS9JpQdENona3iurDFiyn90iKCaQ==", "71ca9c68-efa3-4d0a-ba8f-06df44a1f1ed" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2021, 6, 21, 20, 29, 40, 993, DateTimeKind.Local).AddTicks(4421));
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
