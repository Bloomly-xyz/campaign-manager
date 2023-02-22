using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Business.ServicesTests.Common
{
    public static class CommonModel
    {
        public static string WalletAddress { get; set; } = "0x6e702bfe963ca381";
        public static int ClientId { get; set; } = 1;
        public static int CampaignId { get; set; } = 1;
        public static int Id { get; set; } = 1;
        public static string CampaignUuid { get; set; } = Guid.NewGuid().ToString();
        public static int? UserId { get; set; } = 1;
        public static string? CampaignName { get; set; } = "test campaign";
        public static string? CampaignDescription { get; set; } = "Campaign Description";
        public static DateTime? CampaignStartDate { get; set; } = DateTime.UtcNow;
        public static DateTime? CampaignEndDate { get; set; } = DateTime.UtcNow.AddDays(1);
        public static string? ContractAddress { get; set; } = "0xAs123sda123";
        public static string? ContractName { get; set; } = "NBA top shot";
        public static string? ContractStoragePath { get; set; } = "dummy storage path";
        public static string? CollectionPublicPath { get; set; } = "dummy public path";
        public static string? CampaignJson { get; set; } = "Json";
        public static string? CampaignPublicUrl { get; set; } = "https://www.campaign.url";

    }
}
