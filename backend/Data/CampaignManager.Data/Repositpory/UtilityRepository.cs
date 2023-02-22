using CampaignManager.Data.Context;
using CampaignManager.Data.Core;
using CampaignManager.Data.IRepository;
using CampaignManager.Infrastructure.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Data.Repository
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly DBContext _mySqlDBContext;
        private readonly IDBAccess _dbAccess;
        public UtilityRepository(DBContext mySqlDBContext, IDBAccess dBAccess)
        {
            _mySqlDBContext = mySqlDBContext;
            _dbAccess = dBAccess;
        }
        public async Task<bool> CreateUtilitiesAsync(Utilities utilities)
        {
            _mySqlDBContext.Utilities.Add(utilities);
            await _mySqlDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUtilitiesAsync(Utilities utilities)
        {
            _mySqlDBContext.Utilities.Update(utilities);
            await _mySqlDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Utilities>> GetAllUtilitiesAsync()
        {
            return await _mySqlDBContext.Utilities.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
        }

        public async Task<Utilities> GetUtilitiesByIdAsync(int utilityId)
        {
            return await _mySqlDBContext.Utilities.Where(x => x.Id == utilityId && x.IsActive == true && x.IsDeleted == false).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUtilitiesnAsync(Utilities utilities)
        {
            _mySqlDBContext.Utilities.Update(utilities);
            await _mySqlDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<ShippingPartner>> GetShippingPartnersAsync()
        {
            return await _mySqlDBContext.ShippingPartners.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
        }

        public Task<Utilities> GetUtilitiesByUuidAsync(string CompaignUuid)
        {
            throw new NotImplementedException();
        }

        public async Task<ClaimUtility> GetUtilityClaimedByUserId(int userId, int campaignId)
        {
            return await _mySqlDBContext.ClaimUtilities.Where(x => x.UserId == userId && x.CampaignId == campaignId).FirstOrDefaultAsync();
        }

        public async  Task<bool> CreateClaimedUtilityAsync(ClaimUtility claimUtility)
        {
            _mySqlDBContext.ClaimUtilities.Update(claimUtility);
            await _mySqlDBContext.SaveChangesAsync();
            return true;
        }
    }
}
