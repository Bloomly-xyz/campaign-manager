using CampaignManager.Infrastructure.Models.DBModels;
using CampaignManager.Infrastructure.Models.User.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Data.IRepository
{
    public interface IUserRepository
    {
        Task<Users> GetUserAsync(string emailAddress, string walletAddress);
        Task<Users> CreateUserAsync(Users users);
    }
}
