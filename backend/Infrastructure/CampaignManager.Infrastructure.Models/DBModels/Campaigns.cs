using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.DBModels
{
    public class Campaigns : BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string CampaignUuid { get; set; }
        [ForeignKey("Users")]
        public int? UserId { get; set; }
        public virtual Users Users { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? CampaignName { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string? CampaignDescription { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CampaignStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CampaignEndDate { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? ContractAddress { get; set; }
        [Column(TypeName = "VARCHAR(500)")]
        public string? ContractName { get; set; }
        [Column(TypeName = "VARCHAR(300)")]
        public string? ContractStoragePath { get; set; }
        [Column(TypeName = "VARCHAR(300)")]
        public string? CollectionPublicPath { get; set; }
        [Column(TypeName = "nVARCHAR(4000)")]
        public string? CampaignJson { get; set; }
        [Column(TypeName = "VARCHAR(300)")]
        public string? CampaignPublicUrl { get; set; }
    }
}
