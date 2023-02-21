using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Common.Helper
{
    public static class StreamExtensions
    {
        public static string ToBase64(this Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static Stream FromBase64(string base64String)
        {
            var bytes = Convert.FromBase64String(base64String);
            return new MemoryStream(bytes);
        }

        public static Stream SeekToBegin(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}
