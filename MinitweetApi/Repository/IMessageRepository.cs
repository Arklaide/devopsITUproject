using MInitweetApi.Models;

public interface IMessageRepository
{

    Task<IEnumerable<Message>> getPublicTimeline();
    Task<IEnumerable<Message>> getLoggedInUserTimeline(int id);
    Task<IEnumerable<Message>> GetUserTimeline(string username);
    bool newMessage(string username, string message);
}