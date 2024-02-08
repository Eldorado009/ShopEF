using EFProjectApp.DataAccess;
using Shop.Business.Interface;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;

namespace Shop.Business.Services;

public class ProductInvoiceService : IProductInvoiceService
{
    private readonly AppDbContext _dbContext;

    public ProductInvoiceService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool CreateProductInvoice(ProductInvoices newInvoice)
    {
        try
        {
            var product =  _dbContext.Products.Find(newInvoice.ProductId);
            if (product == null)
            {
                new NotFoundException($"Product not found with ID {newInvoice.ProductId}.");
            }
            if (product.Quantity < newInvoice.ProductCount)
            {
                 new ArgumentException($"Inadequate quantity for product with ID {newInvoice.ProductId}.");
            }
            newInvoice.ProductPrice = product.Price * newInvoice.ProductCount;

            product.Quantity -= newInvoice.ProductCount;

            _dbContext.ProductInvoices.Add(newInvoice);
            _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
