using CampaignManager.Infrastructure.Models.CampaignModel.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.CampaignModel.Dtos
{
    public class CampaignUtilityData
    {
        public List<CampaignData> campaignData { get; set; }
        public List<CampainUtilitiesRequest> campainUtilitiesData { get; set; }
    }
    public class CampaignData
    {
        public int Id { get; set; }
        public string CampaignUuid { get; set; }
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public DateTime? CampaignStartDate { get; set; }
        public DateTime? CampaignEndDate { get; set; }
        public string ContractAddress { get; set; }
        public string ContractName { get; set; }
        public string ContractStoragePath { get; set; }
        public string CollectionPublicPath { get; set; }
        public string CampaignJson { get; set; }
        public bool? Digital { get; set; }
        public bool? Experencial { get; set; }
        public bool? Physical { get; set; }
        public int NoOfClaims { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int UserId { get; set; }
        public string CampaignPublicUrl { get; set; }
    }
}
