using MInitweetApi.Models;

public class MessageRepository : IMessageRepository
{
    private readonly DatabaseContext _context;

    public MessageRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async 
        Task<IEnumerable<Message>> getLoggedInUserTimeline(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Message>> getPublicTimeline()
    {
        var messages = _context.Message.Where(u => !u.flagged);
        return messages;
    }

    public async Task<IEnumerable<Message>> GetUserTimeline(string username)
    {
        var m =  _context.Message.Where(u => u.user.username == username).ToList();
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
            pub_date = DateTime.UtcNow
        };
        _context.Message.Add(msg);
        _context.SaveChanges();
    }
}