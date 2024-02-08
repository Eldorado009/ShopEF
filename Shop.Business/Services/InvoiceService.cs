using EFProjectApp.DataAccess;
using Shop.Business.Interface;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;

namespace Shop.Business.Services;

public class InvoiceService : IInvoiceService
{
    private readonly AppDbContext _dbContext;
    private readonly ICardService _cardService;
    private readonly ProductInvoiceService _productInvoiceService;

    public InvoiceService(AppDbContext dbContext, ICardService cardService, ProductInvoiceService productInvoiceService)
    {
        _dbContext = dbContext;
        _cardService = cardService;
        _productInvoiceService = productInvoiceService;
    }


    public bool CreateInvoice(List<int> productInvoiceIds, int cardId, int userId)
    {
        try
        {
            var productInvoices = _dbContext.ProductInvoices.Where(pi => productInvoiceIds.Contains(pi.Id)).ToList();

            decimal totalPrice = productInvoices.Sum(pi => pi.ProductPrice);

            var card = _dbContext.Cards.Find(cardId);
            if (card == null)
            {
                 new NotFoundException($"Card not found with ID {cardId}.");
            }
            if (card.Balance < totalPrice)
            {
                throw new ArgumentException($"Insufficient funds in the card with ID {cardId}.");
            }

            var invoice = new Invoice
            {
                InvoiceDate = DateTime.UtcNow,
                UserId = userId
            };
            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();

            card.Balance -= totalPrice;
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to create invoice.", ex);
        }
    }

}
