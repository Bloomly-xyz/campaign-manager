using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.CampaignModel.RequestModel
{
    public class CampainUtilitiesRequest
    {
        public int utilityId { get; set; }
        public string CampaignUtilityJson { get; set; }
    }
}
