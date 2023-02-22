using CampaignManager.Infrastructure.Models.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Infrastructure.Models.CampaignModel.RequestModel
{
    public class CampaignRequestModel
    {
        [Required]
        public CampaignStepsEnum stepsEnum { get; set; }
        public string? CampaignUuid { get; set; }
        public string? CampaignName { get; set; }
        public string? CampaignDescription { get; set; }
        public DateTime? CampaignStartDate { get; set; }
        public DateTime? CampaignEndDate { get; set; }
        public string? ContractAddress { get; set; }
        public string? ContractName { get; set; }
        public string? ContractStoragePath { get; set; }
        public string? CollectionPublicPath { get; set; }
        public string? CampaignJson { get; set; }
        public  int UserId { get; set; }
        public List<CampainUtilitiesRequest>? CampaignUtilities { get; set; }
        public string? CampaignPublicUrl { get; set; }
    }
}
