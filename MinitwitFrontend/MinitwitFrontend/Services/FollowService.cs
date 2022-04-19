using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using Newtonsoft.Json;

namespace MinitwitFrontend.Services
{
    public class FollowService : IFollowService
    {
        private readonly HttpClient _client;
        public FollowService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("authorizedClient");
        }
        public async Task<bool> followOrUnfollow(FllwDTO followData, string userName)
        {
            var saveResults = await _client.PostAsync($"fllws/{userName}", new StringContent(JsonConvert.SerializeObject(followData), Encoding.UTF8, "application/json"));
            if (saveResults.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }

}


