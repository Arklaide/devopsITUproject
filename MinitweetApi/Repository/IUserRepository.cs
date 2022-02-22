using MInitweetApi.Models;

public interface IUserRepository{
    bool Follow(string username, string follow);
    bool Unfollow(string username, string unfollow);
    int registerUser(User user);
    int login(User user);
    string getUsername(int id);
}