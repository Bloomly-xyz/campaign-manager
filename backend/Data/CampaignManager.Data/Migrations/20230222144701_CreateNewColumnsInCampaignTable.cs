using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignManager.Data.Migrations
{
    public partial class CreateNewColumnsInCampaignTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlockChainJson",
                table: "Campaigns",
                type: "nVARCHAR(4000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlockChainTransactionId",
                table: "Campaigns",
                type: "VARCHAR(300)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockChainJson",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "BlockChainTransactionId",
                table: "Campaigns");
        }
    }
}
