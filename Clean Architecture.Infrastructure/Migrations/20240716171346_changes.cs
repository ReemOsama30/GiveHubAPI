using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean_Architecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88b51ce2-6ccb-4955-ab2c-1b0889ac22aa");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "donors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AccountState",
                table: "charities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "charities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4282d853-6dc2-41a4-8dc9-64a1dd05a105", null, "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4282d853-6dc2-41a4-8dc9-64a1dd05a105");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "donors");

            migrationBuilder.DropColumn(
                name: "AccountState",
                table: "charities");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "charities");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88b51ce2-6ccb-4955-ab2c-1b0889ac22aa", null, "Admin", "ADMIN" });
        }
    }
}
