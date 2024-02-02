using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Shop.Core.Entities;

public class Wallet:BaseEntities
{
    public int Id { get; set; }
    public string CardName { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public decimal Balance { get; set; } = 0;
    public string UserId  { get; set; }
    public ICollection<Invoice>? Invoices { get; set; }
}
