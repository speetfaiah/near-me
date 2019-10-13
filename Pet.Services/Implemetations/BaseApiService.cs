using Newtonsoft.Json;
using Pet.Services.Configs;
using Pet.Services.Models.Base;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Pet.Services.Implemetations
{
    public abstract class BaseApiService
    {
        protected readonly HttpClient _httpClient;

        public BaseApiService(BaseApiConfig config)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(config.BaseUrl),
                Timeout = TimeSpan.FromSeconds(config.Timeout)
            };
        }

        public async Task<ServiceResult<T>> GetDataAsync<T>(string url, params ApiParam[] apiParams)
        {
            try
            {
                var requestMessage = GetRequestMessage(url, apiParams);
                using (var response = await _httpClient.SendAsync(requestMessage))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return new ServiceResult<T>
                        {
                            Data = JsonConvert.DeserializeObject<T>(content)
                        };
                    }

                    return new ServiceResult<T>
                    {
                        Error = new ErrorMeta("bad api request status", (int)response.StatusCode)
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<T>
                {
                    Error = new ErrorMeta(ex.Message)
                };
            }
        }

        private HttpRequestMessage GetRequestMessage(string url, params ApiParam[] apiParams)
        {
            var getParams = apiParams.Where(x => x.IsOk && x.Usage == UsageFlags.Query)
                .Select(x => $"{HttpUtility.UrlEncode(x.Key)}={HttpUtility.UrlEncode(x.Value)}")
                .ToArray();

            var resultUriString = url +
                (getParams.Length > 0
                    ? "?" + string.Join("&", getParams)
                    : string.Empty);

            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(resultUriString)
            };

            foreach (var header in apiParams.Where(x => x.IsOk && x.Usage == UsageFlags.Header))
                message.Headers.Add(header.Key, header.Value);

            return message;
        }
    }
}
