using CampaignManager.Infrastructure.Common.Operation;
using CampaignManager.Infrastructure.Models.ConfigModels;
using CampaignManager.Infrastructure.Models.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CampaignManager.Api.Controllers
{
    public class SecureController : Microsoft.AspNetCore.Mvc.Controller
    {
        public string Token {
            get
            {
               return this.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            }
        }
        

        protected IActionResult GenericApiResponse<T>(T payload, string message, HttpStatusCode responseType, Exception exception = null, bool isSucces = true)
        {
            ApiResponse<T> apiResponse = new ApiResponse<T>();
            apiResponse.StatusCodeValue = (int)responseType;

            if (responseType == HttpStatusCode.ExpectationFailed)
            {
                //apiResponse.Exception = exception;
                apiResponse.ExceptionStackTrace = exception.StackTrace.ToString();
                apiResponse.StatusCode = HttpStatusCode.ExpectationFailed;
                apiResponse.Message = message;
                return BadRequest(apiResponse);
            }
            else if (responseType == HttpStatusCode.BadRequest)
            {
                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Success = false;
                apiResponse.Message = message;
                return BadRequest(apiResponse);
            }
            else if (responseType == HttpStatusCode.Forbidden)
            {
                apiResponse.StatusCode = HttpStatusCode.Forbidden;
                apiResponse.Success = false;
                apiResponse.Message = message;
                return BadRequest(apiResponse);
            }
            else if (responseType == HttpStatusCode.NoContent)
            {
                apiResponse.StatusCode = HttpStatusCode.NoContent;
                apiResponse.Success = false;
                apiResponse.Message = message;
                return BadRequest(apiResponse);
            }
            else if (responseType == HttpStatusCode.NotFound)
            {
                apiResponse.StatusCode = HttpStatusCode.NotFound;
                apiResponse.Success = false;
                apiResponse.Message = message;
                return BadRequest(apiResponse);
            }
            else
            {
                apiResponse.Payload = payload;
                apiResponse.Exception = null;
                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Success = isSucces;
                apiResponse.Message = string.IsNullOrEmpty(message) ? "Success" : message;
                return Ok(apiResponse);
            }
        }

        private static bool IsDate(string tempDate)
        {
            DateTime fromDateValue;
            if (DateTime.TryParseExact(tempDate.Replace("-", "/"), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue))
                return true;
            else
                return false;
        }
        protected IActionResult ValidateResponce<T>(OpResult<T> result, string message = null)
        {
            if (result.Succeeded)
                return GenericApiResponse(result, message == null ? "" : message, HttpStatusCode.OK, null, true);
            else
                return GenericApiResponse(default(IActionResult), "", HttpStatusCode.ExpectationFailed, result.Exception, false);
        }
    }
}
