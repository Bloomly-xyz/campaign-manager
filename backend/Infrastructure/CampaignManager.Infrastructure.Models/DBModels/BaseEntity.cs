using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Infrastructure.Models.DBModels
{
    public class BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(100)")]
        public string? CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(100)")]
        public string? ModifiedBy { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }

    }
}
