using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.Helper
{
    public class BasePagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
