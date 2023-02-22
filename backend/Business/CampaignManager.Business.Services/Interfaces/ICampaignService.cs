using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Models.CampaignModel.RequestModel;
using CampaignManager.Infrastructure.Models.CampaignModel.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Business.Services.Interfaces
{
    public interface ICampaignService
    {
        Task<GenericApiResponse<CampaignResponseModel>> CreateCampaignAsync(CampaignRequestModel campaignRequestModel);
        Task<GenericApiResponse<List<CampaignResponseModel>>> GetCampaignsListAsync(int userId);
        Task<GenericApiResponse<CampaignResponseModel>> GetCampaignByIdAsync(string campaignUuid);
        Task<GenericApiResponse<List<CampaignClaimDetailResponse>>> GetCampaignClaimDetailsAsync(string campaignUuid);
    }
}
