using CampaignManager.Data.Context;
using CampaignManager.Data.Core;
using CampaignManager.Data.IRepository;
using CampaignManager.Infrastructure.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _mySqlDBContext;
        private readonly IDBAccess _dbAccess;
        public UserRepository(DBContext mySqlDBContext, IDBAccess dBAccess)
        {
            _mySqlDBContext = mySqlDBContext;
            _dbAccess = dBAccess;
        }

        public async Task<Users> CreateUserAsync(Users users)
        {
            _mySqlDBContext.Users.Add(users);
            await _mySqlDBContext.SaveChangesAsync();
            return await _mySqlDBContext.Users.Where(x => x.EmailAddress == users.EmailAddress && x.WalletAddress == users.WalletAddress).FirstOrDefaultAsync();
        }

        public async Task<Users> GetUserAsync(string emailAddress, string walletAddress)
        {
            return await _mySqlDBContext.Users.Where(x => x.EmailAddress == emailAddress && x.WalletAddress == walletAddress).FirstOrDefaultAsync();
        }
    }
}
