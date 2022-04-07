using MinitwitFrontend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinitwitFrontend.Services
{
    public interface IFollowService
    {
        Task<bool> followOrUnfollow(FllwDTO followInfo, string userName);
      
    }
}

