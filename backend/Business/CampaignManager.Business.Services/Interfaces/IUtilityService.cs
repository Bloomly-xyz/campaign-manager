using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Models.User.RequestModel;
using CampaignManager.Infrastructure.Models.User.ResponseModel;
using CampaignManager.Infrastructure.Models.Utilities.RequestModels;
using CampaignManager.Infrastructure.Models.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Business.Services.Interfaces
{
    public interface IUtilityService
    {
        Task<GenericApiResponse<List<UtilitiesResponseModel>>> GetAllUtilities();
        Task<GenericApiResponse<List<ShippingPartnerResponseModel>>> GetShippingPartners();
        Task<GenericApiResponse<bool>> ClaimUtility(ClaimUtilityRequestModel claimUtilityRequestModel);
        Task<GenericApiResponse<bool>> GetClaimedUtility(CheckClaimedUtilityRequestModel checkClaimedUtilityRequest);
    }
}
