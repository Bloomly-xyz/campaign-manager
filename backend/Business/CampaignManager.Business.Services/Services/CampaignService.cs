using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Data.IRepository;
using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Models.CampaignModel.RequestModel;
using CampaignManager.Infrastructure.Models.CampaignModel.ResponseModel;
using CampaignManager.Infrastructure.Models.DBModels;
using System.Collections.Generic;
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Business.Services.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<GenericApiResponse<CampaignResponseModel>> CreateCampaignAsync(CampaignRequestModel campaignRequestModel)
        {
            Campaigns campaigns = new Campaigns();
            if (!string.IsNullOrEmpty(campaignRequestModel.CampaignUuid))
            {
                campaigns = await _campaignRepository.GetCampaignByUuidAsync(campaignRequestModel.CampaignUuid);
                if (campaigns != null)
                {
                    var result = await BindCampaignDbModel(campaignRequestModel, campaigns);
                    var campaignResponse = await _campaignRepository.UpdateCampaignAsync(result);
                    var campaignUtilities = await _campaignRepository.GetCampaignUtilitiesAsync(campaignResponse.Id);
                    var responseModel = await BindCampaignUtilityData(campaignResponse, campaignUtilities);
                    return GenericApiResponse<CampaignResponseModel>.Success(responseModel, "Campaign Created Successfully");
                }
                else
                    return GenericApiResponse<CampaignResponseModel>.Failure("No Campaign found against given id", APIStatusCodes.NoDataFound);
            }
            else
            {
                campaigns.CampaignUuid = Guid.NewGuid().ToString();
                campaigns.IsActive = false;
                campaigns.IsDeleted = false;
                campaigns.CreatedDate = DateTime.UtcNow;
                campaigns.ModifiedDate = DateTime.UtcNow;
                campaigns.UserId = campaignRequestModel.UserId;
                campaigns.CampaignUuid = Guid.NewGuid().ToString();
                var result = await BindCampaignDbModel(campaignRequestModel, campaigns);
                var campaignResponse = await _campaignRepository.CreateCampaignAsync(result);
                var campaignUtilities = await _campaignRepository.GetCampaignUtilitiesAsync(campaignResponse.Id);
                var responseModel = await BindCampaignUtilityData(campaignResponse, campaignUtilities);
                return GenericApiResponse<CampaignResponseModel>.Success(responseModel, "Campaign Updated Successfully");
            }
        }
        public async Task<GenericApiResponse<List<CampaignResponseModel>>> GetCampaignsListAsync(int userId)
        {
            var response = await _campaignRepository.GetAllCampaigns(userId);
             if (response != null)
                return GenericApiResponse<List<CampaignResponseModel>>.Success(response, "Success");
            else
                return GenericApiResponse<List<CampaignResponseModel>>.Failure("No campaign found!", APIStatusCodes.NoDataFound);
        }


        private async Task<CampaignResponseModel> BindCampaignUtilityData(Campaigns campaignResponse, List<CampaignUtilities> campaignUtilities)
        {
            CampaignResponseModel campaignResponseModel = new CampaignResponseModel()
            {
                Id = campaignResponse.Id,
                CampaignUuid = campaignResponse.CampaignUuid,
                CampaignName = campaignResponse.CampaignName,
                CampaignDescription = campaignResponse.CampaignDescription,
                CampaignStartDate = campaignResponse.CampaignStartDate,
                CampaignEndDate = campaignResponse.CampaignEndDate,
                ContractAddress = campaignResponse.ContractAddress,
                ContractName = campaignResponse.ContractName,
                ContractStoragePath = campaignResponse.ContractStoragePath,
                CollectionPublicPath = campaignResponse.CollectionPublicPath,
                CampaignJson = campaignResponse.CampaignJson,
                UserId = campaignResponse.UserId,
                CampaignPublicUrl = campaignResponse.CampaignPublicUrl
            };
            campaignResponseModel.CampaignUtilities = campaignUtilities.Where(x => x.CampaignId == campaignResponse.Id).Select(c => new CampainUtilitiesRequest
            {
                utilityId = Convert.ToInt32(c.UtilityId),
                CampaignUtilityJson = c.CampaignUtilityJson
            }).ToList();
            return campaignResponseModel;
        }

        private async Task<Campaigns> BindCampaignDbModel(CampaignRequestModel campaignRequestModel, Campaigns campaign )
        {

            switch (campaignRequestModel.stepsEnum)
            {
                case CampaignStepsEnum.SelectContract:
                    campaign.ContractName= campaignRequestModel.ContractName;
                    campaign.ContractAddress = campaignRequestModel.ContractAddress;
                    campaign.CollectionPublicPath = campaignRequestModel.CollectionPublicPath;
                    campaign.ContractStoragePath = campaignRequestModel.ContractStoragePath;
                    break;

                case CampaignStepsEnum.ComunityTargeting:
                   campaign.CampaignJson = campaignRequestModel.CampaignJson;
                        break;

                case CampaignStepsEnum.AttachUtility:
                    await CreateUpdateCampaignUtilities(campaignRequestModel, campaign);
                    campaign.CampaignName= campaignRequestModel.CampaignName;
                    campaign.CampaignDescription= campaignRequestModel.CampaignDescription;
                    campaign.CampaignStartDate = campaignRequestModel.CampaignStartDate;
                    campaign.CampaignEndDate= campaignRequestModel.CampaignEndDate;
                    break;

                case CampaignStepsEnum.Confirmation:
                    campaign.IsActive = true;
                    campaign.ModifiedDate = DateTime.UtcNow;
                    campaign.CampaignPublicUrl = campaignRequestModel.CampaignPublicUrl;
                    break;

                default:
                    break;
            }
            return campaign;
        }

        private async Task CreateUpdateCampaignUtilities(CampaignRequestModel campaignRequestModel, Campaigns campaigns)
        {
            List<CampaignUtilities> campaignUtilityList = await _campaignRepository.GetCampaignUtilitiesAsync(campaigns.Id);
            if (campaignUtilityList != null && campaignUtilityList.Count > 0)
            {
                await _campaignRepository.RemoveCampaignUtilities(campaignUtilityList);
                
            }
            List<CampaignUtilities> campaignUtilitieList = new List<CampaignUtilities>();
            foreach (var item in campaignRequestModel.CampaignUtilities)
            {
                CampaignUtilities campaignUtilities = new CampaignUtilities();
                campaignUtilities.CampaignUtilityJson = item.CampaignUtilityJson;
                campaignUtilities.CampaignId = campaigns.Id;
                campaignUtilities.UtilityId = item.utilityId;
                campaignUtilitieList.Add(campaignUtilities);
            }
            await _campaignRepository.AddCampaignUtilities(campaignUtilitieList);
        }

        public async Task<GenericApiResponse<CampaignResponseModel>> GetCampaignByIdAsync(string campaignUuid)
        {
            var campaignResponse = await _campaignRepository.GetUtilityAndCampaignData(campaignUuid);
            if (campaignResponse != null)
            {
                return GenericApiResponse<CampaignResponseModel>.Success(campaignResponse, "Campaign Created Successfully");
            }
            else
                return GenericApiResponse<CampaignResponseModel>.Failure("No Campaign found against given id:"+ campaignUuid, APIStatusCodes.NoDataFound);
        }

        public async Task<GenericApiResponse<List<CampaignClaimDetailResponse>>> GetCampaignClaimDetailsAsync(string campaignUuid)
        {
            var campaignResponse = await _campaignRepository.GetCampaignClaimDetails(campaignUuid);
            if (campaignResponse != null && campaignResponse.Count > 0)
            {
                return GenericApiResponse<List<CampaignClaimDetailResponse>>.Success(campaignResponse, "Success");
            }
            else
                return GenericApiResponse<List<CampaignClaimDetailResponse>>.Failure("No Campaign  claim Data found against given Campaign!", APIStatusCodes.NoDataFound);
        }
    }
}
