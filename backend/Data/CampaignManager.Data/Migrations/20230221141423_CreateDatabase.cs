using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    TemplateValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingPartnerName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingPartners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    EmailAddress = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    WalletAddress = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtitilityName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    UtilityDescription = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    UtilityIconUrl = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    PhysicalUtility = table.Column<bool>(type: "bit", nullable: true),
                    DigitalUtility = table.Column<bool>(type: "bit", nullable: true),
                    ExperientialUtility = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignUuid = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CampaignName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CampaignDescription = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    CampaignStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CampaignEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractAddress = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ContractName = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    ContractStoragePath = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    CollectionPublicPath = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    CampaignJson = table.Column<string>(type: "nVARCHAR(4000)", nullable: true),
                    CampaignPublicUrl = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClaimUtilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    BlockChainTransactionId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ClaimJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimUtilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimUtilities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClaimUtilities_Utilities_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Utilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CampaignUtilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    UtilityId = table.Column<int>(type: "int", nullable: true),
                    CampaignUtilityJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignUtilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignUtilities_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignUtilities_Utilities_UtilityId",
                        column: x => x.UtilityId,
                        principalTable: "Utilities",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ShippingPartners",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "ShippingPartnerName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), "DHL" },
                    { 2, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), "FedEx" },
                    { 3, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), "UPS" }
                });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DigitalUtility", "ExperientialUtility", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "PhysicalUtility", "UtilityDescription", "UtilityIconUrl", "UtitilityName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, false, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "Custom Utility" },
                    { 2, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, false, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, "", "", "Merch" },
                    { 3, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, false, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "Audio" },
                    { 4, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, true, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "Event" },
                    { 5, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, false, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "AMA" },
                    { 6, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, true, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "Martaverse Event" },
                    { 7, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, false, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "Promocode" },
                    { 8, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, true, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "Physical Tickets" },
                    { 9, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, false, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "Newsletter" },
                    { 10, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), true, false, true, false, null, new DateTime(2023, 2, 24, 13, 45, 0, 0, DateTimeKind.Unspecified), false, "", "", "Exclusive Audio" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_UserId",
                table: "Campaigns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUtilities_CampaignId",
                table: "CampaignUtilities",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignUtilities_UtilityId",
                table: "CampaignUtilities",
                column: "UtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimUtilities_CampaignId",
                table: "ClaimUtilities",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimUtilities_UserId",
                table: "ClaimUtilities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignUtilities");

            migrationBuilder.DropTable(
                name: "ClaimUtilities");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "ShippingLocations");

            migrationBuilder.DropTable(
                name: "ShippingPartners");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Utilities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
