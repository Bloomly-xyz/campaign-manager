using Amazon.S3.Model;
using CampaignManager.Infrastructure.Common.GenericResponses;
using Microsoft.AspNetCore.Http;

namespace CampaignManager.Infrastructure.Communication.AWS.S3Services.Bucket
{
    public interface IBucketService
    {
        Task<GenericApiResponse<PutBucketResponse>> CreateBucketAsync(string bucketName);
        Task<GenericApiResponse<ListBucketsResponse>> GetAllBucketAsync();
        Task<GenericApiResponse<DeleteBucketResponse>> DeleteBucketAsync(string bucketName);
        Task<GenericApiResponse<S3Bucket>> GetBucketByNameAsync(string bucketName);
        Task<GenericApiResponse<PutObjectResponse>> CreateFolerInBucketAsync(string bucketName, string FolerName,IFormFile file);
    }
}
