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
    public class MessageService : IMessageService
    {
        private readonly HttpClient _client;
        public MessageService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("authorizedClient");
        }

        public async Task<IEnumerable<Message>> GetAllPublicTwits()
        {
            var subscriptions = await _client.GetFromJsonAsync<IEnumerable<Message>>("/public");
            return subscriptions;
        }
        public async Task<IEnumerable<Message>> GetAllPrivateTwits(string username)
        {
            var subscriptions = await _client.GetFromJsonAsync<IEnumerable<Message>>($"msgs/{username}");
            return subscriptions;
        }
        public async Task<bool> CreateATwit(Stringwrapper twit, string userName)
        {
            var saveResults = await _client.PostAsync($"msgs/{userName}", new StringContent(JsonConvert.SerializeObject(twit), Encoding.UTF8, "application/json"));
            if (saveResults.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }

}


