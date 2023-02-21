using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Data.Core
{
    public interface IDBAccess
    {
        string GetDatabaseConnection(DatabaseOptions databaseOption);
    }
}
