using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
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
        protected userDto user;
        protected List<TwitDto> twits { get; set; }

        protected override void OnParametersSet()
        {
            if (!LoginState.isAuthenticated)
            {
                NavigationManager.NavigateTo("/public-timeline");
            }
            user = LoginState.loggedInUser;
        }

        protected override async Task OnInitializedAsync()
        {
            //var response = await _httpClient.PostAsJsonAsync<userDto>("usertwits", userObject);

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}


            //fake list remove later
            twits = new List<TwitDto>();
            var demoTwit1 = new TwitDto();
            demoTwit1.Date = "20.jan 2022";
            demoTwit1.Name = "Johan Fritze Neve";
            demoTwit1.Twit = "It was my birthday yesterday xD";

            twits.Add(demoTwit1);

        }
    }
}
