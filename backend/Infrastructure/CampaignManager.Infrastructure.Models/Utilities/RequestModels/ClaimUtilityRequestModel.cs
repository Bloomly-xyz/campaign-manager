using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.Utilities.RequestModels
{
    public class ClaimUtilityRequestModel
    {
        [Required]
        public string ClaimJson { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CampaignId { get; set; }
        [Required]
        public string BlockChainTransactionId { get; set; }

    }
    public class CheckClaimedUtilityRequestModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CampaignId { get; set; }

    }
}
