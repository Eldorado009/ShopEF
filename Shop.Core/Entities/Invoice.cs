namespace Shop.Core.Entities;

public class Invoice:BaseEntities
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; } = 0;
    public string? PaymentMethod { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
    public int? UserId { get; set; }
    public int? WalletId { get; set; }
}
