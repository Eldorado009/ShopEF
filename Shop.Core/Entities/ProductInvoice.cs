namespace Shop.Core.Entities;

public class ProductInvoice
{
    public int Id { get; set; }
    public int ProductCount { get; set; }
    public decimal ProductPrice { get; set; } = 0;
    public int DiscountApplied { get; set; } 
    public int ProductId { get; set; }
    public int InvoiceId { get; set; }

}
