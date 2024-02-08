using EFProjectApp.DataAccess;
using Shop.Business.Interface;
using Shop.Core.Entities;

namespace Shop.Business.Services;

public class DiscountService : IDiscountService
{
    private readonly AppDbContext _dbContext;

    public DiscountService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public void CreateDiscount(string name, string description, decimal discountPercent, DateTime startTime, DateTime endTime)
    {
        Discount newDiscount = new Discount
        {
            Name = name,
            Description = description,
            DiscountPrecent = discountPercent,
            StartTime = startTime,
            EndTime = endTime

        };
        _dbContext.Discounts.Add(newDiscount);
    }

    public void DeleteDiscountAsync(int discountId)
    {
        Discount discauntToRemove = _dbContext.Discounts.FirstOrDefault(x => x.Id == discountId);
        if (discauntToRemove is not null) 
        {
            _dbContext.Discounts.Remove(discauntToRemove);
        }
        else
        {
            new ArgumentException("Discount not found.");
        }
    }

    public List<Discount> GetAllDiscounts()
    {
       return _dbContext.Discounts.ToList();
    }

    public void UpdateDiscountAsync(int discountId, string newName, string newDescription, decimal newDiscountPercentage, DateTime newStartDate, DateTime newEndDate)
    {
        Discount discountToUpdate = _dbContext.Discounts.FirstOrDefault(y => y.Id == discountId);
        if (discountToUpdate is not null) 
        {
            discountToUpdate.Name = newName;
            discountToUpdate.Description = newDescription;
            discountToUpdate.DiscountPrecent = newDiscountPercentage;
            discountToUpdate.StartTime = newStartDate;
            discountToUpdate.EndTime = newEndDate;
        }
        else
        {
            new ArgumentException("Discount not found.");
        }
    }
}
