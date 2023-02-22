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

       
        //[HttpPost("calling")]
        //public async Task<IActionResult> Calling()
        //{
        //    return GenericApiResponse(default(IActionResult), "Calling", HttpStatusCode.OK, null, true);
        //}


        //[AllowAnonymous]
        //[HttpGet("SendTestEmail")]
        //public async Task<IActionResult> SendTestEmail(string template)
        //{
        //    List<string> recipients = new List<string>();
        //    recipients.Add("noumankhan@troontechnologies.com");
        //    SqsMessageModel sqsMessageModel = new SqsMessageModel
        //    {
        //        Subject = "Sucessfull Blocto Payment!",
        //        Recipients = recipients,
        //        TemplateType = template,
        //    };
        //    await _SQSEmailService.SendEmailViaSQS(sqsMessageModel);
        //    return Ok();
        //}

    }
}
