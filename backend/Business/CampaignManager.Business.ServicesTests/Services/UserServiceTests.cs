using CampaignManager.Business.Services.Services; 
using CampaignManager.Data.IRepository; 
using CampaignManager.Infrastructure.Models.DBModels;
using CampaignManager.Infrastructure.Models.User.RequestModel; 
using Moq; 
using Xunit;

namespace CampaignManager.Business.ServicesTests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRespository;
        private readonly UserService _userService;
        public UserServiceTests()
        {
            _userRespository = new Mock<IUserRepository>();
            _userService = new UserService(_userRespository.Object);
        }

        [Fact]
        public async Task CreateUserAsync_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _userRespository.Setup(x => x.GetUserAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(value: null);
            _userRespository.Setup(x => x.CreateUserAsync(It.IsAny<Users>())).ReturnsAsync(new Users());

            //ACT
            var mockResponse = await _userService.CreateUserAsync(new CreateUserRequest());
            //ASSERT
            Assert.NotNull(mockResponse);
        }
        [Fact]
        public async Task CreateUserAsync_UserAlreadyExisy_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _userRespository.Setup(x => x.GetUserAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Users());
            _userRespository.Setup(x => x.CreateUserAsync(It.IsAny<Users>())).ReturnsAsync(new Users());

            //ACT
            var mockResponse = await _userService.CreateUserAsync(new CreateUserRequest());
            //ASSERT
            Assert.NotNull(mockResponse);
        }
    }
}
