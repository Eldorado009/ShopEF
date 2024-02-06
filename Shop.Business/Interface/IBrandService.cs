using Shop.Core.Entities;

namespace Shop.Business.Interface;

public interface IBrandService
{
    void CreateBrand(string name);
    void UptadeBrand(int brandId, string newName);
    void DelateBrand(int brandId, string name);
    List<Brand> GetAllBrands();
}
