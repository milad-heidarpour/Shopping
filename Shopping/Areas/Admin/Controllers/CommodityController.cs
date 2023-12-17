using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Core.Interface;
using Shopping.Database.Model;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Shopping.Areas.Admin.Controllers;

[Area("Admin")]
public class CommodityController : Controller
{
    string imgPath = "wwwroot/images/commodity";
    ICommodity _commodity;
    IBrand _brand;
    IClassification _classification;
    public CommodityController(ICommodity commodity, IBrand brand, IClassification classification)
    {
        _commodity = commodity;
        _brand = brand;
        _classification = classification;
    }
    public async Task<IActionResult> Index()
    {
        var commodities = await _commodity.GetCommodities(/*ClassificationId:Guid.Empty,*/);
        return View(commodities);
    }


    public async Task<IActionResult> Create()
    {
        ViewBag.BrandCount = (await _brand.GetBrands()).Count();
        ViewBag.ClassificationCount = (await _classification.GetProductClassifications()).Count();
        ViewBag.BrandId = new SelectList(await _brand.GetBrands(), "Id", "BrandEnName");
        ViewBag.ClassificationId = new SelectList(await _classification.GetProductClassifications(), "Id", "GroupEnName");
        ViewBag.CommodityId = Guid.NewGuid();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Commodity commodity)
    {
        if (ModelState.IsValid)
        {
            if (await _commodity.AddCommodity(commodity))
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("ProductFaName", "خطا در ثبت محصول");
        }
        ViewBag.BrandId = new SelectList(await _brand.GetBrands(), "Id", "BrandEnName");
        ViewBag.ClassificationId = new SelectList(await _classification.GetProductClassifications(), "Id", "GroupEnName");
        ViewBag.CommodityId = Guid.NewGuid();
        ViewBag.BrandCount = (await _brand.GetBrands()).Count();
        return View(commodity);
    }




    public async Task<IActionResult> AddCommodityAlbum(Guid Id)
    {
        ViewBag.Message = TempData["Message"];
        var commodity = await _commodity.GetCommodity(Id);

        var commodityAlbum = await _commodity.GetCommodityAlbums(commodity.Id);
        if (commodityAlbum != null)
        {
            ViewBag.Album = commodityAlbum;
        }
        ViewBag.Commodity = commodity;
        ViewBag.CommodityId = commodity.Id;
        ViewBag.Id = Guid.NewGuid();
        TempData["CommodityId"] = Id;
        return await Task.FromResult(View());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddCommodityAlbum(CommodityAlbum album, IFormFile CommodityImg)
    {
        if (ModelState.IsValid)
        {
            if (await _commodity.AddAlbum(album, CommodityImg))
            {
                return RedirectToAction(nameof(AddCommodityAlbum), new { id = album.CommodityId });
            }
            ModelState.AddModelError("CommodityImg", "خطا در ثبت محصول");
        }

        TempData["Message"] = "دوباره امتحان کنید";
        return RedirectToAction(nameof(AddCommodityAlbum), new { id = album.CommodityId});

        //ModelState.AddModelError("CommodityImg", "خطا در ثبت محصول");
        //ViewBag.Album = await _commodity.GetCommodityAlbums(album.CommodityId);
        //ViewBag.Id = Guid.NewGuid();

    }

    public async Task<IActionResult> RemoveCommodityAlbum(Guid Id)
    {
        var commodity = await _commodity.GetCommodityAlbum(Id);
        if (commodity == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return PartialView(commodity);

    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveCommodityAlbum(CommodityAlbum commodityAlbum)
    {
        var previousimg = (await _commodity.GetCommodityAlbum(commodityAlbum.Id)).CommodityImg;
        if (await _commodity.DeleteCommodityAlbum(commodityAlbum.Id))
        {
            string ExitingFile = Path.Combine(imgPath, previousimg);
            System.IO.File.Delete(ExitingFile);

            return RedirectToAction(nameof(AddCommodityAlbum), new { id = TempData["CommodityId"] });
        }
        return RedirectToAction(nameof(AddCommodityAlbum), new { id = TempData["CommodityId"] });
    }


    public async Task<IActionResult> CommodityDetails(Guid Id) //id==commodityId
    {
        var commodity = await _commodity.GetCommodity(Id);
        if (commodity == null)
        {
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Album = await _commodity.GetCommodityAlbums(Id);
        return await Task.FromResult(View(commodity));
    }


    public async Task<IActionResult> RemoveCommodity(Guid Id)
    {
        var commodity = await _commodity.GetCommodity(Id);
        ViewBag.CommodityAlbum = (await _commodity.GetCommodityAlbums(Id)).Take(4);
        if (commodity != null)
        {
            return PartialView(commodity);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveCommodity(Commodity commodity)
    {
        var commoDetails = await _commodity.GetCommodity(commodity.Id);
        if (commoDetails != null)
        {
            if (await _commodity.DeleteCommodity(commodity.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            return await Task.FromResult(View(commoDetails));
        }
        return await Task.FromResult(View(commoDetails));
    }

    public async Task<IActionResult> EditCommodity(Guid Id)//id==commodityId
    {
        var commodity = await _commodity.GetCommodity(Id);
        ViewBag.BrandId = new SelectList(await _brand.GetBrands(), "Id", "BrandEnName");
        ViewBag.ClassificationId = new SelectList(await _classification.GetProductClassifications(), "Id", "GroupEnName");
        if (commodity != null)
        {
            return await Task.FromResult(View(commodity));
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCommodity(Commodity commodity)
    {

        if (ModelState.IsValid)
        {
            if (await _commodity.EditCommodity(commodity))
            {
                return RedirectToAction(nameof(CommodityDetails), new { Id = commodity.Id });
            }
            ViewBag.BrandId = new SelectList(await _brand.GetBrands(), "Id", "BrandEnName");
            ViewBag.ClassificationId = new SelectList(await _classification.GetProductClassifications(), "Id", "GroupEnName");
            return await Task.FromResult(View(commodity));
        }
        ViewBag.BrandId = new SelectList(await _brand.GetBrands(), "Id", "BrandEnName");
        ViewBag.ClassificationId = new SelectList(await _classification.GetProductClassifications(), "Id", "GroupEnName");
        return await Task.FromResult(View(commodity));
    }
}
