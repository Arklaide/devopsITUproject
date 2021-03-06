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
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject]
        private HttpClient _httpClient { get; set; }
        [Inject]
        LoginState LoginState { get; set; }
        protected User LoggedInUser {get; set;}
        protected bool isAuthenticated { get; set; } = false;
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LoginState.OnAuthenticationChanged  += async () => await UpdateLoginState();
            if (LoginState.isAuthenticated)
            {
                LoggedInUser = LoginState.loggedInUser;
            }

        }
        protected async Task UpdateLoginState() {
            isAuthenticated = LoginState.isAuthenticated;
            LoggedInUser = LoginState.loggedInUser;
            StateHasChanged();
            await Task.CompletedTask;
        }
        protected async void LogoutUser()
        {
            var results = await LoginState.LogOutUser();
            NavigationManager.NavigateTo("/public-timeline");
        }   
        protected async void LoginUser()
        {
            var results = await LoginState.LogOutUser();
            NavigationManager.NavigateTo("/login");
        } 
        protected async void Register()
        {
            NavigationManager.NavigateTo("/register");
        }
    }
}
