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
           
            isLoading = false;
            StateHasChanged();

        }
        protected void GoToUserProfile(int userId)
        {
            NavigationManager.NavigateTo($"/user-timeline/{userId}");
        }

    }

}
