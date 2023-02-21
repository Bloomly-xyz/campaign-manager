using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.DBModels
{
    public class ClaimUtility :BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? Uuid { get; set; }
        [ForeignKey("Utilities")]
        public int? CampaignId { get; set; }
        public virtual Utilities Utilities { get; set; }
        [ForeignKey("Users")]
        public int? UserId { get; set; }
        public virtual Users Users { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string BlockChainTransactionId { get; set; }
        [Required]
        public string ClaimJson { get; set; }
    }
}
