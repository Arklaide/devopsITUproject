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
    public class UserProfileBase : ComponentBase
    {
        [Inject]
        private HttpClient _httpClient { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        LoginState LoginState { get; set; }

        [Parameter]
        public string UserId { get; set; }
        protected List<Message> twits = new List<Message>();
        protected bool isFollowingUser { get; set; } = false;
        //protected User userThatHasThisProfile;
        protected User currentlyLoggedInUser;
        protected Userdto UserProfileUser;
        protected bool isSameUser { get; set; } = false;
        protected bool isLoading { get; set; } = true;
        [Inject] protected IUserService UserService { get; set; }
        [Inject] protected IMessageService MessageService { get; set; }
        [Inject] protected IFollowService FollowService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int UserIdInt = 0;
            bool parseWorked = int.TryParse(UserId, out UserIdInt);
            if (!parseWorked)
            {
                isLoading = false;
                return;
            }
            UserProfileUser = (await UserService.GetUserInfo(UserIdInt));
            twits = (await MessageService.GetAllPrivateTwits(UserProfileUser.username)).ToList();
            foreach (var twit in twits)
            {
                Console.WriteLine(twit.text);
            }
            StateHasChanged();


            if (LoginState.isAuthenticated)
            {
                currentlyLoggedInUser = LoginState.loggedInUser;
                if (LoginState.loggedInUser.user_Id.ToString() == UserId)
                {
                    isSameUser = true;
                }
                else
                {
                    isSameUser = false;
                    isFollowingUser = false;
                }
            }
            else
                currentlyLoggedInUser = null;
            isLoading = false;
            StateHasChanged();
        }
        protected async void FollowUser()
        {
            isLoading = true;

            FllwDTO followInfo = new FllwDTO();
            followInfo.follow = UserProfileUser.username;
            bool result = await(FollowService.followOrUnfollow(followInfo, currentlyLoggedInUser.username));
            if (result)
                isFollowingUser = true;
            isLoading = false;
            StateHasChanged();
            await Task.CompletedTask;
        }
        protected async void UnfollowUser()
        {
            FllwDTO followInfo = new FllwDTO();
            followInfo.unfollow = UserProfileUser.username;
            bool result = await (FollowService.followOrUnfollow(followInfo, currentlyLoggedInUser.username));
            if (result)
                isFollowingUser = false;
            isLoading = false;
            StateHasChanged();
            await Task.CompletedTask;

        }
        protected void GoToUserProfile(int userId)
        {
            NavigationManager.NavigateTo($"/user-timeline/{userId}");
        }
        protected string GetImageSource()
        {
            Random r = new Random();
            int x = r.Next(5);//Max range
            return "images/" + x.ToString() + ".png";
        }

    }
}

