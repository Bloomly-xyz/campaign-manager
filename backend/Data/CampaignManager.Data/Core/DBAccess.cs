using CampaignManager.Infrastructure.Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Data.Core
{
    public class DBAccess : IDBAccess
    {
        private readonly ConnectionStrings _connectionStrings;

        public DBAccess(ConnectionStrings options)
        {
            _connectionStrings = options;
        }

        /// <summary>
        /// DB Access method to return database connection.
        /// </summary>
        /// <param name="databaseOption"></param>
        /// <param name="returnString"></param>
        /// <returns></returns>
        public string GetDatabaseConnection(DatabaseOptions databaseOption)
        {
            string returnString = "";
            switch (databaseOption)
            {
                case DatabaseOptions.Default:
                    returnString = _connectionStrings.DefaultConnection;
                    break;

                default:
                    returnString = _connectionStrings.DefaultConnection;
                    break;
            }

            return returnString;
        }
    }
}
