using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Business.Services.Services;
using CampaignManager.Infrastructure.Models.User.RequestModel;
using CampaignManager.Infrastructure.Models.Utilities.RequestModels;
using CampaignManager.Infrastructure.Models.Utilities.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CampaignManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : SecureController
    {
        private readonly IUtilityService _utilityService;
        public UtilityController(IUtilityService utilityService)
        {
            _utilityService= utilityService;
        }
        /// <summary>
        /// Get all utilities, that may include physical, digital, experiential.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Utility/get_utilities
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(List<ShippingPartnerResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet("get_utilities")]
        public async Task<IActionResult> GetUtilities()
        {
            var result = await _utilityService.GetAllUtilities();
            if (result.errorCode > 0)
                return GenericApiResponse(default(IActionResult), result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, "Success", HttpStatusCode.OK);
        }
        /// <summary>
        /// Get all shipping partners, In case of physical utility claim creator will assign specific shipping partner with respect to country location. User will receive utility gift with the selected shipping partner.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Utility/get_shipping_partners
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(List<ShippingPartnerResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet("get_shipping_partners")]
        public async Task<IActionResult> GetShippingPartners()
        {
            var result = await _utilityService.GetShippingPartners();
            if (result.errorCode > 0)
                return GenericApiResponse(default(IActionResult), result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, "Success", HttpStatusCode.OK);
        }

        /// <summary>
        /// Claim Utility.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Utility/claim_utility
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpPost("claim_utility")]
        public async Task<IActionResult> ClaimUtility([FromBody] ClaimUtilityRequestModel claimUtilityRequest)
        {
            var result = await _utilityService.ClaimUtility(claimUtilityRequest);
            if (result.errorCode > 0)
                return GenericApiResponse(default(IActionResult), result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, "Success", HttpStatusCode.OK);
        }

        /// <summary>
        /// Get Claimed Utility.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Utility/get_claim_utility
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(List<ShippingPartnerResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpPost("get_claimed_utility")]
        public async Task<IActionResult> GetClaimedUtility([FromBody] CheckClaimedUtilityRequestModel checkClaimedUtilityRequest)
        {
            var result = await _utilityService.GetClaimedUtility(checkClaimedUtilityRequest);
            if (result.errorCode > 0)
                return GenericApiResponse(default(IActionResult), result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, result.message, HttpStatusCode.OK);
        }
    }
}
