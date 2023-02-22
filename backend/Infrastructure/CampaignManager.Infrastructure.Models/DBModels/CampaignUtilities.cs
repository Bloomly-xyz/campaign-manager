using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.DBModels
{
    public class CampaignUtilities
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey("Campaigns")]
        public int? CampaignId { get; set; }
        public virtual Campaigns Campaigns { get; set; }
        [ForeignKey("Utilities")]
        public int? UtilityId { get; set; }
        public virtual Utilities Utilities { get; set; }
        public string? CampaignUtilityJson { get; set; }
    }
}
