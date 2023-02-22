using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Infrastructure.Models.AWS.DTOs;
using CampaignManager.Infrastructure.Models.AWS.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CampaignManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3BucketController : SecureController
    {
        private readonly IS3bucketService _S3Bucketservice;
        public S3BucketController(IS3bucketService s3BucketService)
        {
            _S3Bucketservice = s3BucketService;
        }

        /// <summary>
        /// Upload File, An API end point that can upload file(image,Video) on Cloud S3 bucket, based on the user selection file. 
        /// </summary>
        /// <param name="uploadFileRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/S3Bucket/upload_image
        ///             {
        ///               AvatarFile: File,
        ///               BannerFile: File
        ///             }
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [RequestSizeLimit(10000000)]
        [Produces("application/json")]
        [HttpPost("upload_image")]
        public async Task<IActionResult> UploadImage([FromForm] UploadFileRequest uploadFileRequest)
        {
            var result = await _S3Bucketservice.UploadImage(uploadFileRequest);
            if (result.Succeeded)
                return GenericApiResponse(result.Result, "Image Upload Successfully", HttpStatusCode.OK, null, true);
            else
                return GenericApiResponse(default(IActionResult), result.message, result.status, result.Exception, result.Succeeded);
        }
    }
}
