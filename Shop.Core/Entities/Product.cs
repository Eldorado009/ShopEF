namespace Shop.Core.Entities;

public class Product: BaseEntities
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public decimal Price { get; set; } = 0;
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public int DiscountId { get; set; }
}
