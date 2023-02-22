using CampaignManager.Business.ServicesTests.Common;
using CampaignManager.Data.IRepository;
using CampaignManager.Infrastructure.Models.CampaignModel.RequestModel;
using CampaignManager.Infrastructure.Models.CampaignModel.ResponseModel;
using CampaignManager.Infrastructure.Models.DBModels;
using Moq;
using Xunit;

namespace CampaignManager.Business.Services.Services.Tests
{
    public class CampaignServiceTests
    {
        private Mock<ICampaignRepository> _campaignRepository;
        private CampaignService _campaignService;
        public CampaignServiceTests()
        {
            _campaignRepository = new Mock<ICampaignRepository>();
            _campaignService = new CampaignService(_campaignRepository.Object);
        }

        [Fact]
        public async Task CreateCampaignAsync_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _campaignRepository.Setup(x => x.CreateCampaignAsync(It.IsAny<Campaigns>())).ReturnsAsync(new Campaigns() { });
            _campaignRepository.Setup(x => x.GetCampaignUtilitiesAsync(It.IsAny<int>())).ReturnsAsync(new List<CampaignUtilities>() { new CampaignUtilities {
            CampaignId = 1,
            Campaigns = new Campaigns{
                CampaignDescription = CommonModel.CampaignDescription,
                CampaignEndDate = CommonModel.CampaignEndDate,
                CampaignJson = CommonModel.CampaignJson,
                CampaignName = CommonModel.CampaignName,
                CampaignPublicUrl = CommonModel.CampaignPublicUrl,
                CampaignStartDate = CommonModel.CampaignStartDate,
                CampaignUuid = CommonModel.CampaignUuid,
                CollectionPublicPath = CommonModel.CollectionPublicPath,
                ContractAddress = CommonModel.ContractAddress,
                ContractName = CommonModel.ContractName,
                ContractStoragePath = CommonModel.ContractStoragePath,
                UserId = CommonModel.UserId,
                Id = CommonModel.Id
            },
            }});

            //ACT
            var mockResponse = await _campaignService.CreateCampaignAsync(new CampaignRequestModel());
            //ASSERT
            Assert.NotNull(mockResponse);
        }

        [Fact]
        public async Task UpdateCampaignAsync_Test_WithSuccessResponse()
        {
            //ARRANGE 
            Campaigns campaigns = new Campaigns() {
                CampaignDescription = CommonModel.CampaignDescription,
                CampaignEndDate = CommonModel.CampaignEndDate,
                CampaignJson = CommonModel.CampaignJson,
                CampaignName = CommonModel.CampaignName,
                CampaignPublicUrl = CommonModel.CampaignPublicUrl,
                CampaignStartDate = CommonModel.CampaignStartDate,
                CampaignUuid = CommonModel.CampaignUuid,
                CollectionPublicPath = CommonModel.CollectionPublicPath,
                ContractAddress = CommonModel.ContractAddress,
                ContractName = CommonModel.ContractName,
                ContractStoragePath = CommonModel.ContractStoragePath,
                UserId = CommonModel.UserId,
                Id = CommonModel.Id
            };
            _campaignRepository.Setup(x => x.GetCampaignByUuidAsync(It.IsAny<string>())).ReturnsAsync(campaigns);
            _campaignRepository.Setup(x => x.UpdateCampaignAsync(It.IsAny<Campaigns>())).ReturnsAsync(campaigns);
            _campaignRepository.Setup(x => x.GetCampaignUtilitiesAsync(It.IsAny<int>())).ReturnsAsync(new List<CampaignUtilities>() { new CampaignUtilities {
            CampaignId = 1,Campaigns = campaigns }});

            //ACT
            var mockResponse = await _campaignService.CreateCampaignAsync(new CampaignRequestModel
            {
                CampaignUuid = CommonModel.CampaignUuid
            });

            //ASSERT
            Assert.NotNull(mockResponse);
        }

        [Fact]
        public async Task GetCampaignsListAsync_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _campaignRepository.Setup(x => x.GetAllCampaigns(It.IsAny<int>())).ReturnsAsync(new List<CampaignResponseModel>() { });
            //ACT
            var mockResponse = await _campaignService.GetCampaignsListAsync(Convert.ToInt32(CommonModel.UserId));

            //ASSERT
            Assert.NotNull(mockResponse);
        }

        [Fact]
        public async Task GetCampaignByIdAsync_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _campaignRepository.Setup(x => x.GetCampaignByUuidAsync(It.IsAny<string>())).ReturnsAsync(new Campaigns());
            _campaignRepository.Setup(x => x.GetCampaignUtilitiesAsync(It.IsAny<int>())).ReturnsAsync(new List<CampaignUtilities>());

            //ACT
            var mockResponse = await _campaignService.GetCampaignByIdAsync(CommonModel.CampaignId.ToString());

            //ASSERT
            Assert.NotNull(mockResponse);
        }

        [Fact]
        public async Task GetCampaignByIdAsync_Test_WithFailureResponse()
        {
            //ARRANGE 
            _campaignRepository.Setup(x => x.GetCampaignByUuidAsync(It.IsAny<string>())).ReturnsAsync(value: null); 

            //ACT
            var mockResponse = await _campaignService.GetCampaignByIdAsync(CommonModel.CampaignId.ToString());

            //ASSERT
            Assert.Equal(mockResponse.message, "No Campaign found against given id:"+ CommonModel.CampaignId);
        }

        [Fact]
        public async Task GetCampaignClaimDetailsAsync_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _campaignRepository.Setup(x => x.GetCampaignClaimDetails(It.IsAny<string>())).ReturnsAsync(new List<CampaignClaimDetailResponse>());

            //ACT
            var mockResponse = await _campaignService.GetCampaignClaimDetailsAsync(CommonModel.CampaignId.ToString());

            //ASSERT
            Assert.NotNull(mockResponse.payload);
        }

        [Fact]
        public async Task GetCampaignClaimDetailsAsync_Test_WithFailureResponse()
        {
            //ARRANGE 
            _campaignRepository.Setup(x => x.GetCampaignClaimDetails(It.IsAny<string>())).ReturnsAsync(value: null);

            //ACT
            var mockResponse = await _campaignService.GetCampaignClaimDetailsAsync(CommonModel.CampaignId.ToString());

            //ASSERT
            Assert.Equal(mockResponse.message, "No Campaign  claim Data found against given Campaign!");
        }

    }
}