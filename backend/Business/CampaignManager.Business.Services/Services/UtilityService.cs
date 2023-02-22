using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Data.IRepository;
using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Models.DBModels;
using CampaignManager.Infrastructure.Models.Utilities.RequestModels;
using CampaignManager.Infrastructure.Models.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Business.Services.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly IUtilityRepository _utilityRepository;
        public UtilityService(IUtilityRepository utilityRepository)
        {
            _utilityRepository = utilityRepository;
        }

        public async Task<GenericApiResponse<bool>> ClaimUtility(ClaimUtilityRequestModel claimUtilityRequestModel)
        {
            var utilityClaimed = await _utilityRepository.GetUtilityClaimedByUserId(claimUtilityRequestModel.UserId, claimUtilityRequestModel.CampaignId);
            if(utilityClaimed == null)
            {
                ClaimUtility claimUtility = new ClaimUtility 
                { 
                    Uuid =  Guid.NewGuid().ToString(),
                    CampaignId = claimUtilityRequestModel.CampaignId,
                    UserId = claimUtilityRequestModel.UserId,
                    ClaimJson= claimUtilityRequestModel.ClaimJson,
                    BlockChainTransactionId= claimUtilityRequestModel.BlockChainTransactionId,
                    IsActive = true,
                    IsDeleted= false,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate= DateTime.UtcNow
                };
                var result = await _utilityRepository.CreateClaimedUtilityAsync(claimUtility);
                return GenericApiResponse<bool>.Success(result,"User Claimed Successfully");
            }
            else
                return GenericApiResponse<bool>.Failure("User Already Claimed", APIStatusCodes.UserAlreadyClaimed);
        }

        public async Task<GenericApiResponse<List<UtilitiesResponseModel>>> GetAllUtilities()
        {
            var result =  await _utilityRepository.GetAllUtilitiesAsync();
            if (result != null && result.Count > 0)
            {
                List<UtilitiesResponseModel> utilitiesResponseList = new List<UtilitiesResponseModel>();
                foreach (var item in result)
                {
                    UtilitiesResponseModel utilitiesResponseModel = new UtilitiesResponseModel
                    {
                        Id = item.Id,
                        UtitilityName = item.UtitilityName,
                        Digital = item.DigitalUtility,
                        Physical = item.PhysicalUtility,
                        Experiential = item.ExperientialUtility,
                        UtilityDescription = item.UtilityDescription,
                        UtilityIconUrl = item.UtilityIconUrl,
                        CreatedDate = item.CreatedDate,
                        ModifiedDate = item.ModifiedDate,
                        IsActive = item.IsActive,
                        IsDeleted = item.IsDeleted
                    };
                    utilitiesResponseList.Add(utilitiesResponseModel);
                }
                return GenericApiResponse<List<UtilitiesResponseModel>>.Success(utilitiesResponseList, "User Created Successfully");
            }
            else
            {
                return GenericApiResponse<List<UtilitiesResponseModel>>.Failure("no utility found", APIStatusCodes.NoDataFound);
            }
        }

        public async Task<GenericApiResponse<bool>> GetClaimedUtility(CheckClaimedUtilityRequestModel checkClaimedUtilityRequest)
        {
            var utilityClaimed = await _utilityRepository.GetUtilityClaimedByUserId(checkClaimedUtilityRequest.UserId, checkClaimedUtilityRequest.CampaignId);
            if (utilityClaimed != null)
            {
                return GenericApiResponse<bool>.Failure("User Already Claimed",APIStatusCodes.UserAlreadyClaimed);
            }
            else
                return GenericApiResponse<bool>.Success(true,"User can avail the Utility");
        }

        public async Task<GenericApiResponse<List<ShippingPartnerResponseModel>>> GetShippingPartners()
        {
            var result = await _utilityRepository.GetShippingPartnersAsync();
            if (result != null && result.Count > 0)
            {
                List<ShippingPartnerResponseModel> shippingPartnersList = new List<ShippingPartnerResponseModel>();
                foreach (var item in result)
                {
                    ShippingPartnerResponseModel shippingPartners = new ShippingPartnerResponseModel
                    {
                        ShippingPartnerId = item.Id,
                        ShippingPartnerName = item.ShippingPartnerName
                    };
                    shippingPartnersList.Add(shippingPartners);
                }
                return GenericApiResponse<List<ShippingPartnerResponseModel>>.Success(shippingPartnersList, "User Created Successfully");
            }
            else
            {
                return GenericApiResponse<List<ShippingPartnerResponseModel>>.Failure("no Shipping Partner Found", APIStatusCodes.NoDataFound);
            }
        }
    }
}
