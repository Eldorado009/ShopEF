using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shop.Business.Interface;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;

namespace Shop.Business.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _dbContext;

    public ProductService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> ActivateProduct(int productId)
    {
        var product = await _dbContext.Products.FindAsync(productId);
        if (product != null && product.IsDeleted)
        {
            product.IsDeleted = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public void CreateProduct(string name, string description, decimal price, int quantity , int categoryId, int brandId, int discountId)
    {
        var categoryExists = _dbContext.Categories.Any(c => c.Id == categoryId);
        if (categoryExists)
        {
            new NotFoundException($"Category ID {categoryId} not found.");
        }

        var brandExists = _dbContext.Brands.Any(b => b.Id == brandId);
        if (brandExists)
        {
            new NotFoundException($"Brand ID {brandId} not found.");
        }


        var discountExists = discountId == null || _dbContext.Discounts.Any(d => d.Id == discountId);
        if (discountExists)
        {
            new NotFoundException($"Discount ID {discountId} not found.");
        }
        try
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity,
                CategoryId = categoryId,
                BrandId = brandId,
                DiscountId = discountId
            };

            _dbContext.Products.AddAsync(product);
            _dbContext.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the product: " + ex.Message);
        }
    }


    public void DeactivateProduct(int productId)
    {
        var product = _dbContext.Products.Find(productId);
        if (product != null && !product.IsDeleted)
        {
            product.IsDeleted = true;
            _dbContext.SaveChangesAsync();
        }
    }

    public void DeleteProduct(int productId)
    {
        var productToDelete = _dbContext.Products.Find(productId);

        if (productToDelete is not null)
        {
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }
        else
        {
            new NotFoundException($"Product with ID {productId} not found.");
        }

    }
    public List<Product> GetAllProducts()
    {
        var products = _dbContext.Products.ToList();

        if (products.Count == 0)
        {
            new NotFoundException("No products found.");
        }

        return products;
    }

    public void UpdateProduct(int productId, string newName, string newDescription, decimal newPrice, int quantity, int newCategoryId, int newBrandId, int newDiscountId)
    {
        Product productToUpdate = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
        if (productToUpdate is not null) 
        {
            productToUpdate.Name = newName;
            productToUpdate.Description = newDescription;
            productToUpdate.Price = newPrice;
            productToUpdate.Quantity = quantity;
            productToUpdate.CategoryId = newCategoryId;
            productToUpdate.BrandId = newBrandId;
            productToUpdate.DiscountId = newDiscountId;
        }
        else
        {
            new ArgumentException("Product not found");
        }
    }
}
