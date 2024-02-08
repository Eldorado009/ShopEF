using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shop.Business.Interface;
using Shop.Core.Entities;

namespace Shop.Business.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _dbContext;
    public CategoryService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void CreateCategory(string name)
    {
        var category = new Category
        {
            Name = name
        };

        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }
    public void DeleteCategory(int categoryId)
    {
        Category categoryToRemove = _dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
        if (categoryToRemove != null)
        {
            _dbContext.Categories.Remove(categoryToRemove);
        }
        else
        {
            throw new ArgumentException("Category not found");
        }
    }

    public List<Category> GetAllCategories()
    {
        return _dbContext.Categories.ToList();
    }

    public void UpdateCategory(int categoryId, string newName)
    {
        Category categoryToUpdate = _dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
        if (categoryToUpdate is not null)
        {
            categoryToUpdate.Name = newName;
        }
        else
        {
            throw new ArgumentException("Category not found");
        }
    }
}
