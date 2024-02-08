namespace Shop.Core.Entities;

public class DeliveryAddress : BaseEntities
{
    public int Id { get; set; }
    public string Address { get; set; } = null!;
    public string? PostalCode { get; set; }
    public User User { get; set; } = new User();
    public int? UserId { get; set; }


}
