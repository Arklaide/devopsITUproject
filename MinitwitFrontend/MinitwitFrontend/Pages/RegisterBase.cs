using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using MinitwitFrontend.Services;
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
        protected Userdto user = new Userdto();
        protected bool loading;
        protected string errorText = "";

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        LoginState LoginState { get; set; }
        [Inject]
        private HttpClient _httpClient { get; set; }
        protected string pwd1 {get; set;}
        protected string pwd2 {get; set;}
        [Inject]
        protected IUserService UserService { get; set; }

        protected async void OnValidSubmit()
        {
            if (pwd1 == pwd2)
            {
                user.pwd = pwd1;
            }
            else
            {
                errorText = "Passwords don't match";
                StateHasChanged();
                return;
            }


            var httpResultError = await UserService.RegisterUser(user);
            if (!string.IsNullOrEmpty(httpResultError))
            {
                errorText = httpResultError;
                return;
            }

            //var results = await LoginState.RegisterUser(user);

            NavigationManager.NavigateTo("/login");
            
        }
        protected override async Task OnInitializedAsync()
        {
            pwd1 = "";
            pwd2 = "";
            if (LoginState.isAuthenticated)
            {
                NavigationManager.NavigateTo("/");
            }
            LoginState.OnAuthenticationChanged += StateHasChanged;

        }
    }
}