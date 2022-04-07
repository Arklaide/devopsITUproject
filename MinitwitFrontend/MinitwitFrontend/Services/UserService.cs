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
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        public UserService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("authorizedClient");
        }

        public async Task<string> RegisterUser(Userdto user)
        {
            var saveResults = await _client.PostAsync("register", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            if (saveResults.IsSuccessStatusCode)
                return "";
            else
                return "Register Failed";
            //var subscriptions = await _client.GetFromJsonAsync<IEnumerable<Message>>("register");
          
        }
        public async Task<Userdto> LoginUser(string username)
        {
            var saveResults = await _client.PostAsync("login", new StringContent(JsonConvert.SerializeObject(username), Encoding.UTF8, "application/json"));
            if (saveResults.IsSuccessStatusCode)
            { 
                var respString = await saveResults.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<Userdto>(respString);
                return user;
            }
            else
                return null;


        }
        public async Task<Userdto> GetUserInfo(int userId)
        {
            var saveResults = await _client.PostAsync("userinfo", new StringContent(JsonConvert.SerializeObject(userId), Encoding.UTF8, "application/json"));
            if (saveResults.IsSuccessStatusCode)
            { 
                var respString = await saveResults.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<Userdto>(respString);
                return user;
            }
            else
                return null;


        }
    }

}


