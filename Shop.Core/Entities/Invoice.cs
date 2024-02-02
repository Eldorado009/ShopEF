namespace Shop.Core.Entities;

public class Invoice:BaseEntities
{
    public int Id { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
}
