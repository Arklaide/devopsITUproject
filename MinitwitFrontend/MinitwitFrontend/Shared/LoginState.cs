using Microsoft.AspNetCore.Components;
using MinitwitFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinitwitFrontend.Shared
{
    public class LoginState : ComponentBase
    {
       
        public bool isAuthenticated { get; private set; } = false;
        public userDto loggedInUser { get; private set; }

        public event Action OnAuthenticationChanged;

        public async Task<bool> LoginUser(UserInputModel user)
        {
            //var response = await _httpClient.PostAsJsonAsync<userDto>("login", userObject);

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}
            loggedInUser = new userDto();
            loggedInUser.Username = "Harpa";
            loggedInUser.Email = "harpa@harps.is";
            loggedInUser.Id = 1;
            isAuthenticated = true;
           
            
            NotifyAuthenticationHasChanged();
            return true;
        }

        public async Task<bool> RegisterUser(userDto user)
        {
            //var response = await _httpClient.PostAsJsonAsync<userDto>("login", userObject);

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}
            loggedInUser = user;
            isAuthenticated = true;


            NotifyAuthenticationHasChanged();
            return true;
        }

        public async Task<bool> LogOutUser()
        {
            //var response = await _httpClient.PostAsJsonAsync<userDto>("login", userObject);

            //if (response.IsSuccessStatusCode)
            //{
            //    isAuthenticated = true;
            //}
            //else
            //{
            //    isAuthenticated = false;

            //}

            isAuthenticated = false;
            loggedInUser = new userDto();

            NotifyAuthenticationHasChanged();
            return true;
        }

        private void NotifyAuthenticationHasChanged() => OnAuthenticationChanged?.Invoke();
    }
}
