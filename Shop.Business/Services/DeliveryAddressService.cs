using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shop.Business.Interface;
using Shop.Core.Entities;

namespace Shop.Business.Services;

public class DeliveryAddressService : IDeliveryAddress
{
    private readonly AppDbContext _dbContext;

    public DeliveryAddressService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void CreateDeliveryAddress(string address, string postalCode, int userId)
    {
        var user = _dbContext.Users.Find(userId);
        if (user == null)
        {
            Console.WriteLine($"User with ID {userId} not found. Impossible to create delivery address.");
            return;
        }

        var existAddress = _dbContext.DeliveryAddresses.FirstOrDefault(da => da.User.Id == userId && (da.Address == address || da.PostalCode == postalCode));

        if (existAddress == null)
        {
            _dbContext.DeliveryAddresses.Add
           (
           new DeliveryAddress
           {
                Address = address,
                PostalCode = postalCode,
                User = user,
                Created = DateTime.UtcNow
           });

            _dbContext.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Delivery address created successful.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A delivery address with the same details already exists.");
            Console.ResetColor();
        }
    }
    

    public void DeleteDeliveryAddress(int deliveryAddressId)
    {
        throw new NotImplementedException();
    }

    public List<DeliveryAddress> GetAllDeliveryAddresses(int userId)
    {
        throw new NotImplementedException();
    }

    public void GetDeliveryAddressById(int deliveryAddressId)
    {
        throw new NotImplementedException();
    }

    public void UpdateDeliveryAddress(int deliveryAddressId, string newAddress, string newPostalCode)
    {
        throw new NotImplementedException();
    }
}
