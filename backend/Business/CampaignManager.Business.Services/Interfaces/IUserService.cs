using Amazon.S3.Model;
using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Models.User.RequestModel;
using CampaignManager.Infrastructure.Models.User.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<GenericApiResponse<UserResponseModel>> CreateUserAsync(CreateUserRequest createUserRequest);
    }
}
