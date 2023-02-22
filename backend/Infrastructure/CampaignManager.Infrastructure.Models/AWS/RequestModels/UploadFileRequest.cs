using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.AWS.RequestModels
{
    public class UploadFileRequest
    {
        [Required]
        public IFormFile File { get; set; }
    }

    public class UserProfileMediaFileRequest
    {
        public IFormFile? AvatarFile { get; set; }
        public IFormFile? BannerFile { get; set; }
    }
     

}
