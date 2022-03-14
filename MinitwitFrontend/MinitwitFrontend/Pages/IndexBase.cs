using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using MinitwitFrontend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinitwitFrontend.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        LoginState LoginState { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        protected User user;
        protected bool loading;
        protected List<Message> twits { get; set; }
        protected Message twit = new Message();
        protected bool showShareSuccesfulMessage { get; set; }

        protected override void OnParametersSet()
        {
            if (!LoginState.isAuthenticated)
            {
                NavigationManager.NavigateTo("/public-timeline");
            }
            user = LoginState.loggedInUser;
        }

        protected async void OnShareTwit()
        {
            showShareSuccesfulMessage = true;
            var demoTwit1 = new Message();
            demoTwit1.pub_date = DateTime.Now;
            var user = new User();
            user.username = "Harpa";
            demoTwit1.user = user;
            demoTwit1.text = "some twit";

            twits.Add(demoTwit1);
            StateHasChanged();
            await Task.CompletedTask;
        }

        protected void GoToUserProfile(int userId)
        {
            NavigationManager.NavigateTo($"/user-timeline/{userId}");
        }

        protected override async Task OnInitializedAsync()
        {
            //var response = await _httpClient.PostAsJsonAsync<userDto>("usertwits", userObject);

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}

            showShareSuccesfulMessage = false;
            //fake list remove later
            twits = new List<Message>();
            var demoTwit1 = new Message();
            demoTwit1.pub_date = DateTime.Now;
            var user = new User();
            user.username = "Harpa";
            demoTwit1.user = user;
            demoTwit1.text = "some twit";

            twits.Add(demoTwit1);

        }
    }
}
