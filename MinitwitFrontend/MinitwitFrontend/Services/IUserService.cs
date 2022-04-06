using MinitwitFrontend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinitwitFrontend.Services
{
    public interface IUserService
    {
        Task<string> RegisterUser(Userdto user);
        Task<Userdto> LoginUser(string username);
    }
}

