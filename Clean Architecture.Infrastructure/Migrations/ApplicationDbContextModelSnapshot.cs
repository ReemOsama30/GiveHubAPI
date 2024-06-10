﻿// <auto-generated />
using System;
using Clean_Architecture.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clean_Architecture.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("charityPulse.core.Models.Admin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("charityPulse.core.Models.Advertisment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("AdDesign")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("CharityId")
                        .HasColumnType("int");

                    b.Property<int?>("CorporateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("CorporateId");

                    b.ToTable("Advertisments");
                });

            modelBuilder.Entity("charityPulse.core.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<int?>("CharityId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CorporateId")
                        .HasColumnType("int");

                    b.Property<int?>("DonorId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CharityId");

                    b.HasIndex("CorporateId");

                    b.HasIndex("DonorId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {

                            Id = "7ed7b474-c12b-40cb-bb90-1d13d399c32d",
                            AccessFailedCount = 0,
                            AccountType = "Donor",
                            ConcurrencyStamp = "d5366998-b177-4499-907b-f7e5752b9c73",


                            Email = "user1@example.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@EXAMPLE.COM",
                            NormalizedUserName = "USER1@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPytr5fctLYTt00mLs+dDYRcHueIqFhzrrkXwJnk0FMYf+RZcALx9Prtk7DHg4iwwA==",
                            PhoneNumber = "+1-555-1234",
                            PhoneNumberConfirmed = false,

                            SecurityStamp = "1bbdcadc-4b33-47b3-ae4e-635126f9b04c",


                            TwoFactorEnabled = false,
                            UserName = "user1@example.com"
                        },
                        new
                        {

                            Id = "0d6ab7d2-93f8-4f1f-9f76-3f11b0a942e6",
                            AccessFailedCount = 0,
                            AccountType = "Donor",
                            ConcurrencyStamp = "8bacfee3-61fd-44b8-b560-31388e5d8c8a",



                            Email = "user2@example.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@EXAMPLE.COM",
                            NormalizedUserName = "USER2@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAT5q1tUkd5Xdg0vltcpJoEoOfnGVBxyrDM9kPBpTcHPvnMZEFXer+OBlJFg37QI+g==",
                            PhoneNumber = "+1-555-5678",
                            PhoneNumberConfirmed = false,

                            SecurityStamp = "b8909d1e-7494-4c74-98ab-077e9d1cae4a",
                            TwoFactorEnabled = false,
                            UserName = "user2@example.com"
                        },
                        new
                        {
                            Id = "5fd6f1ce-3758-4381-ade0-4ef74fae5b17",
                            AccessFailedCount = 0,
                            AccountType = "Donor",
                            ConcurrencyStamp = "891a15da-6bd1-4e23-bee4-34486c727f02",
                            Email = "user3@example.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            PasswordHash = "Smith",
                            PhoneNumber = "+1-555-9012",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "91b976fc-084d-49de-964a-f05e62ae04b7",
                            TwoFactorEnabled = false,
                            UserName = "user3@example.com"
                        },
                        new
                        {
                            Id = "d67ca6c6-8fd7-4f17-add0-acd32e8855a2",
                            AccessFailedCount = 0,
                            AccountType = "Donor",
                            ConcurrencyStamp = "bf346582-3fc6-45d6-b2b4-47caf8618dac",
                            Email = "user4@example.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            PasswordHash = "Johnson",
                            PhoneNumber = "+1-555-3456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "efd0081c-2d2a-42ac-9460-18c99ab7ba3a",
                            TwoFactorEnabled = false,
                            UserName = "user4@example.com"
                        },
                        new
                        {
                            Id = "6fd7eb52-b907-4227-9753-99373ae91eac",
                            AccessFailedCount = 0,
                            AccountType = "Donor",
                            ConcurrencyStamp = "fd51d122-5f3b-40f0-83be-28bdc3839d23",
                            Email = "user5@example.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            PasswordHash = "William",
                            PhoneNumber = "+1-555-7890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "520bb0d1-f85d-47d2-8eca-e6b37159e44a",
                            TwoFactorEnabled = false,
                            UserName = "user5@example.com"


                        });
                });

            modelBuilder.Entity("charityPulse.core.Models.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharityId")
                        .HasColumnType("int");

                    b.Property<int?>("CorporateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRecived")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DonorId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Icon")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("CorporateId");

                    b.HasIndex("DonorId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("charityPulse.core.Models.Charity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfileImg")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("charities");
                });

            modelBuilder.Entity("charityPulse.core.Models.Corporate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CSRProgramDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfileImg")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("corporations");
                });

            modelBuilder.Entity("charityPulse.core.Models.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharityId")
                        .HasColumnType("int");

                    b.Property<int?>("CorporateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonationType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("DonorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("projectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("CorporateId");

                    b.HasIndex("DonorId");

                    b.HasIndex("projectId");

                    b.ToTable("donations");

                    b.HasDiscriminator<string>("DonationType").HasValue("Donation");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("charityPulse.core.Models.DonationReport", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Results")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ProjectId");

                    b.ToTable("donationsReport");
                });

            modelBuilder.Entity("charityPulse.core.Models.Donor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfileImg")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("donors");
                });

            modelBuilder.Entity("charityPulse.core.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountRaised")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DonorId")
                        .HasColumnType("int");

                    b.Property<decimal>("FundingGoal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("Img")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ReportId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("DonorId");

                    b.HasIndex("ReportId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("charityPulse.core.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharityId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DonorID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("DonorID");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("charityPulse.core.Models.InKindDonation", b =>
                {
                    b.HasBaseType("charityPulse.core.Models.Donation");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("InKind");
                });

            modelBuilder.Entity("charityPulse.core.Models.MoneyDonation", b =>
                {
                    b.HasBaseType("charityPulse.core.Models.Donation");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Monetary");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("charityPulse.core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("charityPulse.core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("charityPulse.core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("charityPulse.core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("charityPulse.core.Models.Admin", b =>
                {
                    b.HasOne("charityPulse.core.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("charityPulse.core.Models.Advertisment", b =>
                {
                    b.HasOne("charityPulse.core.Models.Charity", "Charity")
                        .WithMany("Advertisments")
                        .HasForeignKey("CharityId");

                    b.HasOne("charityPulse.core.Models.Corporate", "Corporate")
                        .WithMany("Advertisments")
                        .HasForeignKey("CorporateId");

                    b.Navigation("Charity");

                    b.Navigation("Corporate");
                });

            modelBuilder.Entity("charityPulse.core.Models.ApplicationUser", b =>
                {
                    b.HasOne("charityPulse.core.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.HasOne("charityPulse.core.Models.Charity", "Charity")
                        .WithMany()
                        .HasForeignKey("CharityId");

                    b.HasOne("charityPulse.core.Models.Corporate", "Corporate")
                        .WithMany()
                        .HasForeignKey("CorporateId");

                    b.HasOne("charityPulse.core.Models.Donor", "Donor")
                        .WithMany()
                        .HasForeignKey("DonorId");

                    b.Navigation("Admin");

                    b.Navigation("Charity");

                    b.Navigation("Corporate");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("charityPulse.core.Models.Badge", b =>
                {
                    b.HasOne("charityPulse.core.Models.Charity", "Charity")
                        .WithMany("Badges")
                        .HasForeignKey("CharityId");

                    b.HasOne("charityPulse.core.Models.Corporate", "Corporate")
                        .WithMany("Badges")
                        .HasForeignKey("CorporateId");

                    b.HasOne("charityPulse.core.Models.Donor", "Donor")
                        .WithMany("Badges")
                        .HasForeignKey("DonorId");

                    b.Navigation("Charity");

                    b.Navigation("Corporate");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("charityPulse.core.Models.Charity", b =>
                {
                    b.HasOne("charityPulse.core.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("charityPulse.core.Models.Corporate", b =>
                {
                    b.HasOne("charityPulse.core.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("charityPulse.core.Models.Donation", b =>
                {
                    b.HasOne("charityPulse.core.Models.Charity", "Charity")
                        .WithMany("Donations")
                        .HasForeignKey("CharityId");

                    b.HasOne("charityPulse.core.Models.Corporate", "Corporate")
                        .WithMany("Donations")
                        .HasForeignKey("CorporateId");

                    b.HasOne("charityPulse.core.Models.Donor", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("charityPulse.core.Models.Project", "Project")
                        .WithMany("Donations")
                        .HasForeignKey("projectId");

                    b.Navigation("Charity");

                    b.Navigation("Corporate");

                    b.Navigation("Donor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("charityPulse.core.Models.DonationReport", b =>
                {
                    b.HasOne("charityPulse.core.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("charityPulse.core.Models.Donor", b =>
                {
                    b.HasOne("charityPulse.core.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("charityPulse.core.Models.Project", b =>
                {
                    b.HasOne("charityPulse.core.Models.Charity", "Charity")
                        .WithMany("Projects")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("charityPulse.core.Models.Donor", null)
                        .WithMany("Projects")
                        .HasForeignKey("DonorId");

                    b.HasOne("charityPulse.core.Models.DonationReport", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId");

                    b.Navigation("Charity");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("charityPulse.core.Models.Review", b =>
                {
                    b.HasOne("charityPulse.core.Models.Charity", "Charity")
                        .WithMany("Reviews")
                        .HasForeignKey("CharityId");

                    b.HasOne("charityPulse.core.Models.Donor", "Donor")
                        .WithMany("Reviews")
                        .HasForeignKey("DonorID");

                    b.Navigation("Charity");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("charityPulse.core.Models.Charity", b =>
                {
                    b.Navigation("Advertisments");

                    b.Navigation("Badges");

                    b.Navigation("Donations");

                    b.Navigation("Projects");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("charityPulse.core.Models.Corporate", b =>
                {
                    b.Navigation("Advertisments");

                    b.Navigation("Badges");

                    b.Navigation("Donations");
                });

            modelBuilder.Entity("charityPulse.core.Models.Donor", b =>
                {
                    b.Navigation("Badges");

                    b.Navigation("Donations");

                    b.Navigation("Projects");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("charityPulse.core.Models.Project", b =>
                {
                    b.Navigation("Donations");
                });
#pragma warning restore 612, 618
        }
    }
}
