namespace Shop.Core.Entities;

public class BasketProduct
{
    public int Id { get; set; }
    public int ProductQuantity { get; set; }
    public int BasketId { get; set; }
    public int ProductId { get; set; }
}
