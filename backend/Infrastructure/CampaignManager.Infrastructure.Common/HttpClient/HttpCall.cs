﻿using CampaignManager.Infrastructure.Common.GenericResponses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Infrastructure.Common.HttpClient
{
    public class HttpCall : IHttpCall
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpCall(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">it should not contain base url</param>
        /// <param name="ClientType"> HTTP client mentioned in DI Services </param>
        /// <returns></returns>
        public async Task<GenericApiResponse<T>> Get<T>(string url, string ClientType)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient(ClientType);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                return GenericApiResponse<T>.Success(JsonConvert.DeserializeObject<T>(body), response.ReasonPhrase);
            }
            else
                return GenericApiResponse<T>.Failure(response.ReasonPhrase, APIStatusCodes.InternalServerError);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">it should not contain base url</param>
        /// <param name="ClientType"> HTTP client mentioned in DI Services </param>
        /// <param name="bearerToken">BearerToken</param>
        /// <param name="jsonPayload">Payload data that is passed in request</param>
        /// <returns></returns>
        public async Task<GenericApiResponse<T>> Post<T, P>(string url, string ClientType, string bearerToken, P jsonPayload)
        {
            var stringPayload = JsonConvert.SerializeObject(jsonPayload);
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Headers ={
                            { "Authorization", "Bearer " + bearerToken},
                        },
                Content = new StringContent(stringPayload, UnicodeEncoding.UTF8, "application/json")
            };

            var client = _clientFactory.CreateClient(ClientType);
            client.Timeout = TimeSpan.FromMilliseconds(1000000);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var result = GenericApiResponse<T>.Success(JsonConvert.DeserializeObject<T>(body), response.ReasonPhrase);
                return result;
            }
            else
            {
                var body = await response.Content.ReadAsStringAsync();
                return GenericApiResponse<T>.Failure(body, APIStatusCodes.InternalServerError);

            }
        }
    }
}
