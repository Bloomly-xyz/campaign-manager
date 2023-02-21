using CampaignManager.Infrastructure.Common.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Common.Extensions
{
    public static class MediaFileExtensions
    {
        public static MediaFile ToMediaFile(this IFormFile file)
        {
            if (file != null)
            {
                var mediaFile = new MediaFile();
                mediaFile.Stream = file.OpenReadStream();
                mediaFile.ContentType = file.ContentType;
                mediaFile.FileName = file.FileName;
                mediaFile.Extension = Path.GetExtension(file.FileName);
                mediaFile.Length = file.Length;
                mediaFile.Name = file.Name;

                return mediaFile;
            }
            return null;
        }
    }
}
