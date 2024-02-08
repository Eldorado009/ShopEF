using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
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
        return  _dbContext.Cards.AnyAsync(c => c.Id == cardId);
    }

    public void CreateCard(int userId, string cardNumber, string cardHolderName, int cvc)
    {
        Card card = new()
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

        

        card.Created = DateTime.UtcNow;
        _dbContext.Cards.Add(card);
        _dbContext.SaveChanges();
    }

    public void DeleteCard(int cardId)
    {
        Card cardToRemove = _dbContext.Cards.FirstOrDefault(c => c.Id == cardId);
        if (cardToRemove is not null)
        {
           _dbContext.Cards.Remove(cardToRemove);
        }
        else
        {
            throw new ArgumentException("Card not found");
        }
    }
    public List<Card> GetAllCards()
    {
        var cards = _dbContext.Cards.ToList();

        if (cards.Count == 0)
        {
            new NotFoundException("No cards.");
        }

        return cards;
    }

    public async Task<decimal> GetCardBalanceAsync(int cardId)
    {
        Card card =  _dbContext.Cards.Find(cardId);
        if (card is not null)
        {
            return card.Balance;
        }
        else
        {
            throw new ArgumentException("Card not found");
        }
    }

    public void UpdateCard(int cardId, string cardNumber, string cardHolderName, int cvc)
    {
        Card cardToUpdate = _dbContext.Cards.FirstOrDefault(c => c.Id == cardId);
        if (cardToUpdate is not null)
        {
            cardToUpdate.CardNumber = cardNumber;
            cardToUpdate.CardHolderName = cardHolderName;
            cardToUpdate.Cvc = cvc;
        }
        else
        {
            throw new ArgumentException("Card not found");
        }
    }
}
