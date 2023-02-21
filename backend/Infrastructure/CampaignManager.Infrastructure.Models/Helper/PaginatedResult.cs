using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Infrastructure.Models.Helper
{
    public class PaginatedListResult<T>
        where T : class
    {
        public List<T> PageModel { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
