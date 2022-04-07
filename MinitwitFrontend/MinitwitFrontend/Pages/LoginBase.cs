using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using MinitwitFrontend.Services;
using MinitwitFrontend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MinitwitFrontend.Pages
{
    public class LoginBase : ComponentBase
    {
        protected Userdto user = new Userdto();
        protected bool isLoading = true;
        protected string errorText = "";

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        LoginState LoginState { get; set; }
        [Inject]
        private HttpClient _httpClient { get; set; }
        [Inject]
        protected IUserService UserService { get; set; }

        public async void OnValidSubmit()
        {
            user = await UserService.LoginUser(user.username);
            if (user == null)
            {
                errorText = "Could not log you in.";
                return;
            }
            var results = await LoginState.LoginUser(user);
         
            StateHasChanged();
            if (results)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                errorText = "We could not log you in";
            }
        }
        protected override async Task OnInitializedAsync()
        {
            
            if (LoginState.isAuthenticated)
            {
                NavigationManager.NavigateTo("/");
            }
            LoginState.OnAuthenticationChanged += StateHasChanged;
            isLoading = false;
        }
    }
}
