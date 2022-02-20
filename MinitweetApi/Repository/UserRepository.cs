using MInitweetApi.Models;

public class UserRepository : IUserRepository
{

    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public int login(User user)
    {
        var current = _context.User.Where(u => u.username == user.username).FirstOrDefault();
        if (current == null) throw new Exception();
        return current.user_Id;
    }

    public int registerUser(User user)
    {
        var current = _context.User.Where(u => u.username == user.username);
        var newuser = new User
        {
            username = user.username,
            email = user.email,
            pw_hash = user.pw_hash
        };
        _context.User.Add(newuser);
        return newuser.user_Id;
    }

    public void unfollow(string username, string unfollow)
    {
        var currentuser = _context.User.Where(u => u.username == username).FirstOrDefault();
        var follower = _context.User.Where(u => u.username == unfollow).FirstOrDefault();

        var followers = _context.Follower.FirstOrDefault(u => u.whom_user.username == username && u.whom_user.username == unfollow);
        _ = _context.Follower.Remove(followers);
        _context.SaveChanges();
    }

    public void follows(string username, string follow)
    {
        var currentuser = _context.User.Where(u => u.username == username).FirstOrDefault();
        if (currentuser == null)
        {
            throw new Exception();
        }
        var follower = _context.User.Where(u => u.username == follow).FirstOrDefault();
        var newf = new Follower { who_user = currentuser, whom_user = follower };
        _context.Add(follower);
        _context.SaveChanges();
    }
}