namespace Shop.Core.Entities;

public class User : BaseEntities
{

    public int Id { get; set; }
    public string? Surname { get; set; }
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; } 
    public string? Phone { get; set; } 
    public string? Password { get; set; } 
    public bool isAdmin { get; set; } = false;
    public ICollection<DeliveryAddress>? DeliveryAddresses { get; set; }
    public ICollection<Wallet>? Wallets { get; set; }
    public ICollection<Invoice>? Invoices { get; set; }
    public ICollection<Basket>? Baskets { get; set; }
    public ICollection<Card>? Cards { get; set; }
}

