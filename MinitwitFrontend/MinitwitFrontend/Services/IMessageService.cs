using MinitwitFrontend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinitwitFrontend.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllPublicTwits();
        Task<IEnumerable<Message>> GetAllPrivateTwits(string userName);
        Task<bool> CreateATwit(Stringwrapper twit, string userName);
    }
}

