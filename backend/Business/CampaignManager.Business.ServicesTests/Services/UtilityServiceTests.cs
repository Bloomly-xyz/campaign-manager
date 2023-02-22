using CampaignManager.Business.Services.Services;
using CampaignManager.Data.IRepository;
using CampaignManager.Infrastructure.Models.DBModels;
using CampaignManager.Infrastructure.Models.Utilities.RequestModels;
using Moq;
using Xunit;

namespace CampaignManager.Business.ServicesTests.Services
{
    public class UtilityServiceTests
    {
        private readonly Mock<IUtilityRepository> _utilityRepository;
        private readonly UtilityService _utilityService;
        public UtilityServiceTests()
        {
            _utilityRepository = new Mock<IUtilityRepository>();
            _utilityService = new UtilityService(_utilityRepository.Object);
        }

        [Fact]
        public async Task GetAllUtilities_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _utilityRepository.Setup(x => x.GetAllUtilitiesAsync()).ReturnsAsync(new List<Utilities>() { new Utilities {
                PhysicalUtility = true,
                DigitalUtility = true,
                ExperientialUtility = true,
                UtilityDescription = "Testing",
                UtilityIconUrl ="",
            }});

            //ACT
            var mockResponse = await _utilityService.GetAllUtilities();

            //ASSERT
            Assert.NotNull(mockResponse);
        }
        [Fact]
        public async Task GetAllUtilities_Test_WithFailureResponse()
        {
            //ARRANGE 
            _utilityRepository.Setup(x => x.GetAllUtilitiesAsync()).ReturnsAsync(value: null);

            //ACT
            var mockResponse = await _utilityService.GetAllUtilities();

            //ASSERT
            Assert.NotNull(mockResponse);
        }

        [Fact]
        public async Task ClaimUtility_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _utilityRepository.Setup(x => x.GetUtilityClaimedByUserId(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(value: null);
            _utilityRepository.Setup(x => x.CreateClaimedUtilityAsync(It.IsAny<ClaimUtility>())).ReturnsAsync(true);

            //ACT
            var mockResponse = await _utilityService.ClaimUtility(new ClaimUtilityRequestModel());

            //ASSERT
            Assert.NotNull(mockResponse);
        }

        [Fact]
        public async Task ClaimUtility_AlreadyCliamd_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _utilityRepository.Setup(x => x.GetUtilityClaimedByUserId(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new ClaimUtility());

            //ACT
            var mockResponse = await _utilityService.ClaimUtility(new ClaimUtilityRequestModel());

            //ASSERT
            Assert.False(mockResponse.payload);
        }

        [Fact]
        public async Task GetClaimedUtility_Test_WithFailureResponse()
        {
            //ARRANGE 
            _utilityRepository.Setup(x => x.GetUtilityClaimedByUserId(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new ClaimUtility());

            //ACT
            var mockResponse = await _utilityService.GetClaimedUtility(new CheckClaimedUtilityRequestModel());

            //ASSERT
            Assert.False(mockResponse.payload);
        }

        [Fact]
        public async Task GetClaimedUtility_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _utilityRepository.Setup(x => x.GetUtilityClaimedByUserId(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(value: null);

            //ACT
            var mockResponse = await _utilityService.GetClaimedUtility(new CheckClaimedUtilityRequestModel());

            //ASSERT
            Assert.True(mockResponse.payload);
        }

        [Fact]
        public async Task GetShippingPartners_Test_WithSuccessResponse()
        {
            //ARRANGE 
            _utilityRepository.Setup(x => x.GetShippingPartnersAsync()).ReturnsAsync(new List<ShippingPartner>() {
            new ShippingPartner{
                Id = 1,
                ShippingPartnerName = "DHL"
            }
            });
            //ACT
            var mockResponse = await _utilityService.GetShippingPartners();

            //ASSERT
            Assert.NotNull(mockResponse.payload);
        }

        [Fact]
        public async Task GetShippingPartners_Test_WithFailureResponse()
        {
            //ARRANGE 
            _utilityRepository.Setup(x => x.GetShippingPartnersAsync()).ReturnsAsync(value: null);

            //ACT
            var mockResponse = await _utilityService.GetShippingPartners();

            //ASSERT
            Assert.Equal(mockResponse.message, "no Shipping Partner Found");
        }


    }
}
