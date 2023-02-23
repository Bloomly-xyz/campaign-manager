using CampaignManager.Data.Context;
using CampaignManager.Data.Core;
using CampaignManager.Data.IRepository;
using CampaignManager.Infrastructure.Models.CampaignModel.Dtos;
using CampaignManager.Infrastructure.Models.CampaignModel.RequestModel;
using CampaignManager.Infrastructure.Models.CampaignModel.ResponseModel;
using CampaignManager.Infrastructure.Models.DBModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore; 
using System.Data; 
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Data.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly DBContext _mySqlDBContext;
        private readonly IDBAccess _dbAccess;
        public CampaignRepository(DBContext mySqlDBContext, IDBAccess dBAccess)
        {
            _mySqlDBContext = mySqlDBContext;
            _dbAccess = dBAccess;
        }
        private SqlConnection CreateConnection()
        {
            string ConnectionString = _dbAccess.GetDatabaseConnection(DatabaseOptions.Default);
            return new SqlConnection(ConnectionString);
        }
        public async Task<Campaigns> GetCampaignByIdAsync(int compaignId)
        {
            return await _mySqlDBContext.Campaigns.Where(x => x.Id == compaignId && x.IsActive == true && x.IsDeleted == false).FirstOrDefaultAsync();
        }
        public async Task<CampaignUtilityData> GetAllCampaignsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
        public async Task<Campaigns> GetCampaignByUuidAsync(string CompaignUuid)
        {
            return await _mySqlDBContext.Campaigns.Where(x => x.CampaignUuid == CompaignUuid).FirstOrDefaultAsync();
        }
        public async Task<Campaigns> CreateCampaignAsync(Campaigns campaigns) 
        {
            _mySqlDBContext.Campaigns.Add(campaigns);
            await _mySqlDBContext.SaveChangesAsync();
            return await _mySqlDBContext.Campaigns.Where(x => x.CampaignUuid == campaigns.CampaignUuid).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteCampaignAsync(Campaigns campaigns)
        {
            _mySqlDBContext.Campaigns.Update(campaigns);
            await _mySqlDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Campaigns> UpdateCampaignAsync(Campaigns campaigns)
        {
            _mySqlDBContext.Campaigns.Update(campaigns);
            await _mySqlDBContext.SaveChangesAsync();
            return await _mySqlDBContext.Campaigns.Where(x => x.CampaignUuid == campaigns.CampaignUuid).FirstOrDefaultAsync();
        }

        public async Task<bool> AddCampaignUtilities(List<CampaignUtilities> campaignUtilitiesList)
        {
            _mySqlDBContext.CampaignUtilities.AddRange(campaignUtilitiesList);
            await _mySqlDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveCampaignUtilities(List<CampaignUtilities> campaignUtilitiesList)
        {
            _mySqlDBContext.CampaignUtilities.RemoveRange(campaignUtilitiesList);
            await _mySqlDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<CampaignUtilities>> GetCampaignUtilitiesAsync(int CompaignId)
        {
            return await _mySqlDBContext.CampaignUtilities.Where(x => x.CampaignId == CompaignId).ToListAsync();
        }

        public async Task<List<CampaignResponseModel>> GetAllCampaigns(int UserId) 
        {
            //var res = await (from c in _mySqlDBContext.Campaigns
            //                 join cu in _mySqlDBContext.CampaignUtilities on c.Id equals cu.CampaignId
            //                 join util in _mySqlDBContext.Utilities on cu.UtilityId equals util.Id
            //                 join user in _mySqlDBContext.Users on c.UserId equals user.Id
            //                 where c.UserId.Equals(UserId)
            //                 group cu by cu.CampaignId into g
            //                 select new CampaignResponseModel {
            //                     Id = Convert.ToInt32(g.Key),
            //                     CampaignUuid = g.Select(c=> c.Campaigns.CampaignUuid).FirstOrDefault(),
            //                     CollectionPublicPath = g.Select(c => c.Campaigns.CollectionPublicPath).FirstOrDefault(),
            //                     CampaignName = g.Select(c => c.Campaigns.CampaignName).FirstOrDefault(),
            //                     ContractName = g.Select(c => c.Campaigns.ContractName).FirstOrDefault(),
            //                     CampaignDescription = g.Select(c => c.Campaigns.CampaignDescription).FirstOrDefault(),
            //                     CampaignStartDate = g.Select(c => c.Campaigns.CampaignStartDate).FirstOrDefault(),
            //                     CampaignEndDate = g.Select(c => c.Campaigns.CampaignStartDate).FirstOrDefault(),
            //                     CampaignJson = g.Select(c => c.Campaigns.CampaignJson).FirstOrDefault(),
            //                     CampaignPublicUrl = g.Select(c => c.Campaigns.CampaignPublicUrl).FirstOrDefault(),
            //                     ContractAddress = g.Select(c => c.Campaigns.ContractAddress).FirstOrDefault(),
            //                     ContractStoragePath = g.Select(c => c.Campaigns.ContractStoragePath).FirstOrDefault(),
            //                     UserId = g.Select(c => c.Campaigns.UserId).FirstOrDefault(), 
            //                     Physical = g.Select(c=>c.Utilities.PhysicalUtility).FirstOrDefault(),
            //                     Digital = g.Select(c=>c.Utilities.DigitalUtility).FirstOrDefault(),
            //                     Experencial = g.Select(c=>c.Utilities.ExperientialUtility).FirstOrDefault(),
            //                     IsActive = g.FirstOrDefault().Campaigns.IsActive,
            //                     IsDeleted = g.FirstOrDefault().Campaigns.IsDeleted,
            //                     NoOfClaims = 0, // To do: need claimed user table.
            //                 }).ToListAsync();
            //return res;
            return await _mySqlDBContext.Campaigns
                        .Include(x => x.Users)
                        .Where(x => x.IsActive == true && x.IsDeleted == false && x.UserId == UserId)
                        .Select(c => new CampaignResponseModel
                        {
                            Id = c.Id,
                            CampaignUuid = c.CampaignUuid ?? "",
                            CollectionPublicPath = c.CollectionPublicPath ?? "",
                            CampaignName = c.CampaignName ?? "",
                            ContractName = c.ContractName ?? "",
                            CampaignDescription = c.CampaignDescription ?? "",
                            CampaignStartDate = c.CampaignStartDate,
                            CampaignEndDate = c.CampaignEndDate,
                            CampaignPublicUrl = c.CampaignPublicUrl ?? "",
                            ContractAddress = c.ContractAddress ?? "",
                            ContractStoragePath = c.ContractStoragePath ?? "",
                            UserId = c.UserId,
                            Physical = _mySqlDBContext.CampaignUtilities.Include(c=>c.Utilities).Where(cu=> cu.CampaignId == c.Id).Any(x=>x.Utilities.PhysicalUtility == true),
                            Digital = _mySqlDBContext.CampaignUtilities.Include(c => c.Utilities).Where(cu => cu.CampaignId == c.Id).Any(x => x.Utilities.DigitalUtility == true),
                            Experencial = _mySqlDBContext.CampaignUtilities.Include(c => c.Utilities).Where(cu => cu.CampaignId == c.Id).Any(x => x.Utilities.ExperientialUtility == true),
                            BlockChainTransactionId = c.BlockChainTransactionId ?? "",
                            BlockChainJson = c.BlockChainJson ?? "",
                            IsActive = c.IsActive,
                            IsDeleted = c.IsDeleted,
                            NoOfClaims = _mySqlDBContext.ClaimUtilities.Where(x=>x.CampaignId == c.Id).Count(),
                            CampaignUtilities = _mySqlDBContext.CampaignUtilities
                                                                .Where(x => x.CampaignId == c.Id)
                                                                .Select(c => new CampainUtilitiesRequest
                                                                {
                                                                    utilityId = Convert.ToInt32(c.UtilityId),
                                                                    CampaignUtilityJson = c.CampaignUtilityJson
                                                                }).ToList()
                        })
                        .ToListAsync();
        }

        public async Task<CampaignResponseModel> GetUtilityAndCampaignData(string campaignUuid)
        {
            return await _mySqlDBContext.Campaigns
                        .Include(x => x.Users)
                        .Where(x => x.IsActive == true && x.IsDeleted == false && x.CampaignUuid == campaignUuid)
                        .Select(c => new CampaignResponseModel
                        {
                            Id = c.Id,
                            CampaignUuid = c.CampaignUuid ?? "",
                            CollectionPublicPath = c.CollectionPublicPath ?? "",
                            CampaignName = c.CampaignName ?? "",
                            ContractName = c.ContractName ?? "",
                            CampaignDescription = c.CampaignDescription ?? "",
                            CampaignStartDate = c.CampaignStartDate,
                            CampaignEndDate = c.CampaignEndDate,
                            CampaignPublicUrl = c.CampaignPublicUrl ?? "",
                            ContractAddress = c.ContractAddress ?? "",
                            ContractStoragePath = c.ContractStoragePath ?? "",
                            UserId = c.UserId,
                            Physical = _mySqlDBContext.CampaignUtilities.Include(c => c.Utilities).Where(cu => cu.CampaignId == c.Id).Any(x => x.Utilities.PhysicalUtility == true),
                            Digital = _mySqlDBContext.CampaignUtilities.Include(c => c.Utilities).Where(cu => cu.CampaignId == c.Id).Any(x => x.Utilities.DigitalUtility == true),
                            Experencial = _mySqlDBContext.CampaignUtilities.Include(c => c.Utilities).Where(cu => cu.CampaignId == c.Id).Any(x => x.Utilities.ExperientialUtility == true),
                            BlockChainTransactionId = c.BlockChainTransactionId ?? "",
                            BlockChainJson = c.BlockChainJson ?? "",
                            IsActive = c.IsActive,
                            IsDeleted = c.IsDeleted,
                            NoOfClaims = _mySqlDBContext.ClaimUtilities.Where(x => x.CampaignId == c.Id).Count(),
                            CampaignUtilities = _mySqlDBContext.CampaignUtilities
                                                                .Where(x => x.CampaignId == c.Id)
                                                                .Select(c => new CampainUtilitiesRequest
                                                                {
                                                                    utilityId = Convert.ToInt32(c.UtilityId),
                                                                    CampaignUtilityJson = c.CampaignUtilityJson
                                                                }).ToList()
                        }).FirstOrDefaultAsync();
        }

        public async Task<List<CampaignClaimDetailResponse>> GetCampaignClaimDetails(string CompaignUuid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                var _param = new DynamicParameters();
                _param.Add("@campaignUuid", CompaignUuid);
                var result = await conn.QueryAsync<CampaignClaimDetailResponse>("GetClaimedCampaignsDetail", param: _param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
