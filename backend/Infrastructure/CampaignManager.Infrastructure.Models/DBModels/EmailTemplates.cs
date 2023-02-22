using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManager.Infrastructure.Models.DBModels
{
    public class EmailTemplate : BaseEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(200)")]
        public string TemplateName { get; set; }
        public string TemplateValue { get; set; }
    }
}
