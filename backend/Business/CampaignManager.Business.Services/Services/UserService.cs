using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Data.IRepository; 
using CampaignManager.Infrastructure.Common.GenericResponses;
using CampaignManager.Infrastructure.Models.DBModels;
using CampaignManager.Infrastructure.Models.User.RequestModel;
using CampaignManager.Infrastructure.Models.User.ResponseModel; 

namespace CampaignManager.Business.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<GenericApiResponse<UserResponseModel>> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            var user = await _userRepository.GetUserAsync(createUserRequest.EmailAddress, createUserRequest.WalletAddress);
            if(user == null)
            {
                Users users = new Users
                {
                    EmailAddress = createUserRequest.EmailAddress,
                    WalletAddress = createUserRequest.WalletAddress,
                    IsActive= true,
                    IsDeleted= false,
                    CreatedDate= DateTime.UtcNow,
                    ModifiedDate= DateTime.UtcNow,
                };
                var result = await _userRepository.CreateUserAsync(users);
                UserResponseModel userResponseModel = BindUserResponseModel(result);
                return GenericApiResponse<UserResponseModel>.Success(userResponseModel, "User Created Successfully");
            }
            else
            {
                UserResponseModel userResponseModel = BindUserResponseModel(user);
                return GenericApiResponse<UserResponseModel>.Success(userResponseModel, "User Logged In Successfully");
            }
        }

        private static UserResponseModel BindUserResponseModel(Users user)
        {
            return new UserResponseModel
            {
                EmailAddress = user.EmailAddress,
                WalletAddress = user.WalletAddress,
                Id = user.Id,
                FirstName = user.FirstName??"",
                LastName = user.LastName ?? ""

            };
        }
    }
}
