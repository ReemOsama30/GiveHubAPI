using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean_Architecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64c028df-c13b-4500-99ff-8c03ddc861d6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0e4173f-0370-454f-9b8f-dab1d9e84b82", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0e4173f-0370-454f-9b8f-dab1d9e84b82");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64c028df-c13b-4500-99ff-8c03ddc861d6", null, "Admin", "ADMIN" });
        }
    }
}
