using Microsoft.AspNetCore.Http;
using Shopping.Core.ViewModels;
using Shopping.Database.Model;

namespace Shopping.Core.Interface;

public interface IClassification : IDisposable
{
    Task<List<ProductClassification>> GetProductClassifications(bool? notShow = null);
    Task<bool> AddClassification(ProductClassification classification, IFormFile ClsfLogo);
    Task<ProductClassification> GetProductClassification(Guid classificationId);
    Task<bool> EditClassification(EditClassificationViewModel classification, IFormFile? ClassificationImg);
    Task<bool> DeleteClassification(Guid classificationId);

    //Task<bool> EditClassificationImg(EditClassificationViewModel viewModel, IFormFile file);
    //Task<bool> EditClassification(EditClassificationViewModel viewModel);
}
