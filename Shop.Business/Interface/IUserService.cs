using Shop.Core.Entities;

namespace Shop.Business.Interface;

public interface IUserService
{
    Task <bool> CreateUser( string name, string surname, string username, string UserEmail, string UserPassword, string UserPhone, bool isAdmin);
    void DeleteUser(string userEmail);
    bool ActivateProfile(int UserId);
    bool DeactivateProfile(int UserId);
    bool Login(string username, string UserPassword);
    Task<bool> Register(string username, string email, string password);
    bool IsUserAdmin(string userName);
    bool UpdateProfile(string name, string newUsername, string newUserEmail, string newUserPassword, string newUserPhone);
    List <User> GetAllUsers();
}
