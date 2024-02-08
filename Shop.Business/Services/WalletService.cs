using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shop.Business.Interface;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using System;

namespace Shop.Business.Services;

public class WalletService : IWalletService
{
    private readonly AppDbContext _dbContext;
    private readonly ICardService _cardService;

    public WalletService(AppDbContext dbContext, ICardService cardService)
    {
        _dbContext = dbContext;
        _cardService = cardService;
    }
    public bool CreateWallet(Wallet newWallet, int userId)
    {
        try
        {
            var NewWallet = new Wallet
            {
                UserId = userId
            };
            _dbContext.Wallets.Add(newWallet);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while adding the product to the wallet: " + ex.Message);
            return false;
        }
    }

    public bool DeleteWallet(int walletId)
    {
        Wallet walletToRemove = _dbContext.Wallets.FirstOrDefault(w => w.Id == walletId);
        if (walletToRemove is not null)
        {
            _dbContext.Wallets.Remove(walletToRemove);
            return true;
        }
        else
        {
            return false; 
        }
    }

    public List<Wallet> GetAllWallets()
    {
        return _dbContext.Wallets.ToList();
    }

    public decimal GetWalletBalance(int userId)
    {
        Wallet userWallet = _dbContext.Wallets.FirstOrDefault(w => w.UserId == userId);
        if (userWallet is not null)
        {
            return userWallet.Balance;
        }
        else
        {
            throw new ArgumentException("Wallet not found for user");
        }
    }

    public void IncreaseWalletBalance(int walletId, int cardId, decimal amount)
    {
        try
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.Id == walletId);
            if (wallet == null)
            {
                 new NotFoundException($"Wallet not found ID {walletId}.");
            }
            var card =  _dbContext.Cards.FirstOrDefault(c => c.Id == cardId);
            if (card == null)
            {
                new NotFoundException($"Card not found ID {cardId}.");
            }
            if (card.Balance < amount)
            {
                Console.WriteLine($"Insufficient funds on the ID card {cardId}.");
            }
            card.Balance -= amount;
            wallet.Balance += amount;
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to increase wallet balance.", ex);
        }
    }

    public bool UpdateWallet(int walletId, int userId)
    {
        Wallet walletToUpdate = _dbContext.Wallets.FirstOrDefault(w => w.Id == walletId);
        if (walletToUpdate != null)
        {
            walletToUpdate.UserId = userId;
            return true;
        }
        else
        {
            return false; 
        }
    }
}
