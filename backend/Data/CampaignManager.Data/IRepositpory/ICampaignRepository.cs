using CampaignManager.Infrastructure.Models.CampaignModel.Dtos;
using CampaignManager.Infrastructure.Models.CampaignModel.ResponseModel;
using CampaignManager.Infrastructure.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Data.IRepository
{
    public interface ICampaignRepository
    {
        Task<Campaigns> GetCampaignByIdAsync(int compaignId);
        Task<CampaignUtilityData> GetAllCampaignsByUserIdAsync(int userId);
        Task<Campaigns> GetCampaignByUuidAsync(string CompaignUuid);
        Task<Campaigns> CreateCampaignAsync(Campaigns campaigns);
        Task<bool> DeleteCampaignAsync(Campaigns campaigns);
        Task<Campaigns> UpdateCampaignAsync(Campaigns campaigns);
        Task<bool> AddCampaignUtilities(List<CampaignUtilities> campaignUtilitiesList);
        Task<List<CampaignUtilities>> GetCampaignUtilitiesAsync(int CompaignId);
        Task<bool> RemoveCampaignUtilities(List<CampaignUtilities> campaignUtilitiesList);
        Task<List<CampaignResponseModel>> GetAllCampaigns(int CampCarUserId);
        Task<List<CampaignClaimDetailResponse>> GetCampaignClaimDetails(string CompaignUuid);
        Task<CampaignResponseModel> GetUtilityAndCampaignData(string campaignUuid);
    }
}
