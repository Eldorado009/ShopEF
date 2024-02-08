using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shop.Business.Interface;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using System;

namespace Shop.Business.Services;

public class BasketService : IBasketService
{
    private readonly AppDbContext _dbContext;
    private readonly IProductService _productService;

    public BasketService(AppDbContext dbContext, IProductService productService)
    {
        _dbContext = dbContext;
        _productService = productService;
    }

    public async Task<Basket> AddToBasketAsync(int userId, int productId, int quantity)
    {

        var basketItem = new Basket
        {
            UserId = userId,
            ProductId = productId,
            Quantity = quantity
        };

        await _dbContext.Baskets.AddAsync(basketItem);
        await _dbContext.SaveChangesAsync();

        return basketItem;
    }

    public async Task UpdateBasketItemAsync(int basketItemId, int quantity)
    {
        var basketItem = (basketItemId);

        if (basketItem != null)
        {
            ValidateQuantity(quantity);

            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task<decimal> CalculateTotalAsync(int userId)
    {
        await AuthenticateUserAsync(userId);

        var basketItems = await _dbContext.Baskets
            .Include(b => b.Product)
            .Where(b => b.UserId == userId)
            .ToListAsync();

        return basketItems.Sum(b => b.Quantity * (b.Product?.Price ?? 0));
    }

    private void ValidateQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be a positive integer.");
        }
    }

    private async Task AuthenticateUserAsync(int userId)
    {
        var authenticatedUser = await _dbContext.Users.FindAsync(userId);

        if (authenticatedUser == null)
        {
            throw new UnauthorizedAccessException("User authentication failed.");
        }
    }

    public Task RemoveFromBasketAsync(int basketItemId)
    {
        throw new NotImplementedException();
    }
}
