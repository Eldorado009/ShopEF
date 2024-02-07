namespace Shop.Core.Entities;

public class User : BaseEntities
{

    public User(string? name, string userName, string password, string email, string? phone, bool isAdmin)
    {
        Name = name;
        UserName = userName;
        Password = password;
        Email = email;
        Phone = phone;
        isAdmin = isAdmin;

        DeliveryAddresses = new List<DeliveryAddress>();
        Wallets = new List<Wallet>();
        Invoices = new List<Invoice>();
    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string UserName { get; set; }
    public string Email { get; set; } = null!;
    public string Phone { get; set; } 
    public string Password { get; set; } = null!;
    public bool isAdmin { get; set; } = false;
    public Basket Basket { get; set; }
    public ICollection<DeliveryAddress>? DeliveryAddresses { get; set; }
    public ICollection<Wallet>? Wallets { get; set; }
    public ICollection<Invoice>? Invoices { get; set; }
}

