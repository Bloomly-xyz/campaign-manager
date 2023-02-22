namespace CampaignManager.Infrastructure.Models.ConfigModels
{
    public class SendGridConfig
    {
        public string SendGridUser { get; set; }
        public string SendGridFrom { get; set; }
        public string IMSADevsMailingAddress { get; set; }
        public string SendGridKey { get; set; }
    }
}
