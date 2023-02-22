using Amazon.S3.Model;
using CampaignManager.Business.Services.Services;
using CampaignManager.Business.ServicesTests.DependencyResolver;
using CampaignManager.Infrastructure.Common.Cache;
using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Common.Operation;
using CampaignManager.Infrastructure.Communication.AWS.S3Services.Bucket;
using CampaignManager.Infrastructure.Communication.AWS.S3Services.File;
using CampaignManager.Infrastructure.Models.AWS.RequestModels;
using CampaignManager.Infrastructure.Models.ConfigModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CampaignManager.Business.ServicesTests.Services
{
    public class S3bucketServiceTests
    {
        private readonly DBOperationExecutor _dbOperationExecutor;
        private readonly SafeOperationExecutor _safeOperationExecutor;
        private readonly Mock<IBucketService> _bucketService;
        private readonly Mock<IFileService> _fileService;
        private Mock<ICache> _cache;
        private readonly Mock<ILogger<DBOperationExecutor>> _dblogger;
        private readonly Mock<ILogger<SafeOperationExecutor>> _logger;
        private readonly S3bucketService _s3BucketService;
        private readonly Mock<IFormFile> _file;
       
        public S3bucketServiceTests()
        {
            UnitTestDependencyResolver dependencyResolver = new UnitTestDependencyResolver();
            var _options = dependencyResolver.InitiateAppSetting();
            _cache = new Mock<ICache>();
            _dblogger = new Mock<ILogger<DBOperationExecutor>>();
            _logger = new Mock<ILogger<SafeOperationExecutor>>();
            _fileService = new Mock<IFileService>(); 
            _dbOperationExecutor = new DBOperationExecutor(_cache.Object,_dblogger.Object);
            _safeOperationExecutor = new SafeOperationExecutor(_cache.Object, _logger.Object);
            _bucketService = new Mock<IBucketService>();
            _file = new Mock<IFormFile>();
            _s3BucketService = new S3bucketService(_dbOperationExecutor, _safeOperationExecutor, _bucketService.Object, _fileService.Object, _options);
        }

        [Fact]
        public async Task UploadImage_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _fileService.Setup(x => x.UploadFileAsync(It.IsAny<AWSS3RequestModel>(), It.IsAny<bool>())).ReturnsAsync(new GenericApiResponse<PutObjectResponse>());
            
            //ACT
            var mockResponse = await _s3BucketService.UploadImage(new UploadFileRequest() { File = _file.Object});
            
            //ASSERT
            Assert.NotNull(mockResponse);
        }
    }
}
