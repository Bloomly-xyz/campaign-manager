using CampaignManager.Infrastructure.Common.Resources;

using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Infrastructure.Common.Extensions
{
    public static class MessageResource
    {
        public static string GetMessage(this APIStatusCodes code)
        {
            return ApiMessagesResource.ResourceManager.GetString(code.ToString());
        }
    }
}
