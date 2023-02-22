using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Infrastructure.Common.Operation;
using CampaignManager.Infrastructure.Communication.AWS.S3Services.Bucket;
using CampaignManager.Infrastructure.Communication.AWS.S3Services.File;
using CampaignManager.Infrastructure.Models.AWS.RequestModels;
using CampaignManager.Infrastructure.Models.ConfigModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Business.Services.Services
{
    public class S3bucketService : IS3bucketService
    {
        private readonly IDBOperationExecutor _dbOperationExecutor;
        private readonly ISafeOperationExecutor _safeOperationExecutor;
        private readonly IBucketService _bucketService;
        private readonly IFileService _fileService;
        private readonly AWSS3Config _aWS3Config;
        public S3bucketService(
            IDBOperationExecutor dBOperationExecutor,
            ISafeOperationExecutor safeOperationExecutor,
            IBucketService bucketService,
            IFileService fileService,
            IOptions<AWSS3Config> aWS3Config)
        {
            _dbOperationExecutor = dBOperationExecutor;
            _safeOperationExecutor = safeOperationExecutor;
            _bucketService = bucketService;
            _fileService = fileService;
            _aWS3Config = aWS3Config.Value;
        }

        public async Task<OpResult<string>> UploadImage(UploadFileRequest uploadFileRequest)
        {
            return await _safeOperationExecutor.ExecuteSafeOperationAsync<string>(async () =>
            {
                if (uploadFileRequest.File != null)
                {
                      AWSS3RequestModel aWSS3RequestModel = new AWSS3RequestModel
                      {
                          //BucketName = bucket.payload.BucketName,
                          Key = _aWS3Config.OriginalFolder + "/" + uploadFileRequest.File.FileName,
                          Prefix = _aWS3Config.OriginalFolder + "/",
                          File = uploadFileRequest.File
                      };
                      var result = await _fileService.UploadFileAsync(aWSS3RequestModel);
                      return result.message;
                }
                return "";
            });
        }
    }
}
