using Shop.Core.Entities;

namespace Shop.Business.Interface;

public interface IProductService
{
    List<Product> GetAllProducts();
    void CreateProduct(string name, string description, decimal price, int Quantity, int categoryId, int brandId, int discountId);
    bool UpdateProduct(int productId, string newName, string newDescription, decimal newPrice, int Quantity, int newCategoryId, int newBrandId, int newDiscountId);
    bool DeleteProduct(int productId);
    Task<bool> ActivateProduct(int productId);
    bool DeactivateProduct(int productId);
}
