using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    public partial class UpdateCampaignForignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimUtilities_Utilities_CampaignId",
                table: "ClaimUtilities");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimUtilities_Campaigns_CampaignId",
                table: "ClaimUtilities",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimUtilities_Campaigns_CampaignId",
                table: "ClaimUtilities");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimUtilities_Utilities_CampaignId",
                table: "ClaimUtilities",
                column: "CampaignId",
                principalTable: "Utilities",
                principalColumn: "Id");
        }
    }
}
