using MInitweetApi.Models;
using static MInitweetApi.Controllers.UsersController;

public interface IUserRepository{
    bool Follow(string username, string follow);
    bool Unfollow(string username, string unfollow);
    bool registerUser(Userdto user);
    int login(User user);
    string getUsername(int id);
}