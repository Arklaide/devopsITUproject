using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using MinitwitFrontend.Services;
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

        protected List<Message> twits = new List<Message>();
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        protected IMessageService MessageService { get; set; }

        protected bool isLoading = true;


        protected override async Task OnParametersSetAsync()
        {
            twits = (await MessageService.GetAllPublicTwits()).ToList();
            foreach (var twit in twits)
            {
                Console.WriteLine(twit.text);
            }
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
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
           
            
            isLoading = false;
            StateHasChanged();
        
        //    twits = new List<Message>();
        //    var test = new Message()
        //    {
        //        text = "demotext",
        //        author_id = 1,
        //        flagged = true,
        //        message_Id = 1,
        //        pub_date = DateTime.Today,
        //        user = loggedInUser
        //    };
        //twits.Add(test);


        }
        protected void GoToUserProfile(int userId)
        {
            NavigationManager.NavigateTo($"/user-timeline/{userId}");
        }

    }

}
