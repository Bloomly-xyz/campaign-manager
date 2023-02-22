using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Infrastructure.Models.User.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CampaignManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : SecureController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Create User in a database with Blocto Address.
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/User/create_user
        ///     {
        ///        "EmailAddress": "test@CampaignManager.xyz",
        ///        "WalletAddress": "x123213213hkjxac"
        ///     }
        /// </remarks>
        /// <response code="200">Returns success response</response>
        /// <response code="500">If exception failed</response> 
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpPost("create_user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var result = await _userService.CreateUserAsync(createUserRequest);
            if (result.errorCode > 0)
                return GenericApiResponse(result.payload, result.message, HttpStatusCode.BadRequest);
            else
                return GenericApiResponse(result.payload, result.message, HttpStatusCode.OK);
        }
    }
}
