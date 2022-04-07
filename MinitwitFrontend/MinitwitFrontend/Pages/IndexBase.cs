using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using MinitwitFrontend.Services;
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

        [Inject] protected IMessageService MessageService { get; set; }
        protected User user;
        protected bool isLoading = true;
        protected List<Message> twits { get; set; }
        protected Message twit = new Message();
        protected bool showShareSuccesfulMessage { get; set; }


        protected override async void OnParametersSet()
        {
            if (!LoginState.isAuthenticated)
            {
                NavigationManager.NavigateTo("/public-timeline");
                return;
            }
            user = LoginState.loggedInUser;
            twits = (await MessageService.GetAllPrivateTwits(user.username)).ToList();
            foreach (var twit in twits)
            {
                twit.user = user;
            }
            //twits = new List<Message>();
            isLoading = false;
            StateHasChanged();
        }

        protected async void OnShareTwit()
        {
            isLoading = true;
            StateHasChanged();

            Stringwrapper currentTwit = new Stringwrapper();
            currentTwit.content = twit.text;
            bool result = (await MessageService.CreateATwit(currentTwit, user.username));
            if (result)
            {
                showShareSuccesfulMessage = true;
                twits = (await MessageService.GetAllPrivateTwits(user.username)).ToList();
                foreach (var twit in twits)
                {
                    twit.user = user;
                }
                twit = new Message();
            }
            else
            {
                showShareSuccesfulMessage = false;
            }

            isLoading = false;
            StateHasChanged();
            await Task.CompletedTask;
        }

        protected void GoToUserProfile(int userId)
        {
            NavigationManager.NavigateTo($"/user-timeline/{userId}");
        }

        protected override async Task OnInitializedAsync()
        {
            
        }
    }
}
