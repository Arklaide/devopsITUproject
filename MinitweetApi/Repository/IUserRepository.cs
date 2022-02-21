using MInitweetApi.Models;

public interface IUserRepository{
    void Follow(string username, string follow);
    void Unfollow(string username, string unfollow);
    int registerUser(User user);
    int login(User user);
    string getUsername(int id);
}