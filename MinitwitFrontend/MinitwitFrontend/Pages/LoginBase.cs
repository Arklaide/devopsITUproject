using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
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
        protected UserInputModel model = new UserInputModel();
        protected bool loading;
        protected string errorText = "";

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        LoginState LoginState { get; set; }
        [Inject]
        private HttpClient _httpClient { get; set; }
   
        protected async void OnValidSubmit()
        {
            var results = await LoginState.LoginUser(model);
         
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

        }
    }
}
