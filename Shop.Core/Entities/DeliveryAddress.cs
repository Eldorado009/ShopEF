namespace Shop.Core.Entities;

public class DeliveryAddress : BaseEntities
{
    public int Id { get; set; }
    public string Address { get; set; } = null!;
    public string? PostalCode { get; set; } 
    public int? UserId { get; set; }

}
