using Microsoft.AspNetCore.Mvc;
using Shopping.Core.Interface;
using Shopping.Core.ViewModels;
using Shopping.Database.Model;

namespace Shopping.Areas.Admin.Controllers;

[Area("admin")]
public class BrandController : Controller
{
    IBrand _brand;
    string imgPath = "wwwroot/images/brand";

    public BrandController(IBrand brand)
    {
        _brand = brand;
    }

    public async Task<IActionResult> Index()
    {
        var brands = await _brand.GetBrands();
        return View(brands);
    }

    public async Task<IActionResult> CreateBrand()
    {
        ViewBag.BrandId = Guid.NewGuid();
        return await Task.FromResult(View());
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateBrand(Brand brand, IFormFile brandLogo)
    {
        if (ModelState.IsValid)
        {
            if (await _brand.AddBrand(brand, brandLogo))
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("BrandEnName", "خطا در ثبت برند");
        }
        ViewBag.CommodityId = Guid.NewGuid();
        return await Task.FromResult(View(brand));
    }

    public async Task<IActionResult> BrandDetails(Guid Id)//id=brandId
    {
        var brand = await _brand.GetBrand(Id);
        if (brand != null)
        {
            return await Task.FromResult(View(brand));
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> EditBrandTitel(Guid Id)//id=brandId
    {
        var brand = await _brand.GetBrand(Id);
        if (brand != null)
        {
            EditBrandViewModel viewModel = new EditBrandViewModel()
            {
                Id = brand.Id,
                BrandEnName = brand.BrandEnName,
                BrandFaName = brand.BrandFaName,
                BrandDes = brand.BrandDes,
                BrandImg = brand.BrandImg,
                NotShow = brand.NotShow,
            };
            return await Task.FromResult(View(viewModel));
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditBrandTitel(EditBrandViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _brand.EditBrand(viewModel))
            {
                return RedirectToAction(nameof(BrandDetails), new { id = viewModel.Id });
            }
            return await Task.FromResult(View(viewModel));
        }
        return await Task.FromResult(View(viewModel));
    }


    public async Task<IActionResult> EditBrandImg(Guid Id)//id=brandId
    {
        var brand = await _brand.GetBrand(Id);
        if (brand != null)
        {
            EditBrandViewModel viewModel = new EditBrandViewModel()
            {
                Id = brand.Id,
                BrandEnName = brand.BrandEnName,
                BrandFaName = brand.BrandFaName,
                BrandDes = brand.BrandDes,
                BrandImg = brand.BrandImg,
                NotShow = brand.NotShow,
            };

            var previousImg = viewModel.BrandImg;
            TempData["Img"] = previousImg.ToString();
            return await Task.FromResult(View(viewModel));
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditBrandImg(EditBrandViewModel viewModel, IFormFile BrandImg)
    {
        if (ModelState.IsValid && BrandImg != null)
        {
            if (await _brand.EditBrandImg(viewModel, BrandImg))
            {
                //for deleting previous image
                var previousimg = (TempData["Img"]).ToString();
                string ExitingFile = Path.Combine(imgPath, previousimg);
                System.IO.File.Delete(ExitingFile);
                //end deleting previous image

                return RedirectToAction(nameof(BrandDetails), new { id = viewModel.Id });
            }
            return await Task.FromResult(View(viewModel));
        }
        return await Task.FromResult(View(viewModel));
    }

    public async Task<IActionResult> Delete(Guid Id)//id==brandId
    {
        var brand = await _brand.GetBrand(Id);
        if (brand != null)
        {
            return PartialView(brand);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Brand brand)
    {
        var Previousimg = (await _brand.GetBrand(brand.Id)).BrandImg;
        if (await _brand.DeleteBrand(brand.Id))
        {
            string ExitingFile = Path.Combine(imgPath, Previousimg);
            System.IO.File.Delete(ExitingFile);

            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }
}
