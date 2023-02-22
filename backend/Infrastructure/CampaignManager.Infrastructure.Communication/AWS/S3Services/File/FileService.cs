using Amazon.S3;
using Amazon.S3.Model;
using CampaignManager.Infrastructure.Common.Extensions;
using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Common.Helper;
using CampaignManager.Infrastructure.Models.AWS.DTOs;
using CampaignManager.Infrastructure.Models.AWS.RequestModels;
using CampaignManager.Infrastructure.Models.ConfigModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Infrastructure.Communication.AWS.S3Services.File
{
    public class FileService : IFileService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly AWSS3Config _aWS3Config;
        public FileService(IAmazonS3 s3Client, IOptions<AWSS3Config> aWS3Config)
        {
            _s3Client = s3Client;
            _aWS3Config = aWS3Config.Value;
        }
        /// <summary>
        /// Delete a file from spcific bucket of S3
        /// </summary>
        /// <param name="aWSS3RequestModel"></param>
        /// <returns></returns>
        public async Task<GenericApiResponse<DeleteObjectResponse>> DeleteFileAsync(AWSS3RequestModel aWSS3RequestModel)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(aWSS3RequestModel.BucketName);
            if (!bucketExists)
                return GenericApiResponse<DeleteObjectResponse>.Failure(MessageResource.GetMessage(APIStatusCodes.S3BucketNotExist), APIStatusCodes.S3BucketNotExist);
            var result = await _s3Client.DeleteObjectAsync(aWSS3RequestModel.BucketName, aWSS3RequestModel.Key);
            return GenericApiResponse<DeleteObjectResponse>.Success(result, "");
        }
        /// <summary>
        /// Get all files from a spcific bucket
        /// </summary>
        /// <param name="aWSS3RequestModel"></param>
        /// <returns></returns>
        public async Task<GenericApiResponse<IEnumerable<S3ObjectDto>>> GetAllFilesAsync(AWSS3RequestModel aWSS3RequestModel)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(aWSS3RequestModel.BucketName);
            if (!bucketExists)
                return GenericApiResponse<IEnumerable<S3ObjectDto>>.Failure(MessageResource.GetMessage(APIStatusCodes.S3BucketNotExist), APIStatusCodes.S3BucketNotExist);
            var request = new ListObjectsV2Request()
            {
                BucketName = aWSS3RequestModel.BucketName,
                Prefix = aWSS3RequestModel.Prefix
            };
            var result = await _s3Client.ListObjectsV2Async(request);
            var s3Objects = result.S3Objects.Select(s =>
            {
                var urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = aWSS3RequestModel.BucketName,
                    Key = s.Key,
                    Expires = DateTime.UtcNow.AddMinutes(1)
                };
                return new S3ObjectDto()
                {
                    Name = s.Key.ToString(),
                    PresignedUrl = _s3Client.GetPreSignedURL(urlRequest),
                };
            });
            return GenericApiResponse<IEnumerable<S3ObjectDto>>.Success(s3Objects, "");
        }
        /// <summary>
        /// Get file by key from S3 Bucket
        /// </summary>
        /// <param name="aWSS3RequestModel"></param>
        /// <returns></returns>
        public async Task<GenericApiResponse<GetObjectResponse>> GetFileByKeyAsync(AWSS3RequestModel aWSS3RequestModel)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(aWSS3RequestModel.BucketName);
            if (!bucketExists)
                return GenericApiResponse<GetObjectResponse>.Failure(MessageResource.GetMessage(APIStatusCodes.S3BucketNotExist), APIStatusCodes.S3BucketNotExist);
            var result = await _s3Client.GetObjectAsync(aWSS3RequestModel.BucketName, aWSS3RequestModel.Key);
            return GenericApiResponse<GetObjectResponse>.Success(result, "");
        }
        /// <summary>
        /// Upload file to a specific bucket of S3
        /// </summary>
        /// <param name="aWSS3RequestModel"></param>
        /// <returns></returns>
        public async Task<GenericApiResponse<PutObjectResponse>> UploadFileAsync(AWSS3RequestModel aWSS3RequestModel, bool reduceQuality = false)
        {
            string FileName = Guid.NewGuid().ToString() + Path.GetExtension(aWSS3RequestModel.File.FileName);
            var mediaFile = aWSS3RequestModel.File.ToMediaFile();
            var request = new PutObjectRequest()
            {
                BucketName = _aWS3Config.BucketName,
                Key = string.IsNullOrEmpty(aWSS3RequestModel.Prefix) ? FileName : $"{aWSS3RequestModel.Prefix?.TrimEnd('/')}/{FileName}",
                InputStream = reduceQuality ? ResizeImage(mediaFile.Stream.SeekToBegin()) : mediaFile.Stream.SeekToBegin()
            };
            request.Metadata.Add("Content-Type", aWSS3RequestModel.File.ContentType);
            var result = await _s3Client.PutObjectAsync(request);
            if (result.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                string FileUrl = _aWS3Config.BaseUrl + "/" + request.Key;
                return GenericApiResponse<PutObjectResponse>.Success(result, FileUrl);
            }
            else
                return GenericApiResponse<PutObjectResponse>.Failure("Asset Upload Failed", APIStatusCodes.ImageUploadFailed);
        }
private Stream ResizeImage(Stream stream)
{
    using (var image = Image.Load(stream, out var format))
    {
        var outStream = new MemoryStream();
        var encoder = new JpegEncoder()
        {
            Quality = 90
        };
        image.Save(outStream, encoder);
        return outStream;
    }
}
    }
}
