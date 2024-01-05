using Microsoft.AspNetCore.Http;
using Shopping.Core.ViewModels;
using Shopping.Database.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Shopping.Core.Interface;

public interface IBrand:IDisposable
{
    Task<List<Brand>> GetBrands(bool? notShow=null);
    Task<Brand> GetBrand(Guid brandId);
    Task<bool> AddBrand(Brand brand,IFormFile brandLogo);
    Task<bool> EditBrand(EditBrandViewModel brand, IFormFile? BrandImg);
    Task<bool> DeleteBrand(Guid brandId);

    //Task<bool> EditBrandImg (EditBrandViewModel viewModel, IFormFile file);
    //Task<bool>EditBrand(EditBrandViewModel viewModel);
}
