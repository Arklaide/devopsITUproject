using MInitweetApi.Models;

public interface IUserRepository{
    void follows(string username, string follow);
    void unfollow(string username, string unfollow);
    int registerUser(User user);
    int login(User user);
    string getUsername(int id);
}