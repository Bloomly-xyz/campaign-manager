using CampaignManager.Infrastructure.Common.Operation;
using CampaignManager.Infrastructure.Models.AWS.RequestModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Business.Services.Interfaces
{
    public interface IS3bucketService
    {
        Task<OpResult<string>> UploadImage(UploadFileRequest uploadFileRequest);
    }
}
