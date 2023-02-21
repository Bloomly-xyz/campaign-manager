using CampaignManager.Infrastructure.Common.GenericResponses;

namespace CampaignManager.Infrastructure.Common.HttpClient
{
    public interface IHttpCall
    {
        Task<GenericApiResponse<T>> Get<T>(string url, string ClientType);
        Task<GenericApiResponse<T>> Post<T, P>(string url, string ClientType, string bearerToken, P jsonPayload);
    }
}
