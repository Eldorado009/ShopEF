using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shop.Business.Interface;
using Shop.Core.Entities;
using System;

namespace Shop.Business.Services;

public class BasketService : IBasketService
{
    private readonly AppDbContext _dbContext;
    private readonly IProductService _productService;

    
    public void AddToBasket(int userId, int ProductId)
    {
        try
        {
            var basket = _dbContext.Baskets.FirstOrDefault(b => b.UserId == userId);
            if (basket == null)
            {
                basket = new Basket { UserId = userId };
                _dbContext.Baskets.Add(basket);
            }
            basket.Products.Add( new Product { Id = ProductId} );

            _dbContext.SaveChanges();
            Console.WriteLine("The product added in basket.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while adding the product to the basket: " + ex.Message);
        }
    }

    public void ClearBasket(int basketId)
    {
        try
        {
            var basket = _dbContext.Baskets.Include(b => b.Products).FirstOrDefault(b => b.Id == basketId);

            if (basket == null || basket.Products.Any())
            {
                Console.WriteLine("The basket is already empty.");
                return;
            }

            basket.Products.Clear();

            _dbContext.SaveChanges();
            Console.WriteLine("The basket has been cleared.\r\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while clearing the basket: " + ex.Message);
        }
    }

    public void RemoveFromBasket(int basketId)
    {
        try
        {
            var basket = _dbContext.Baskets.Include(b => b.Products).FirstOrDefault(b => b.Id == basketId);
            var itemToRemove = basket.Products.FirstOrDefault(item => item.Id == basketId);

            if (basket == null || itemToRemove == null)
            {
                Console.WriteLine("The product is not in your Basket.");
                return;
            }
            basket.Products.Remove(itemToRemove);

            _dbContext.SaveChanges();
            Console.WriteLine("The product has been removed from the basket.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while removing the rune from the basket: " + ex.Message);
        }
    }
}
