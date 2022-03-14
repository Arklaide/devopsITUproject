using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using MinitwitFrontend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinitwitFrontend.Pages
{
    public class UserProfileBase : ComponentBase
    {
        [Inject]
        private HttpClient _httpClient { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        LoginState LoginState { get; set; }
        [Parameter]
        public string UserId { get; set; }
        protected List<Message> twits = new List<Message>();
        protected bool isFollowingUser { get; set; } = false;
        protected User userThatHasThisProfile;
        protected User currentlyLoggedInUser;
        protected bool isSameUser { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            //var response = await _httpClient.PostAsJsonAsync<userDto>("publicTwits", userObject);

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}
            if (LoginState.isAuthenticated)
            {
                currentlyLoggedInUser = LoginState.loggedInUser;
                if (LoginState.loggedInUser.user_Id.ToString() == UserId)
                {
                    isSameUser = true;
                }
                else
                {
                    isSameUser = false;
                    isFollowingUser = false;
                }
            }
            else
                currentlyLoggedInUser = null;


            var demoUser = new User();
            demoUser.username = "Harpa";
            demoUser.email = "harpa@harps.is";
            var demomessage = new Message()
            {
                text = "demotext",
                author_id = 1,
                flagged = true,
                message_Id = 1,
                pub_date = DateTime.Today,
                user = demoUser
            };
            var listofdemomessages = new List<Message>();
            listofdemomessages.Add(demomessage);
            demoUser.messages = listofdemomessages;
            demoUser.user_Id = 1;


            userThatHasThisProfile = demoUser;


            //fake list remove later
            twits = new List<Message>();
            var test = new Message()
            {
                text = "demotext",
                author_id = 1,
                flagged = true,
                message_Id = 1,
                pub_date = DateTime.Today,
                user = demoUser
            };
            twits.Add(test);


        }
        protected async void FollowUser()
        {
            isFollowingUser = true;
            StateHasChanged();
            await Task.CompletedTask;
        }
        protected async void UnfollowUser()
        {
            isFollowingUser = false;
            StateHasChanged();
            await Task.CompletedTask;

        }
        protected void GoToUserProfile(int userId)
        {
            NavigationManager.NavigateTo($"/user-timeline/{userId}");
        }

    }
}

