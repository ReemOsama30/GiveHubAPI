using System;
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
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdDesign = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CharityId = table.Column<int>(type: "int", nullable: true),
                    CorporateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    DonorId = table.Column<int>(type: "int", nullable: true),
                    CharityId = table.Column<int>(type: "int", nullable: true),
                    CorporateId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "charities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_charities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_charities_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "corporations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CSRProgramDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corporations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_corporations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_donors_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRecived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Icon = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: true),
                    CharityId = table.Column<int>(type: "int", nullable: true),
                    CorporateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badges_charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "charities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Badges_corporations_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "corporations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Badges_donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "donors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DonorID = table.Column<int>(type: "int", nullable: true),
                    CharityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "charities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reviews_donors_DonorID",
                        column: x => x.DonorID,
                        principalTable: "donors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    CorporateId = table.Column<int>(type: "int", nullable: true),
                    projectId = table.Column<int>(type: "int", nullable: true),
                    CharityId = table.Column<int>(type: "int", nullable: true),
                    DonationType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_donations_charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "charities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_donations_corporations_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "corporations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_donations_donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donationsReport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donationsReport", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FundingGoal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountRaised = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Img = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: true),
                    CharityId = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projects_charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_donationsReport_ReportId",
                        column: x => x.ReportId,
                        principalTable: "donationsReport",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_projects_donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "donors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminId", "CharityId", "ConcurrencyStamp", "CorporateId", "DonorId", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2c673213-ef3f-4d7b-b484-cc88b6a5130b", 0, null, null, "f6d19909-7b8e-496a-b4ff-f6f4ff61bfdd", null, null, "user2@example.com", false, false, false, null, null, null, "Doe", "+1-555-5678", false, "ff1165c8-0ddb-440c-97da-7e6b1bb1619b", false, "user2@example.com" },
                    { "2f81ede5-ef00-481a-8650-e4aee9482ebc", 0, null, null, "51cda152-56b3-4b26-87b9-cb6e39c6947c", null, null, "user3@example.com", false, false, false, null, null, null, "Smith", "+1-555-9012", false, "77222550-a3a3-4814-9b27-016da8a44042", false, "user3@example.com" },
                    { "34b5c9f7-52da-41fc-a994-11921c5a0792", 0, null, null, "b1a43fe1-1e47-4050-b873-64bcf2b81930", null, null, "user4@example.com", false, false, false, null, null, null, "Johnson", "+1-555-3456", false, "294b7bfd-470d-4405-a3b3-e3848eef9ae9", false, "user4@example.com" },
                    { "7390dafc-8c6f-40f2-a47e-3db683552686", 0, null, null, "bfdf0101-a765-4ca9-a2b1-589b8ad74ca5", null, null, "user5@example.com", false, false, false, null, null, null, "William", "+1-555-7890", false, "80a3ed6b-9bd6-4d7c-8366-4b8305a55f99", false, "user5@example.com" },
                    { "ee1b449a-a0a3-4604-b253-78209eed1a1d", 0, null, null, "1cc206ee-ab0b-49fe-a5c3-84b54e61addd", null, null, "user1@example.com", false, false, false, null, null, null, "Doe", "+1-555-1234", false, "c13a0c10-d101-4aef-a5c5-4b8066dd7852", false, "user1@example.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ApplicationUserId",
                table: "Admins",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_CharityId",
                table: "Advertisments",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_CorporateId",
                table: "Advertisments",
                column: "CorporateId");

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
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CharityId",
                table: "AspNetUsers",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CorporateId",
                table: "AspNetUsers",
                column: "CorporateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonorId",
                table: "AspNetUsers",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_CharityId",
                table: "Badges",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_CorporateId",
                table: "Badges",
                column: "CorporateId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_DonorId",
                table: "Badges",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_charities_ApplicationUserId",
                table: "charities",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_corporations_ApplicationUserId",
                table: "corporations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_CharityId",
                table: "donations",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_CorporateId",
                table: "donations",
                column: "CorporateId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_DonorId",
                table: "donations",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_projectId",
                table: "donations",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_donationsReport_ProjectId",
                table: "donationsReport",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_donors_ApplicationUserId",
                table: "donors",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_CharityId",
                table: "projects",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_DonorId",
                table: "projects",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_ReportId",
                table: "projects",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_CharityId",
                table: "reviews",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_DonorID",
                table: "reviews",
                column: "DonorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_ApplicationUserId",
                table: "Admins",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisments_charities_CharityId",
                table: "Advertisments",
                column: "CharityId",
                principalTable: "charities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisments_corporations_CorporateId",
                table: "Advertisments",
                column: "CorporateId",
                principalTable: "corporations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_charities_CharityId",
                table: "AspNetUsers",
                column: "CharityId",
                principalTable: "charities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_corporations_CorporateId",
                table: "AspNetUsers",
                column: "CorporateId",
                principalTable: "corporations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_donors_DonorId",
                table: "AspNetUsers",
                column: "DonorId",
                principalTable: "donors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_donations_projects_projectId",
                table: "donations",
                column: "projectId",
                principalTable: "projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_donationsReport_projects_ProjectId",
                table: "donationsReport",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_ApplicationUserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_charities_AspNetUsers_ApplicationUserId",
                table: "charities");

            migrationBuilder.DropForeignKey(
                name: "FK_corporations_AspNetUsers_ApplicationUserId",
                table: "corporations");

            migrationBuilder.DropForeignKey(
                name: "FK_donors_AspNetUsers_ApplicationUserId",
                table: "donors");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_charities_CharityId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_donors_DonorId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_donationsReport_projects_ProjectId",
                table: "donationsReport");

            migrationBuilder.DropTable(
                name: "Advertisments");

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
                name: "Badges");

            migrationBuilder.DropTable(
                name: "donations");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "corporations");

            migrationBuilder.DropTable(
                name: "charities");

            migrationBuilder.DropTable(
                name: "donors");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "donationsReport");
        }
    }
}
