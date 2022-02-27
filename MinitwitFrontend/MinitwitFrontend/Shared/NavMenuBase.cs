using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinitwitFrontend.Shared
{
    public class NavMenuBase : ComponentBase
    {
        private bool collapseNavMenu = true;
        [Inject]
        protected LoginState LoginState { get; set; }
        protected bool isAuthenticated = false;
       

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected async void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;

        }
        protected override async Task OnInitializedAsync()
        {
            LoginState.OnAuthenticationChanged += TestFunction;
            isAuthenticated = LoginState.isAuthenticated;
        }

        protected async void TestFunction()
        {
            StateHasChanged();
        }


    }
}
