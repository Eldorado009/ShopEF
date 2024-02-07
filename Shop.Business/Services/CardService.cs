using EFProjectApp.DataAccess;
using Shop.Business.Interface;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;

namespace Shop.Business.Services;

public class CardService : ICardService
{
    private readonly AppDbContext _dbContext;

    public CardService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> CardExists(int cardId)
    {
        throw new NotImplementedException();
    }

    public void CreateCard(int userId, string cardNumber, string cardHolderName, int cvc)
    {
        var card = new Card
        {
            CardNumber = cardNumber,
            CardHolderName = cardHolderName,
            Cvc = cvc
        };

        var user =  _dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            new NotFoundException("User not found.");
        }

        

        card. = DateTime.UtcNow;
        _dbContext.Cards.Add(card);
        _dbContext.SaveChanges();
    }

    public void DeleteCard(int cardId)
    {
        throw new NotImplementedException();
    }

    public List<Card> GetAllCards()
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetCardBalanceAsync(int cardId)
    {
        throw new NotImplementedException();
    }

    public void UpdateCard(int cardId, string cardNumber, string cardHolderName, int cvc)
    {
        throw new NotImplementedException();
    }
}
