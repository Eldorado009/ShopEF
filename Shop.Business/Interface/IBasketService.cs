using Shop.Core.Entities;

namespace Shop.Business.Interface;

public interface IBasketService
{
    Task<Basket> AddToBasketAsync(int userId, int productId, int quantity);
    Task UpdateBasketItemAsync(int basketItemId, int quantity);
    Task RemoveFromBasketAsync(int basketItemId);
    Task<decimal> CalculateTotalAsync(int userId);
}
