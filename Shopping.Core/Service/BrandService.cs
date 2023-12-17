using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopping.Core.Interface;
using Shopping.Core.ViewModels;
using Shopping.Database.Context;
using Shopping.Database.Model;
using static System.Console;
using static System.ConsoleColor;

namespace Shopping.Core.Service;

public class BrandService : IBrand
{
    string imgPath = "wwwroot/images/brand";
    private readonly DatabaseContext _context;
    public BrandService(DatabaseContext context)
    {
        _context = context;
    }
    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<List<Brand>> GetBrands(bool? notShow = null)
    {
        var brands = await _context.Brands.ToListAsync();
        if (notShow != null)
        {
            return await Task.FromResult(brands.Where(b => b.NotShow == notShow).ToList());
        }
        return await Task.FromResult(brands);
    }

    public async Task<Brand> GetBrand(Guid brandId)
    {
        var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == brandId);
        return await Task.FromResult(brand);
    }

    public async Task<bool> AddBrand(Brand brand, IFormFile brandLogo)
    {
        try
        {
            int imgCode = new Random().Next(10000, 1000000);
            string imgName = imgCode + brandLogo.FileName;

            if (!Directory.Exists(imgPath))
                Directory.CreateDirectory(imgPath);
            string savePath = Path.Combine(imgPath, imgName);

            using (Stream Stream = new FileStream(savePath, FileMode.Create))
            {
                await brandLogo.CopyToAsync(Stream);
            }

            // add product to database(products table)
            brand.BrandImg = imgName;
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(true);
            //throw;
        }
    }


    public async Task<bool> EditBrand(EditBrandViewModel viewModel)
    {
        try
        {
            Brand brand = new Brand()
            {
                Id = viewModel.Id,
                BrandEnName = viewModel.BrandEnName,
                BrandFaName = viewModel.BrandFaName,
                BrandDes = viewModel.BrandDes,
                BrandImg = viewModel.BrandImg,
                NotShow = viewModel.NotShow,
            };

            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }

    }

    public async Task<bool> EditBrandImg(EditBrandViewModel viewModel, IFormFile file)
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

            viewModel.BrandImg = imgName;

            // add product to database(products table)

            Brand brand = new Brand()
            {
                Id = viewModel.Id,
                BrandEnName = viewModel.BrandEnName,
                BrandFaName = viewModel.BrandFaName,
                BrandDes = viewModel.BrandDes,
                BrandImg = viewModel.BrandImg,
                NotShow = viewModel.NotShow,
            };

            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(true);
            //throw;
        }
    }

    public async Task<bool> DeleteBrand(Guid brandId)
    {
        try
        {
            var brand = await _context.Brands.FindAsync(brandId);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
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
