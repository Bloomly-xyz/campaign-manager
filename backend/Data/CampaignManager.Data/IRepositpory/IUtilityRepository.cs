using CampaignManager.Infrastructure.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Data.IRepository
{
    public interface IUtilityRepository
    {
        Task<Utilities> GetUtilitiesByIdAsync(int utilityId);
        Task<List<Utilities>> GetAllUtilitiesAsync();
        Task<Utilities> GetUtilitiesByUuidAsync(string CompaignUuid);
        Task<bool> CreateUtilitiesAsync(Utilities utilities);
        Task<bool> DeleteUtilitiesAsync(Utilities utilities);
        Task<bool> UpdateUtilitiesnAsync(Utilities utilities);
        Task<List<ShippingPartner>> GetShippingPartnersAsync();
        Task<ClaimUtility> GetUtilityClaimedByUserId(int UserId, int utilityId);
        Task<bool> CreateClaimedUtilityAsync(ClaimUtility claimUtility);
    }
}
