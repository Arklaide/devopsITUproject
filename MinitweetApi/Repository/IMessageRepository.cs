using MInitweetApi.Models;

public interface IMessageRepository
{

    IEnumerable<Message> getPublicTimeline();
    IEnumerable<Message> getLoggedInUserTimeline(int id);
    IEnumerable<Message> GetUserTimeline(string username);
    void newMessage(string username, string message);
}