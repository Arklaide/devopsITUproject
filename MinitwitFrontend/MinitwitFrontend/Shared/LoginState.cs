using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MinitwitFrontend.Shared
{
    public class LoginState : ComponentBase
    {
       
        public bool isAuthenticated { get; private set; } = false;
        public User loggedInUser { get; private set; }

        public event Action OnAuthenticationChanged;

        [Inject]
        private HttpClient _httpClient { get; set; }

        public async Task<bool> LoginUser(Userdto user)
        {
            //var response = await _httpClient.PostAsJsonAsync<String>("login", "Harpa");

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}
            loggedInUser = new User();
            loggedInUser.username = "Harpa";
            loggedInUser.email = "harpa@harps.is";
            var demomessage = new Message()
            {
                text = "demotext",
                author_id = 1,
                flagged = true,
                message_Id = 1,
                pub_date = DateTime.Today,
                user = loggedInUser
            };
            var listofdemomessages = new List<Message>();
            listofdemomessages.Add(demomessage);
            loggedInUser.messages = listofdemomessages; loggedInUser.user_Id = 1;
            isAuthenticated = true;
           
            
            NotifyAuthenticationHasChanged();
            return true;
        }

        public async Task<bool> RegisterUser(Userdto user)
        {
            //var response = await _httpClient.PostAsJsonAsync<userDto>("login", userObject);

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}
            //loggedInUser = new User();
            //loggedInUser.username = "Harpa";
            //loggedInUser.email = "harpa@harps.is";
            //var demomessage = new Message()
            //{
            //    text = "demotext",
            //    author_id = 1,
            //    flagged = true,
            //    message_Id = 1,
            //    pub_date = DateTime.Today,
            //    user = loggedInUser
            //};
            //var listofdemomessages = new List<Message>();
            //listofdemomessages.Add(demomessage);
            //loggedInUser.messages = listofdemomessages; 
            //loggedInUser.user_Id = 1;
     
            //isAuthenticated = true;


            NotifyAuthenticationHasChanged();
            return true;
        }

        public async Task<bool> LogOutUser()
        {
            //var response = await _httpClient.PostAsJsonAsync<userDto>("login", userObject);

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}

            isAuthenticated = false;
            loggedInUser = new User();

            NotifyAuthenticationHasChanged();
            return true;
        }

        private void NotifyAuthenticationHasChanged() => OnAuthenticationChanged?.Invoke();
    }
}
