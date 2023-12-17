using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopping.Core.Interface;
using Shopping.Core.ViewModels;
using Shopping.Database.Context;
using Shopping.Database.Model;

namespace Shopping.Core.Service;

public class ClassificationService : IClassification
{
    string imgPath = "wwwroot/images/ProductClassification";
    private readonly DatabaseContext _context;
    public ClassificationService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<List<ProductClassification>> GetProductClassifications(bool? notShow = null)
    {
        var classification = await _context.ProductClassifications.ToListAsync();
        if (notShow != null)
        {
            return await Task.FromResult(classification.Where(c => c.NotShow == notShow).ToList());
        }
        return await Task.FromResult(classification);
    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<bool> AddClassification(ProductClassification classification, IFormFile ClsfLogo)
    {
        try
        {
            int imgCode = new Random().Next(10000, 1000000);
            string imgName = imgCode + ClsfLogo.FileName;

            if (!Directory.Exists(imgPath))
                Directory.CreateDirectory(imgPath);
            string savePath = Path.Combine(imgPath, imgName);

            using (Stream Stream = new FileStream(savePath, FileMode.Create))
            {
                await ClsfLogo.CopyToAsync(Stream);
            }

            // add product to database(products table)
            classification.GroupImg = imgName;
            await _context.ProductClassifications.AddAsync(classification);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);

        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<ProductClassification> GetProductClassification(Guid classificationId)
    {
        var classification = await _context.ProductClassifications.Include(c => c.Commodities).FirstOrDefaultAsync(c => c.Id == classificationId);
        return await Task.FromResult(classification);
    }

    public async Task<bool> EditClassification(EditClassificationViewModel viewModel)
    {
        try
        {
            ProductClassification classification = new ProductClassification()
            {
                Id = viewModel.Id,
                GroupEnName = viewModel.GroupEnName,
                GroupFaName = viewModel.GroupFaName,
                GroupImg = viewModel.GroupImg,
                GroupDes = viewModel.GroupDes,
                NotShow = viewModel.NotShow,
            };
            _context.Update(classification);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<bool> EditClassificationImg(EditClassificationViewModel viewModel, IFormFile file)
    {
        try
        {
            int imgCode = new Random().Next(10000, 1000000);
            string imgName = imgCode + file.FileName;

            if (!Directory.Exists(imgPath))
                Directory.CreateDirectory(imgPath);
            string savePath = Path.Combine(imgPath, imgName);

            using (Stream Stream = new FileStream(savePath, FileMode.Create))
            {
                await file.CopyToAsync(Stream);
            }

            viewModel.GroupImg = imgName;

            // add product to database(products table)

            ProductClassification classification = new ProductClassification()
            {
                Id = viewModel.Id,
                GroupEnName = viewModel.GroupEnName,
                GroupFaName = viewModel.GroupFaName,
                GroupImg = viewModel.GroupImg,
                GroupDes = viewModel.GroupDes,
                NotShow = viewModel.NotShow,
            };

            _context.ProductClassifications.Update(classification);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }

    }

    public async Task<bool> DeleteClassification(Guid classificationId)
    {
        try
        {
            var classification = await _context.ProductClassifications.FindAsync(classificationId);
            if (classification != null)
            {
                _context.Remove(classification);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);

        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }
}
