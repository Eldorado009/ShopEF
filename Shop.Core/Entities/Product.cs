﻿namespace Shop.Core.Entities;

public class Product: BaseEntities
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public decimal Price { get; set; } = 0;
}
