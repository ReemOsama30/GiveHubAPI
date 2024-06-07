using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clean_Architecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "316e1122-3cc3-41a4-bc6d-bad30dd9f4b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4de4f404-9b4a-4468-86d6-5d0a08e9f43d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aeb1d7f4-0e55-4621-8d26-3ef696d86968");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc3173c1-2ac9-4ee1-b67b-28c2c9c3abaa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e819adc5-691d-4fc2-9963-9c22136fc4af");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "AdminId", "CharityId", "ConcurrencyStamp", "CorporateId", "DonorId", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "88cc91c6-559e-4fc1-b517-fcd6d7c32d61", 0, "Donor", null, null, "e98b2378-c501-43ba-917b-fb1297047cad", null, null, "user5@example.com", false, false, false, null, null, null, "William", "+1-555-7890", false, "bde2bccf-3748-47a2-b1f8-2b7eafa0d5c6", false, "user5@example.com" },
                    { "ac260993-7771-4b05-a003-6abca811ff7e", 0, "Donor", null, null, "4b705f79-ac6a-4547-b197-29f8a0e9b752", null, null, "user4@example.com", false, false, false, null, null, null, "Johnson", "+1-555-3456", false, "ec22db7a-1ed9-4e65-b23c-b8e4a9b5e1c2", false, "user4@example.com" },
                    { "cc412f8f-c6c2-4d4b-9295-770e9f3fdb6b", 0, "Donor", null, null, "28e50d36-7585-4178-96f9-c25acb941638", null, null, "user1@example.com", false, false, false, null, null, null, "Doe", "+1-555-1234", false, "af1c01ff-143f-4dea-9090-f779a8abddde", false, "user1@example.com" },
                    { "f163ce9f-1b64-496f-b18e-43ba132bb445", 0, "Donor", null, null, "daf7c596-b2cc-494b-8045-577e05b8c2b1", null, null, "user2@example.com", false, false, false, null, null, null, "Doe", "+1-555-5678", false, "9a6b6fe8-24e1-4f71-a890-44352d1065d9", false, "user2@example.com" },
                    { "fea2d9c3-9866-4ae9-9e11-e38697a401b1", 0, "Donor", null, null, "5c77549d-8cce-4e4e-a7be-f5689ff4a545", null, null, "user3@example.com", false, false, false, null, null, null, "Smith", "+1-555-9012", false, "318fd67f-7e1b-4946-86d3-244925d1dfd0", false, "user3@example.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88cc91c6-559e-4fc1-b517-fcd6d7c32d61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac260993-7771-4b05-a003-6abca811ff7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc412f8f-c6c2-4d4b-9295-770e9f3fdb6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f163ce9f-1b64-496f-b18e-43ba132bb445");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fea2d9c3-9866-4ae9-9e11-e38697a401b1");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminId", "CharityId", "ConcurrencyStamp", "CorporateId", "DonorId", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "316e1122-3cc3-41a4-bc6d-bad30dd9f4b2", 0, null, null, "ae506d52-fa8d-4fda-8246-faea77ddfd3b", null, null, "user1@example.com", false, false, false, null, null, null, "Doe", "+1-555-1234", false, "22950d99-2390-464a-be23-6c0e7a658d61", false, "user1@example.com" },
                    { "4de4f404-9b4a-4468-86d6-5d0a08e9f43d", 0, null, null, "9c587095-e796-4509-b5f2-9ae5a0c29d86", null, null, "user4@example.com", false, false, false, null, null, null, "Johnson", "+1-555-3456", false, "3a365e09-9021-4e23-8698-02a1826a3120", false, "user4@example.com" },
                    { "aeb1d7f4-0e55-4621-8d26-3ef696d86968", 0, null, null, "215d7d6b-9e39-46c4-bcca-677d4129e8d3", null, null, "user2@example.com", false, false, false, null, null, null, "Doe", "+1-555-5678", false, "0fc84333-41cc-4444-b14b-319a4f030798", false, "user2@example.com" },
                    { "dc3173c1-2ac9-4ee1-b67b-28c2c9c3abaa", 0, null, null, "23bb6ec2-e1d4-49f6-a616-4bdef3da8cc6", null, null, "user3@example.com", false, false, false, null, null, null, "Smith", "+1-555-9012", false, "54d41c87-9b8f-44d1-a363-fed874bc1f87", false, "user3@example.com" },
                    { "e819adc5-691d-4fc2-9963-9c22136fc4af", 0, null, null, "29965ae7-594c-439b-91a2-31fcfbf1ab84", null, null, "user5@example.com", false, false, false, null, null, null, "William", "+1-555-7890", false, "d14705b5-c05a-4df6-9612-daab23727918", false, "user5@example.com" }
                });
        }
    }
}
