using MInitweetApi.Models;

public interface IMessageRepository
{

    Task<IEnumerable<Message>> getPublicTimeline();
    Task<IEnumerable<Message>> getLoggedInUserTimeline(int id);
    Task<IEnumerable<Message>> GetUserTimeline(string username);
    void newMessage(string username, string message);
}