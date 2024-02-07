using EFProjectApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Shop.Business.Interface;
using Shop.Core.Entities;

namespace Shop.Business.Services;

public class BrandService : IBrandService
{
    private readonly AppDbContext _dbContext;

    public BrandService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Brand> CreateBrandAsync(string name)
    {
        var brand = new Brand
        {
            Name = name
        };
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
        return brand;
    }

    public void DelateBrandAsync(int brandId, string name)
    {
        Brand brandToDelete = _dbContext.Brands.Find(b => b.Id == brandId && b.Name == name);
        if (brandToDelete is not null)
        {
            _dbContext.Brands.Remove(brandToDelete);
            _dbContext.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Brand not found");
        }
    }

    public List<Brand> GetAllBrandsAsync()
    {
        return _dbContext.Brands.ToList();
    }

    public void UptadeBrand(int brandId, string newName)
    {
        Brand brandToUpdate = _dbContext.Brands.Find(b => b.Id == brandId);
        if (brandToUpdate != null)
        {
            brandToUpdate.Name = newName;
        }
        else
        {
            throw new ArgumentException("Brand not found");
        }
    }

}
