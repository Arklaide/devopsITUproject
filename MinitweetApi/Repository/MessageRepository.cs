using MInitweetApi.Models;

public class MessageRepository : IMessageRepository
{
    private readonly DatabaseContext _context;

    public IEnumerable<Message> getLoggedInUserTimeline(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Message> getPublicTimeline()
    {
        var messages = _context.Message.Where(u => !u.flagged);
        return messages;
    }

    public IEnumerable<Message> GetUserTimeline(string username)
    {
        var m = _context.Message.Where(u => u.user.username == username).ToList();
        return m;
    }

    public void newMessage(string username, string message)
    {
        var user = _context.User.FirstOrDefault(u => u.username == username);
        if (user == null) throw new Exception();
        var msg = new Message
        {
            user = user,
            author_id = user.user_Id,
            flagged = false,
            text = message,
            pub_date = DateTime.Now
        };
        _context.Message.Add(msg);
        _context.SaveChanges();
    }
}