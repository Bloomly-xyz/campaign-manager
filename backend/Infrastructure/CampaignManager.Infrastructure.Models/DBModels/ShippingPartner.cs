using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.DBModels
{
    public class ShippingPartner : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string? ShippingPartnerName { get; set; }
    }
}
