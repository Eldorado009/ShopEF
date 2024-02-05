using Shop.Core.Entities;

namespace Shop.Business.Interface;

public interface IUser
{
    void CreateUser();
    void DeleteUser();
    void ActivateProfile();
    void DeActivateProfile();
    void Login();
    void UpdateProfile();
    Task <List<User>> GetAllUsers();
}
