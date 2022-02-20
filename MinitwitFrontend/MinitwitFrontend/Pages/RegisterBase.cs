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
    public class RegisterBase : ComponentBase
    {
        protected userDto model = new userDto();
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
            var results = await LoginState.RegisterUser(model);

            StateHasChanged();
            if (results)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                errorText = "We could not register";
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