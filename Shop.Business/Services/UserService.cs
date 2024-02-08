using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shop.Business.Interface;
using Shop.Core.Entities;
using System;



namespace Shop.Business.Services
{
    public class UserService : IUserService
    {
        public readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void ActivateProfile(int UserId)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(UserId);
                if (user != null)
                {
                    user.isAdmin = true;
                    await _dbContext.SaveChangesAsync();
                    
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while activating the user: " + ex.Message);
            }
        }

        public void CreateUser(User user, string name, string surname, string username, string UserEmail, string UserPassword, string UserPhone, bool isAdmin)
        {
            try
            {
                user.Name = name;
                user.Surname = surname;
                user.UserName = username;
                user.Email = UserEmail;
                user.Password = UserPassword;
                user.Phone = UserPhone;
                user.isAdmin = isAdmin;

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the user: " + ex.Message);
            }
        }

        public async void DeactivateProfile(int UserId)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(UserId);
                if (user != null)
                {
                    user.isAdmin = false;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deactivating the user: " + ex.Message);
            }
        }

        public async Task<bool> DeleteUser(string userEmail)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                if (user is not null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting a user: " + ex.Message);
                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public async Task<bool> IsUserAdmin(string userName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            return user != null && user.isAdmin;
        }

        public void Login(string username, string UserPassword)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

                if (user is not null && user.Password == UserPassword)
                {
                    Console.WriteLine("Login successful. User: " + user.UserName);
                }
                else
                {
                    Console.WriteLine("Login failed. Username or password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during the login process: " + ex.Message);
            }
        }

        public void UpdateProfile(int userId, string name, string newUsername, string newUserEmail, string newUserPassword, string newUserPhone)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.UserName == newUsername);
                if (user is not null)
                {
                    user.Name = name;
                    user.UserName = newUsername;
                    user.Email = newUserEmail;
                    user.Password = newUserPassword;
                    user.Phone = newUserPhone;

                    _dbContext.SaveChanges();
                    Console.WriteLine("Profile updated. User: " + user.UserName);
                }
                else
                {
                    Console.WriteLine("Profile update failed. User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during the profile update process: " + ex.Message);
            }
        }
        public async Task<bool> Register(string username, string email, string password)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username || u.Email == email);
            if (existingUser != null)
            {
                return false;
            }

            var newUser = new User
            {
                UserName = username,
                Email = email,
                Password = password 
            };

            try
            {
                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                return false; 
            }
        }

        void IUserService.DeleteUser(string userEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(string name, string newUsername, string newUserEmail, string newUserPassword, string newUserPhone)
        {
            throw new NotImplementedException();
        }
    }
}
