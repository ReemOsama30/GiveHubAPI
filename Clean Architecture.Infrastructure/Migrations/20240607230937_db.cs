using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clean_Architecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d871073-cc23-473d-bfd8-68129b9b9005");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f36c01f-0e1a-4d4c-8a44-80c3b9b9af00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72cf3156-6864-4e9c-9488-b8fac6396a81");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4a669ab-841e-4dce-ae0c-ee461f7c50d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d77cfd1c-3d7a-4177-9ed7-499cf2765e94");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3d871073-cc23-473d-bfd8-68129b9b9005", 0, "Donor", null, null, "d25bd572-d7d6-4985-890d-a4207f35e9ea", null, null, "user3@example.com", false, false, false, null, null, null, "Smith", "+1-555-9012", false, "4c76ac2f-72f6-4e2b-bded-bdf56387f822", false, "user3@example.com" },
                    { "4f36c01f-0e1a-4d4c-8a44-80c3b9b9af00", 0, "Donor", null, null, "5416cfb1-e645-49f7-aea9-1018df12ee1d", null, null, "user2@example.com", false, false, false, null, null, null, "Doe", "+1-555-5678", false, "b6b2f00b-e7a7-4250-9e69-1f661d497ce1", false, "user2@example.com" },
                    { "72cf3156-6864-4e9c-9488-b8fac6396a81", 0, "Donor", null, null, "7f591a89-8272-4b27-a627-73310bcafaf3", null, null, "user1@example.com", false, false, false, null, null, null, "Doe", "+1-555-1234", false, "e5dd76df-8282-470d-80c0-ef5c09d828fa", false, "user1@example.com" },
                    { "c4a669ab-841e-4dce-ae0c-ee461f7c50d6", 0, "Donor", null, null, "a1ac0a32-9cd3-4740-a49d-c8ddb383ba59", null, null, "user4@example.com", false, false, false, null, null, null, "Johnson", "+1-555-3456", false, "c1562e22-b995-49f1-919b-d7d342e3d056", false, "user4@example.com" },
                    { "d77cfd1c-3d7a-4177-9ed7-499cf2765e94", 0, "Donor", null, null, "0d605a5e-3958-4b40-ab6f-f2b9fdef7665", null, null, "user5@example.com", false, false, false, null, null, null, "William", "+1-555-7890", false, "532dab97-79e8-4546-a123-75e021702ae1", false, "user5@example.com" }
                });
        }
    }
}
