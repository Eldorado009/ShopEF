namespace Shop.Core.Entities;

public class User : BaseEntities
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } 
    public string Password { get; set; } = null!;
    public ICollection<Wallet>? Wallets { get; set; }
    public ICollection<Invoice>? Invoices { get; set; }
}

