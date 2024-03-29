﻿// <auto-generated />
using System;
using CampaignManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230223114329_UpdateCampaignForignKey")]
    partial class UpdateCampaignForignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.Campaigns", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlockChainJson")
                        .HasColumnType("nVARCHAR(4000)");

                    b.Property<string>("BlockChainTransactionId")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("CampaignDescription")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<DateTime?>("CampaignEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CampaignJson")
                        .HasColumnType("nVARCHAR(4000)");

                    b.Property<string>("CampaignName")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("CampaignPublicUrl")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<DateTime?>("CampaignStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CampaignUuid")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("CollectionPublicPath")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("ContractAddress")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("ContractName")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("ContractStoragePath")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.CampaignUtilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("CampaignUtilityJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UtilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("UtilityId");

                    b.ToTable("CampaignUtilities");
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.ClaimUtility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlockChainTransactionId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("ClaimJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Uuid")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("UserId");

                    b.ToTable("ClaimUtilities");
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("TemplateValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailTemplates");
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.ShippingLocations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LocationName")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ShippingLocations");
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.ShippingPartner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShippingPartnerName")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("ShippingPartners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            ShippingPartnerName = "DHL"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            ShippingPartnerName = "FedEx"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            ShippingPartnerName = "UPS"
                        });
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("FirstName")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WalletAddress")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.Utilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("DigitalUtility")
                        .HasColumnType("bit");

                    b.Property<bool?>("ExperientialUtility")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("PhysicalUtility")
                        .HasColumnType("bit");

                    b.Property<string>("UtilityDescription")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("UtilityIconUrl")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("UtitilityName")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Utilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = false,
                            ExperientialUtility = false,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Custom Utility"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = false,
                            ExperientialUtility = false,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = true,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Merch"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = true,
                            ExperientialUtility = false,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Audio"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = false,
                            ExperientialUtility = true,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Event"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = true,
                            ExperientialUtility = false,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "AMA"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = true,
                            ExperientialUtility = true,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Martaverse Event"
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = true,
                            ExperientialUtility = false,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Promocode"
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = false,
                            ExperientialUtility = true,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Physical Tickets"
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = true,
                            ExperientialUtility = false,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Newsletter"
                        },
                        new
                        {
                            Id = 10,
                            CreatedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            DigitalUtility = true,
                            ExperientialUtility = false,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedDate = new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            PhysicalUtility = false,
                            UtilityDescription = "",
                            UtilityIconUrl = "",
                            UtitilityName = "Exclusive Audio"
                        });
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.Campaigns", b =>
                {
                    b.HasOne("CampaignManager.Infrastructure.Models.DBModels.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.CampaignUtilities", b =>
                {
                    b.HasOne("CampaignManager.Infrastructure.Models.DBModels.Campaigns", "Campaigns")
                        .WithMany()
                        .HasForeignKey("CampaignId");

                    b.HasOne("CampaignManager.Infrastructure.Models.DBModels.Utilities", "Utilities")
                        .WithMany()
                        .HasForeignKey("UtilityId");

                    b.Navigation("Campaigns");

                    b.Navigation("Utilities");
                });

            modelBuilder.Entity("CampaignManager.Infrastructure.Models.DBModels.ClaimUtility", b =>
                {
                    b.HasOne("CampaignManager.Infrastructure.Models.DBModels.Campaigns", "Campaigns")
                        .WithMany()
                        .HasForeignKey("CampaignId");

                    b.HasOne("CampaignManager.Infrastructure.Models.DBModels.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Campaigns");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
