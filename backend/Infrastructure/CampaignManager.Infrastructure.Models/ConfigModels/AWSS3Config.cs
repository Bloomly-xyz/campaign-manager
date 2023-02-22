using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.ConfigModels
{
    public class AWSS3Config
    {
        public string BucketName { get; set; }
        public string ClientLogoFolder { get; set; }
        public string ClientAssetFolder { get; set; }
        public string ClientProfileImages { get; set; }
        public string BaseUrl { get; set; }
        public string CroppedAssetFolder { get; set; }
        public string ReduceQualityFolder { get; set; }
        public string OriginalFolder { get; set; }
        public string AudioFolder { get; set; }
        public string VideoFolder { get; set; }
        public string ThumbnailFolder { get; set; }
    }
}
