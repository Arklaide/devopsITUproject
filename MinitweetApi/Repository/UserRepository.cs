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

    public bool Unfollow(string username, string unfollow)
    {
        var currentuser = _context.User.FirstOrDefault(u => u.username == username);
        var follower = _context.User.FirstOrDefault(u => u.username == unfollow);

        Follower? follow = _context.Follower.FirstOrDefault(u => u.who_user.username == username && u.whom_user.username == unfollow);
        if (follow != null)
        {
            _context.Follower.Remove(follow);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool Follow(string username, string follow)
    {
        var currentuser = _context.User.Where(u => u.username == username).FirstOrDefault();
        if (currentuser == null)
        {
            Console.WriteLine("could not find " + username);
            return false;
        }
        var whom_user = _context.User.FirstOrDefault(u => u.username == follow);
        if (whom_user == null) return false;
        var follower = new Follower { who_user = currentuser, whom_user = whom_user };
        _context.Add(follower);
        _context.SaveChanges();
        return true;
    }

    public string getUsername(int id)
    {
        return _context.User.Where(u => u.user_Id == id).FirstOrDefault().username;
    }
}