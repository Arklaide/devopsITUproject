using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;

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
    }

}


