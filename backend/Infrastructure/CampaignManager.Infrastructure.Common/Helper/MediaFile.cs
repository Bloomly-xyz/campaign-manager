using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Common.Helper
{
    public class MediaFile : IDisposable
    {
        private string _contentBase64;

        public string ContentBase64
        {
            get => _contentBase64;
            set
            {
                _contentBase64 = value;
                _stream = value != null ? StreamExtensions.FromBase64(value) : null;
            }
        }

        private Stream _stream;

        [JsonIgnore]
        public Stream Stream
        {
            get => _stream;
            set
            {
                _contentBase64 = value != null ? value.ToBase64() : null;
                _stream = value;
            }
        }

        public string ContentType { get; set; }
        public string FileName { get; set; }

        public string Extension { get; set; }
        public string Name { get; set; }
        public long Length { get; set; }

        public void Dispose()
        {
            Stream?.Dispose();
        }
    }
}
