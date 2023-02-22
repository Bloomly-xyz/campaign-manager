using Amazon.S3.Model;
using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Models.AWS.DTOs;
using CampaignManager.Infrastructure.Models.AWS.RequestModels;

namespace CampaignManager.Infrastructure.Communication.AWS.S3Services.File
{
    public interface IFileService
    {
        Task<GenericApiResponse<PutObjectResponse>> UploadFileAsync(AWSS3RequestModel aWSS3RequestModel, bool reduceQuality=false);
        Task<GenericApiResponse<IEnumerable<S3ObjectDto>>> GetAllFilesAsync(AWSS3RequestModel aWSS3RequestModel);
        Task<GenericApiResponse<GetObjectResponse>> GetFileByKeyAsync(AWSS3RequestModel aWSS3RequestModel);
        Task<GenericApiResponse<DeleteObjectResponse>> DeleteFileAsync(AWSS3RequestModel aWSS3RequestModel);
    }
}
