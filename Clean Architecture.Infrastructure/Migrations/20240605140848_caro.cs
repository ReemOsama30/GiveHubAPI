using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clean_Architecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class caro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "439213c3-e1c8-4fc5-a601-9d441a657dbd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7395d769-fbb4-476e-ad52-1fd8c197ea76");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b3582ec-0f20-46a0-8d98-39b6d489b18b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1190c3b-c773-401c-9df6-74a267330255");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43201d5-204e-4b66-80e8-f6cd8999083f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminId", "CharityId", "ConcurrencyStamp", "CorporateId", "DonorId", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4083cd11-6ad5-4c7d-ad87-8e5c36bc046e", 0, null, null, "c2f3b2c3-aadd-40a0-86ae-35b3a7bdb91c", null, null, "user4@example.com", false, false, false, null, null, null, "Johnson", "+1-555-3456", false, "5bbe9ded-8239-486a-8966-6f7a4deaf29e", false, "user4@example.com" },
                    { "44d2ae7f-df51-4fa0-87c1-c5a6fede0456", 0, null, null, "c0065ab8-5e31-46bc-bc98-4af8fe0c57bb", null, null, "user3@example.com", false, false, false, null, null, null, "Smith", "+1-555-9012", false, "462f412a-d174-40e5-a893-139c45bf1301", false, "user3@example.com" },
                    { "73a5c616-6d02-4dca-be1b-95e1c7fad149", 0, null, null, "95173c18-c5dc-414f-9f0e-9f3a84b2e664", null, null, "user1@example.com", false, false, false, null, null, null, "Doe", "+1-555-1234", false, "5f6217d4-9260-4107-af7e-985b19a50502", false, "user1@example.com" },
                    { "bf89eba9-b143-43d3-9da3-b5162c1e16dc", 0, null, null, "37638316-36ad-4887-b69e-fa33fe4a6532", null, null, "user2@example.com", false, false, false, null, null, null, "Doe", "+1-555-5678", false, "0a2ef224-3e22-493c-a40a-afbbba151b10", false, "user2@example.com" },
                    { "cb02fe7a-713f-4e42-bf89-186cbeda19ed", 0, null, null, "3e9033b6-8533-436a-a183-a5e3ce56e1d0", null, null, "user5@example.com", false, false, false, null, null, null, "William", "+1-555-7890", false, "35fb6a19-a198-4814-b74f-aed0c85ee77f", false, "user5@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4083cd11-6ad5-4c7d-ad87-8e5c36bc046e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44d2ae7f-df51-4fa0-87c1-c5a6fede0456");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73a5c616-6d02-4dca-be1b-95e1c7fad149");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf89eba9-b143-43d3-9da3-b5162c1e16dc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb02fe7a-713f-4e42-bf89-186cbeda19ed");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminId", "CharityId", "ConcurrencyStamp", "CorporateId", "DonorId", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "439213c3-e1c8-4fc5-a601-9d441a657dbd", 0, null, null, "d2e47942-3a68-4a99-b752-789a8d7a7a81", null, null, "user5@example.com", false, false, false, null, null, null, "William", "+1-555-7890", false, "d92c5224-c71f-4c56-ad61-1d8b9a529f02", false, "user5@example.com" },
                    { "7395d769-fbb4-476e-ad52-1fd8c197ea76", 0, null, null, "d3e18527-ac57-4643-a92f-00d3cbd83837", null, null, "user3@example.com", false, false, false, null, null, null, "Smith", "+1-555-9012", false, "87c9d6d6-c95f-4274-b164-7e7677c4c9d3", false, "user3@example.com" },
                    { "8b3582ec-0f20-46a0-8d98-39b6d489b18b", 0, null, null, "dd91ed34-4a5d-4793-913f-40c6184f9335", null, null, "user4@example.com", false, false, false, null, null, null, "Johnson", "+1-555-3456", false, "f9af17da-c001-4572-a1d9-a311f74a001b", false, "user4@example.com" },
                    { "b1190c3b-c773-401c-9df6-74a267330255", 0, null, null, "ce1a0496-1b29-4444-ace1-c31e4d656a5e", null, null, "user2@example.com", false, false, false, null, null, null, "Doe", "+1-555-5678", false, "b1c60598-2a02-49b5-8daf-e3c47ec76857", false, "user2@example.com" },
                    { "e43201d5-204e-4b66-80e8-f6cd8999083f", 0, null, null, "7f9be0be-f6e9-44cb-882b-ccd69a76c1dc", null, null, "user1@example.com", false, false, false, null, null, null, "Doe", "+1-555-1234", false, "0a8d5d0f-fc2b-4bc2-b66e-ebf2d53ba53c", false, "user1@example.com" }
                });
        }
    }
}
