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
        //var messages = _context.Message.Where(u => !u.flagged).Take(200);
        var m = from p in _context.Message.Where(u => !u.flagged).Take(200)
                join l in _context.User
                          on p.author_id equals l.user_Id into g
                from l in g.DefaultIfEmpty()
                select new Message
                {
                    text = p.text,
                    pub_date = p.pub_date,
                    flagged = p.flagged,
                    author_id = p.author_id,
                    user = new User() { email = l.email, user_Id = l.user_Id, username = l.username }
                };
        return m.ToList();
        //return messages;
    }

    public async Task<IEnumerable<Message>> GetUserTimeline(string username)
    {
        //var m =  _context.Message.Where(u => u.user.username == username).Join().ToList();
        var m = from p in _context.Message.Where(u => u.user.username == username)
                    join l in _context.User
                              on p.author_id equals l.user_Id into g
                            from l in g.DefaultIfEmpty()
                            select new Message
                            {
                                text = p.text,
                                pub_date = p.pub_date,
                                flagged = p.flagged,
                                author_id = p.author_id,
                                user = new User() { email = l.email, user_Id = l.user_Id, username = l.username}
                            };
        return m.ToList();
    }

    public bool newMessage(string username, string message)
    {
        var user = _context.User.FirstOrDefault(u => u.username == username);
        if (user == null) return false;
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
        return true;
    }
}