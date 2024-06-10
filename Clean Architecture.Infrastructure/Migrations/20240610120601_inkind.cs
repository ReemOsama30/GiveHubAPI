using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clean_Architecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inkind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28093d8d-bb06-4dae-bff2-3e4eddf243a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "600e7112-1094-4286-a2e4-d13b784c0a55");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "898411e6-cf74-4464-b474-eb9e4e6131cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfb04fda-7948-4460-b1bc-1d6f8f2b8ae9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5bf5aad-633c-4a10-a508-42e1da485f29");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "AdminId", "CharityId", "ConcurrencyStamp", "CorporateId", "DonorId", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d6ab7d2-93f8-4f1f-9f76-3f11b0a942e6", 0, "Donor", null, null, "8bacfee3-61fd-44b8-b560-31388e5d8c8a", null, null, "user2@example.com", false, false, false, null, null, null, "Doe", "+1-555-5678", false, "b8909d1e-7494-4c74-98ab-077e9d1cae4a", false, "user2@example.com" },
                    { "5fd6f1ce-3758-4381-ade0-4ef74fae5b17", 0, "Donor", null, null, "891a15da-6bd1-4e23-bee4-34486c727f02", null, null, "user3@example.com", false, false, false, null, null, null, "Smith", "+1-555-9012", false, "91b976fc-084d-49de-964a-f05e62ae04b7", false, "user3@example.com" },
                    { "6fd7eb52-b907-4227-9753-99373ae91eac", 0, "Donor", null, null, "fd51d122-5f3b-40f0-83be-28bdc3839d23", null, null, "user5@example.com", false, false, false, null, null, null, "William", "+1-555-7890", false, "520bb0d1-f85d-47d2-8eca-e6b37159e44a", false, "user5@example.com" },
                    { "7ed7b474-c12b-40cb-bb90-1d13d399c32d", 0, "Donor", null, null, "d5366998-b177-4499-907b-f7e5752b9c73", null, null, "user1@example.com", false, false, false, null, null, null, "Doe", "+1-555-1234", false, "1bbdcadc-4b33-47b3-ae4e-635126f9b04c", false, "user1@example.com" },
                    { "d67ca6c6-8fd7-4f17-add0-acd32e8855a2", 0, "Donor", null, null, "bf346582-3fc6-45d6-b2b4-47caf8618dac", null, null, "user4@example.com", false, false, false, null, null, null, "Johnson", "+1-555-3456", false, "efd0081c-2d2a-42ac-9460-18c99ab7ba3a", false, "user4@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d6ab7d2-93f8-4f1f-9f76-3f11b0a942e6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5fd6f1ce-3758-4381-ade0-4ef74fae5b17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fd7eb52-b907-4227-9753-99373ae91eac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ed7b474-c12b-40cb-bb90-1d13d399c32d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d67ca6c6-8fd7-4f17-add0-acd32e8855a2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "AdminId", "CharityId", "ConcurrencyStamp", "CorporateId", "DonorId", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "28093d8d-bb06-4dae-bff2-3e4eddf243a7", 0, "Donor", null, null, "c7e82b0e-73ee-42f7-8204-531bfbc0c86d", null, null, "user2@example.com", false, false, false, null, null, null, "Doe", "+1-555-5678", false, "0a34820e-a16a-4b94-9de2-e9f610eff1c1", false, "user2@example.com" },
                    { "600e7112-1094-4286-a2e4-d13b784c0a55", 0, "Donor", null, null, "6f0c37e6-83a0-46e4-a51a-dc87afe792fa", null, null, "user4@example.com", false, false, false, null, null, null, "Johnson", "+1-555-3456", false, "e0ad3139-07df-4fff-a157-8babc8555b68", false, "user4@example.com" },
                    { "898411e6-cf74-4464-b474-eb9e4e6131cb", 0, "Donor", null, null, "b8dda723-7001-4b83-b7ac-92df48eef369", null, null, "user5@example.com", false, false, false, null, null, null, "William", "+1-555-7890", false, "e9b3945a-98fe-4a9e-866e-eff7de705bc2", false, "user5@example.com" },
                    { "cfb04fda-7948-4460-b1bc-1d6f8f2b8ae9", 0, "Donor", null, null, "f7232fbd-4b5c-45db-a13e-78b3634a4f1e", null, null, "user3@example.com", false, false, false, null, null, null, "Smith", "+1-555-9012", false, "527f0e4b-7c5f-4b2f-89ff-7c21dacce3a8", false, "user3@example.com" },
                    { "f5bf5aad-633c-4a10-a508-42e1da485f29", 0, "Donor", null, null, "e741fc49-bff0-4b2b-81fd-34df52157fb3", null, null, "user1@example.com", false, false, false, null, null, null, "Doe", "+1-555-1234", false, "9ea996b0-cac1-4b8c-835a-f71093747972", false, "user1@example.com" }
                });
        }
    }
}
