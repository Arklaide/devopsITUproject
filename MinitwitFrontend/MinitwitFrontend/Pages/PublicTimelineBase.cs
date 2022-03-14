﻿using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinitwitFrontend.Pages
{
    public class PublicTimelineBase : ComponentBase
    {

        [Inject]
        private HttpClient _httpClient { get; set; }

        protected List<Message> twits { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

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
           
            var loggedInUser = new User();
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
            loggedInUser.messages = listofdemomessages; 
            loggedInUser.user_Id = 1;

            //fake list remove later
            twits = new List<Message>();
            var test = new Message()
            {
                text = "demotext",
                author_id = 1,
                flagged = true,
                message_Id = 1,
                pub_date = DateTime.Today,
                user = loggedInUser
            };
            twits.Add(test);


        }
        protected void GoToUserProfile(int userId)
        {
            NavigationManager.NavigateTo($"/user-timeline/{userId}");
        }

    }

}
