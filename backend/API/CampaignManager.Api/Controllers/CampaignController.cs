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
        /// Create Campaign request, If user is a creator and want to create Utilities against his public collection, can provide his/her contract address along with other required information, our system will crate a utility based on the given creator data.
        /// </summary>
        /// <param name="campaignRequestModel"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Campaign/create_campaign
        ///     {
        ///       "stepsEnum":3,
        ///       "id":0,
        ///       "campaignUuid":"126052d4-4919-4a13-bc72-22c1ccf7ae76",
        ///       "campaignName":"NFT Campaign",
        ///       "campaignDescription":"Test Campaign",
        ///       "campaignStartDate":"2023-02-16T13:25:51.409Z",
        ///       "campaignEndDate":"2023-02-16T13:25:51.409Z",
        ///       "contractAddress":"0x737fc5ff6c669b8f",
        ///       "contractName":"CampaignManagerNFT",
        ///       "contractStoragePath":"CampaignManagerNFTCollection",
        ///       "collectionPublicPath":"CampaignManagerNFTCollection",
        ///       "campaignJson":"string",
        ///       "userId":1,
        ///       campaignUtilities: "json",
        ///       "campaignPublicUrl":"https://Campaignmanager.bloomly.xyz"
        ///     }
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
        /// Get All Campaigns, An API end point, which can fetch creator campaigns best on the user id. 
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Campaign/get_campaign
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
        /// Get Campaign, An API end point which can fetch campaign data best on particular campaign id.
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
        /// Get Campaign, An API end point which can return all users who claimed the NFT with respect to given campaign UUId.
        /// </summary>
        /// <param name="CampaignUuid">Campaign Id(Parameter) required for calling this API.</param>
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
