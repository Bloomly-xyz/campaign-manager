using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Infrastructure.Models.CampaignModel.RequestModel;
using CampaignManager.Infrastructure.Models.CampaignModel.ResponseModel;
using CampaignManager.Infrastructure.Models.User.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CampaignManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : SecureController
    {
        private readonly ICampaignService _campaignService;
        public CampaignController(ICampaignService campaignService)
        {
            _campaignService= campaignService;
        }
        /// <summary>
        /// Create Campaign.
        /// </summary>
        /// <param name="CampaignRequest"></param> 
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Campaign/create_campaign
        ///             {
        ///               "stepsEnum": 3,
        ///               "id": 0,
        ///               "campaignUuid": "126052d4-4919-4a13-bc72-22c1ccf7ae76",
        ///               "campaignName": "Bloomly NFT Campaign",
        ///               "campaignDescription": "Test Campaign",
        ///               "campaignStartDate": "2023-02-16T13:25:51.409Z",
        ///               "campaignEndDate": "2023-02-16T13:25:51.409Z",
        ///               "contractAddress": "0x737fc5ff6c669b8f",
        ///               "contractName": "CampaignManagerNFT",
        ///               "contractStoragePath": "CampaignManagerNFTCollection",
        ///               "collectionPublicPath": "CampaignManagerNFTCollection",
        ///               "campaignJson": "string",
        ///               "userId": 1,
        ///               "campaignUtilities": [
        ///                 {
        ///                   "utilityId": 2,
        ///                   "campaignUtilityJson": "JSON Value Physical"
        ///                 },
        ///             {
        ///                   "utilityId": 3,
        ///                   "campaignUtilityJson": "JSON Value Pgysical & Digital"
        ///                 },
        ///             {
        ///                 "utilityId": 5,
        ///                   "campaignUtilityJson": "JSON Value Pgysical & Digital & Experiential"
        ///                 }
        ///               ],
        ///               "campaignPublicUrl": "http://localhost:5001/swagger/index.html"
        ///             }
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(CampaignResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpPost("create_campaign")]
        public async Task<IActionResult> CreateCampaign([FromBody] CampaignRequestModel campaignRequestModel)
        {
            var result = await _campaignService.CreateCampaignAsync(campaignRequestModel);
            if (result.errorCode > 0)
                return GenericApiResponse(default(IActionResult), result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, "Campaign Created/Updated Successfully", HttpStatusCode.OK);
        }

        /// <summary>
        /// Get All Campaigns
        /// </summary>
        /// <param name="UserId"></param> 
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Campaign/get_campaign
        ///     {
        ///        "UserId": 1
        ///     }
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(List<CampaignResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpPost("get_campaigns")]
        public async Task<IActionResult> GetAllCampaign([FromBody] UserRequestModel userRequest)
        {
            var result = await _campaignService.GetCampaignsListAsync(userRequest.Id);
            if (result.errorCode > 0)
                return GenericApiResponse(default(IActionResult), result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, "Success", HttpStatusCode.OK);
        }

        /// <summary>
        /// Get Campaign by Id
        /// </summary>
        /// <param name="CampaignUuid"></param> 
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Campaign/get_campaign_by_id
        ///     {
        ///        "CampaignUuid": "safsnxzhc8y8dysajnckmsancdlksahf"
        ///     }
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(List<CampaignResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet("get_campaign_by_id")]
        public async Task<IActionResult> GetCampaignById([FromQuery] string CampaignUuid)
        {
            var result = await _campaignService.GetCampaignByIdAsync(CampaignUuid);
            if (result.errorCode > 0)
                return GenericApiResponse(default(IActionResult), result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, "Success", HttpStatusCode.OK);
        }
        /// <summary>
        /// Get Campaign Claim Details
        /// </summary>
        /// <param name="UserId"></param> 
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Campaign/get_campaign_details
        ///     {
        ///        "CampaignUuid": "safsnxzhc8y8dysajnckmsancdlksahf"
        ///     }
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(List<CampaignResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet("get_campaign_claim_details")]
        public async Task<IActionResult> GetCampaignClaimDetails([FromQuery]string CampaignUuid)
        {
            var result = await _campaignService.GetCampaignClaimDetailsAsync(CampaignUuid);
            if (result.errorCode > 0)
                return GenericApiResponse(default(IActionResult), result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, "Success", HttpStatusCode.OK);
        }
    }
}
