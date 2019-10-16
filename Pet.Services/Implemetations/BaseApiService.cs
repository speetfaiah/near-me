using Newtonsoft.Json;
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

        public async Task<T> GetDataAsync<T>(string url, params ApiParam[] apiParams)
        {
            var requestMessage = GetRequestMessage(url, apiParams);
            using (var response = await _httpClient.SendAsync(requestMessage))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }

                throw new Exception("bad api request status {content}");
            }
        }

        private HttpRequestMessage GetRequestMessage(string url, params ApiParam[] apiParams)
        {
            var getParams = apiParams.Where(x => x.IsOk && x.Usage == UsageFlags.Query)
                .Select(x => $"{HttpUtility.UrlEncode(x.Key)}={HttpUtility.UrlEncode(x.Value.ToString())}")
                .ToArray();

            var resultUriString = url +
                (getParams.Length > 0
                    ? "?" + string.Join("&", getParams)
                    : string.Empty);

            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(resultUriString, UriKind.Relative)
            };

            foreach (var header in apiParams.Where(x => x.IsOk && x.Usage == UsageFlags.Header))
                message.Headers.Add(header.Key, header.Value.ToString());

            return message;
        }
    }
}
