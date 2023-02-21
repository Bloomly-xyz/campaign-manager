using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CampaignManager.Infrastructure.Models.DBModels
{
    public class Utilities : BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? UtitilityName { get; set; }
        [Column(TypeName = "VARCHAR(500)")]
        public string? UtilityDescription { get; set; }
        [Column(TypeName = "VARCHAR(300)")]
        public string? UtilityIconUrl { get; set; }
        [DefaultValue(false)]
        public bool? PhysicalUtility { get; set; }
        [DefaultValue(false)]
        public bool? DigitalUtility { get; set; }
        [DefaultValue(false)]
        public bool? ExperientialUtility { get; set; }
    }
}
