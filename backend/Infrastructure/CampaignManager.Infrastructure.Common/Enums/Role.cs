using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Common.Enums
{
    public enum Role
    {
        [Description("User")]
        USER = 1,
        [Description("Client")]
        CLIENT = 2,
        [Description("Admin")]
        ADMIN = 3,
        [Description("SuperAdmin")]
        SUPERADMIN = 4
    }
}
