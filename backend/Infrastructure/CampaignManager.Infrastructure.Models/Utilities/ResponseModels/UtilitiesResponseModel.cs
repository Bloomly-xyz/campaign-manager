using CampaignManager.Infrastructure.Models.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.Utilities.ResponseModels
{
    public class UtilitiesResponseModel
    {
        public int Id { get; set; }
        public string UtitilityName { get; set; }
        public string UtilityDescription { get; set; }
        public string UtilityIconUrl { get; set; }
        public bool? Digital { get; set; }
        public bool? Experiential { get; set; }
        public bool? Physical { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
