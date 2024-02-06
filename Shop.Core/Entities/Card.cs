namespace Shop.Core.Entities;

public class Card
{
    public int Id { get; set; }
    public string? CardNumber { get; set; } = null!;
    public string? CardHolderName { get; set; } = null!;
    public int Cvc { get; set; }
    public decimal Balance { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
}
