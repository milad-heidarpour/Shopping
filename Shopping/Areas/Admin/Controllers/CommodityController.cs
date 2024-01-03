using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Core.Interface;
using Shopping.Core.ViewModels;
using Shopping.Database.Model;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Shopping.Areas.Admin.Controllers;

[Area("Admin")]
public class CommodityController : Controller
{
    string imgPath = "wwwroot/Images/Commodity";
    ICommodity _commodity;
    IBrand _brand;
    IClassification _classification;
    IFeature _feature;
    public CommodityController(ICommodity commodity, IBrand brand, IClassification classification,IFeature feature)
    {
        _commodity = commodity;
        _brand = brand;
        _classification = classification;
        _feature = feature;
    }
    public async Task<IActionResult> Index()
    {
        var commodities = (await _commodity.GetCommodities(/*ClassificationId:Guid.Empty,*/)).OrderBy(f=>f.RegisterDate);
        return View(commodities);
    }
    //public async Task<IActionResult> GetCommodities()
    //{
    //    //var Id1 = TempData["Id1"];
    //    //var Id2 = TempData["Id2"];
    //    //var Id3 = TempData["Id3"];
    //    //var Id4 = TempData["Id4"];
    //    var commodities = await _commodity.GetCommodities(/*ClassificationId:Guid.Empty,*/);

    //    CompareViewModel compareView = new CompareViewModel()
    //    {
    //        Commodities = commodities,
    //    };


    //    return await Task.FromResult( View(commodities));
    //}


    public async Task<IActionResult> AddNewCommodity()
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
    public async Task<IActionResult> AddNewCommodity(Commodity commodity)
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
        return RedirectToAction(nameof(AddCommodityAlbum), new { id = album.CommodityId });

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


    public async Task<IActionResult> DeleteCommodity(Guid Id)
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
    public async Task<IActionResult> DeleteCommodity(Commodity commodity)
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

    public async Task<IActionResult> CompareCommodities(Guid Id1, Guid? Id2, Guid? Id3, Guid? Id4, Guid? DeleteId)
    {

        var commodity1 = await _commodity.GetCommodity(Id1);
        var commodity2 = await _commodity.GetCommodity(Id2);
        var commodity3 = await _commodity.GetCommodity(Id3);
        var commodity4 = await _commodity.GetCommodity(Id4);

        TempData["Id1"] = Id1;
        TempData["Id2"] = Id2;
        TempData["Id3"] = Id3;
        TempData["Id4"] = Id4;

        if (DeleteId != null)
        {
            if (Id2 == DeleteId)
            {
                Id2 = null;
                TempData["Id1"] = Id1;
                TempData["Id2"] = Id2;
                TempData["Id3"] = Id3;
                TempData["Id4"] = Id4;
                var _Commodities = await _commodity.NoDupCommodities(DupId1: Id1, DupId2: Id2, DupId3: Id3, DupId4: Id4, notShow: false);
                CompareViewModel CompareDelete = new CompareViewModel()
                {
                    Commodity1 = commodity1,
                    Commodity2 = null,
                    Commodity3 = commodity3,
                    Commodity4 = commodity4,
                    Commodities = _Commodities,
                };
                return await Task.FromResult(View(CompareDelete));
            }
            else if (Id3 == DeleteId)
            {
                Id3 = null;
                TempData["Id1"] = Id1;
                TempData["Id2"] = Id2;
                TempData["Id3"] = Id3;
                TempData["Id4"] = Id4;
                var _Commodities = await _commodity.NoDupCommodities(DupId1: Id1, DupId2: Id2, DupId3: Id3, DupId4: Id4, notShow: false);
                CompareViewModel CompareDelete = new CompareViewModel()
                {
                    Commodity1 = commodity1,
                    Commodity2 = commodity2,
                    Commodity3 = null,
                    Commodity4 = commodity4,
                    Commodities = _Commodities
                };
                return await Task.FromResult(View(CompareDelete));
            }
            else if (Id4 == DeleteId)
            {
                Id4 = null;
                TempData["Id1"] = Id1;
                TempData["Id2"] = Id2;
                TempData["Id3"] = Id3;
                TempData["Id4"] = Id4;
                var _Commodities = await _commodity.NoDupCommodities(DupId1: Id1, DupId2: Id2, DupId3: Id3, DupId4: Id4, notShow: false);
                CompareViewModel CompareDelete = new CompareViewModel()
                {
                    Commodity1 = commodity1,
                    Commodity2 = commodity2,
                    Commodity3 = commodity3,
                    Commodity4 = null,
                    Commodities = _Commodities
                };
                return await Task.FromResult(View(CompareDelete));
            }
        }
        var Commodities = await _commodity.NoDupCommodities(DupId1: Id1, DupId2: Id2, DupId3: Id3, DupId4: Id4, notShow: false);
        CompareViewModel compareView = new CompareViewModel()
        {
            Commodity1 = commodity1,
            Commodity2 = commodity2,
            Commodity3 = commodity3,
            Commodity4 = commodity4,
            Commodities = Commodities
        };

        return await Task.FromResult(View(compareView));
    }

    public async Task<List<FeatureGroup>> GetFeatureGroup()
    {
        var featureGroups = await _feature.GetFeatureGroups();
        return featureGroups;
    }

    public async Task<IActionResult> CreateCommodityFeature(Guid CommodityId)
    {
        var commodity = await _commodity.GetCommodity(CommodityId);
        var commodityAlbum = await _commodity.GetCommodityAlbums(commodity.Id);
        if (commodityAlbum != null)
        {
            ViewBag.Album = commodityAlbum;
        }
        var featureGroups = await _feature.GetFeatureGroups();
        var featureSections=await _feature.GetFeatureSections();
        var features=await _feature.GetFeatures();
        ViewBag.Commodity = commodity;
        ViewBag.Id=Guid.NewGuid();
        ViewBag.FeatureGroups = new SelectList(await _feature.GetFeatureGroups(), "Id", "GroupName");
        ViewBag.FeatureSections = new SelectList(await _feature.GetFeatureSections(), "Id", "SectionName");
        ViewBag.FeatureId = new SelectList(await _feature.GetFeatures(), "Id", "Title");
        return await Task.FromResult(View());

    }

    //public async Task<IActionResult> CompareCommodities(Guid ? FId, Guid? SId)//Id==Commodityid
    //{
    //    //for (int i = 0; i < Id.Count(); i++)
    //    //{
    //    //    var commodity = await _commodity.GetCommodity(Id[i]);
    //    //    List<Commodity> commodities = new List<Commodity>() { commodity };
    //    //    ViewBag.Commodities = commodities;
    //    //    TempData["FId"] = commodity.Id;
    //    //}

    //    if (FId!=null)
    //    {
    //        TempData["FId"] = FId;
    //        var commodity1 = await _commodity.GetCommodity(FId);
    //        ViewBag.CommodityFirst = commodity1;

    //    }
    //    if (SId != null)
    //    {
    //        TempData["SId"] = SId;
    //        var commodity2 = await _commodity.GetCommodity(SId);
    //        ViewBag.CommoditySecond = commodity2;
    //    }

    //    return await Task.FromResult(View());
    //}




    //public async Task<IActionResult> CompareCommodityTwo(Guid SId)//Id==Commodityid
    //{

    //    var commodity2 = await _commodity.GetCommodity(SId);
    //    ViewBag.CommoditySecond = commodity2;

    //    return View(commodity2);
    //}
    //public async Task<IActionResult> CompareCommodityOne(Guid Id)//Id==Commodityid
    //{
    //    var commodity=await _commodity.GetCommodity(Id);
    //    ViewBag.CommodityFirst= commodity;
    //    TempData["Commodity1"]= commodity;
    //    return View();
    //}
    //public async Task<IActionResult> CompareCommodityTwo(Guid Id)//Id==Commodityid
    //{
    //    var commodity = await _commodity.GetCommodity(Id);
    //    ViewBag.CommoditySecond = commodity;
    //    TempData["Commodity2"] = commodity;
    //    return RedirectToAction(nameof(CompareCommodities));
    //}
}
