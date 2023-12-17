using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Core.Interface;
using Shopping.Database.Model;

namespace Shopping.Areas.Admin.Controllers;

[Area("Admin")]
public class FeatureController : Controller
{
    IFeature _feature;
    public FeatureController(IFeature feature)
    {
        _feature = feature;
    }
    public async Task<IActionResult> Index()
    {
        #region GetAllFeatures
        ViewBag.FeatureGroups = (await _feature.GetFeatureGroups()).OrderBy(f => f.GroupName);
        //ViewBag.FeatureSections = (await _feature.GetFeatureSections()).OrderBy(f => f.FeatureGroup.GroupName);
        //ViewBag.Features = (await _feature.GetFeatures()).OrderBy(f => f.FeatureSection.SectionName);
        #endregion

        return await Task.FromResult(View());
    }

    //public async Task<IActionResult> AddAllFeatures()
    //{
    //    #region GetAllFeatures
    //    ViewBag.FeatureGroups = (await _feature.GetFeatureGroups()).OrderBy(f=>f.GroupName);
    //    ViewBag.FeatureSections = (await _feature.GetFeatureSections()).OrderBy(f=>f.FeatureGroup.GroupName);
    //    ViewBag.Features = (await _feature.GetFeatures()).OrderBy(f=>f.FeatureSection.SectionName);
    //    #endregion
    //    ViewBag.FeatureGroupId = new SelectList((await _feature.GetFeatureGroups()).OrderBy(f=>f.GroupName), "Id", "GroupName");
    //    ViewBag.FeatureSectionId = new SelectList((await _feature.GetFeatureSections()).OrderBy(f=>f.SectionName), "Id", "SectionName");
    //    return await Task.FromResult(View());
    //}

    //////////////// FEATURE GROUP START ////////////////

    public async Task<IActionResult> GetFeatureGroups()
    {
        var feature = (await _feature.GetFeatureGroups()).OrderBy(f => f.GroupName);
        return await Task.FromResult(View(feature));
    }

    public async Task<IActionResult> GetFeatureSectionsByFeatureGroup(int Id)//id==FeatureGroupId
    {
        var feature = (await _feature.RelatedFeatureSections(Id)).OrderBy(f => f.SectionName);
        return await Task.FromResult(View(feature));
    }
    public async Task<IActionResult> AddFeatureGroup()
    {
        ViewBag.FeatureGroups = (await _feature.GetFeatureGroups()).OrderBy(f => f.GroupName);
        return await Task.FromResult(View());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddFeatureGroup(FeatureGroup featureGroup)
    {
        if (ModelState.IsValid)
        {
            if (await _feature.AddFeatureGroup(featureGroup))
            {
                return RedirectToAction(nameof(AddFeatureGroup));
            }
        }
        return RedirectToAction(nameof(AddFeatureGroup));
    }

    public async Task<IActionResult> EditFeatureGroup(int Id)
    {
        var feature = await _feature.GetFeatureGroup(Id);
        if (feature != null)
        {
            return await Task.FromResult(View(feature));
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditFeatureGroup(FeatureGroup featureGroup)
    {
        if (ModelState.IsValid)
        {
            if (await _feature.EditFeatureGroup(featureGroup))
            {
                return RedirectToAction(nameof(GetFeatureGroups));
            }
        }
        TempData["Message"] = false;
        return RedirectToAction(nameof(GetFeatureGroups));
    }

    public async Task<IActionResult> FeatureGroupDetails(int Id)
    {
        var feature = await _feature.GetFeatureGroup(Id);
        if (feature != null)
        {
            ViewBag.RelatedFeatureSections = await _feature.RelatedFeatureSections(Id);
            return await Task.FromResult(View(feature));
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> FeatureGroupDelete(int Id)
    {
        var feature = await _feature.GetFeatureGroup(Id);
        if (feature != null)
        {
            return PartialView(feature);
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> FeatureGroupDelete(FeatureGroup featureGroup)
    {
        if (await _feature.DeleteFeatureGroup(featureGroup.Id))
        {
            return RedirectToAction(nameof(GetFeatureGroups));
        }
        return RedirectToAction(nameof(GetFeatureGroups));
    }

    //////////////// FEATURE GROUP END ////////////////


    //////////////// FEATURE SECTION START ////////////////

    public async Task<IActionResult> GetFeatureSections()
    {
        var feature = (await _feature.GetFeatureSections()).OrderBy(f => f.FeatureGroup.GroupName);
        return await Task.FromResult(View(feature));
    }

    public async Task<IActionResult> AddFeatureSection()
    {
        ViewBag.FeatureGroupId = new SelectList((await _feature.GetFeatureGroups()).OrderBy(f => f.GroupName), "Id", "GroupName");
        ViewBag.FeatureSections = (await _feature.GetFeatureSections()).OrderBy(f => f.FeatureGroup.GroupName);
        return await Task.FromResult(View());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddFeatureSection(FeatureSection featureSection)
    {
        if (ModelState.IsValid)
        {
            if (await _feature.AddFeatureSection(featureSection))
            {
                return RedirectToAction(nameof(AddFeatureSection));
            }
        }
        return RedirectToAction(nameof(AddFeatureSection));
    }

    public async Task<IActionResult> EditFeatureSection(int Id)
    {
        var feature = await _feature.GetFeatureSection(Id);
        if (feature != null)
        {
            ViewBag.FeatureGroupId = new SelectList((await _feature.GetFeatureGroups()).OrderBy(f => f.GroupName), "Id", "GroupName");
            return await Task.FromResult(View(feature));
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditFeatureSection(FeatureSection featureSection)
    {
        if (ModelState.IsValid)
        {
            if (await _feature.EditFeatureSection(featureSection))
            {
                return RedirectToAction(nameof(GetFeatureSections));
            }
        }
        return RedirectToAction(nameof(GetFeatureSections));
    }


    public async Task<IActionResult> FeatureSectionDetails(int Id)
    {
        var feature = await _feature.GetFeatureSection(Id);
        if (feature != null)
        {
            ViewBag.RelatedFeature = await _feature.RelatedFeature(Id);
            return await Task.FromResult(View(feature));
        }
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> FeatureSectionDelete(int Id)
    {
        var feature = await _feature.GetFeatureSection(Id);
        if (feature != null)
        {
            return PartialView(feature);
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> FeatureSectionDelete(FeatureSection featureSection)
    {
        if (await _feature.DeleteFeatureSection(featureSection.Id))
        {
            return RedirectToAction(nameof(GetFeatureSections));
        }
        return RedirectToAction(nameof(GetFeatureSections));
    }

    //////////////// FEATURE SECTION END ////////////////

    //////////////// FEATURE START ////////////////
    public async Task<IActionResult> GetFeatures()
    {
        var feature = (await _feature.GetFeatures()).OrderBy(f => f.FeatureSection.SectionName);
        return await Task.FromResult(View(feature));
    }
    public async Task<IActionResult> AddFeature()
    {
        ViewBag.FeatureSectionId = new SelectList((await _feature.GetFeatureSections()).OrderBy(f => f.SectionName), "Id", "SectionName");
        return await Task.FromResult(View());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddFeature(Feature feature)
    {
        if (ModelState.IsValid)
        {
            if (await _feature.AddFeature(feature))
            {
                return RedirectToAction(nameof(AddFeature));
            }
        }
        return RedirectToAction(nameof(AddFeature));
    }

    public async Task<IActionResult> EditFeature(int Id)
    {
        var feature = await _feature.GetFeature(Id);
        if (feature!=null)
        {
            ViewBag.FeatureSectionId = new SelectList((await _feature.GetFeatureSections()).OrderBy(f => f.SectionName), "Id", "SectionName");
            return await Task.FromResult(View(feature));
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> EditFeature(Feature feature)
    {
        if (ModelState.IsValid) 
        {
            if (await _feature.EditFeature(feature))
            {
                return RedirectToAction(nameof(GetFeatures));
            }
        }
            return RedirectToAction(nameof(GetFeatures));
    }

    public async Task<IActionResult> FeatureDetails(int Id)
    {
        var feature = await _feature.GetFeature(Id);
        if (feature != null)
        {
            return await Task.FromResult(View(feature));
        }
        return RedirectToAction(nameof(GetFeatures));
    }


    public async Task<IActionResult> FeatureDelete(int Id)
    {
        var feature = await _feature.GetFeature(Id);
        if (feature != null)
        {
            return PartialView(feature);
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> FeatureDelete(Feature feature)
    {
        if (await _feature.DeleteFeature(feature.Id))
        {
            return RedirectToAction(nameof(GetFeatures));
        }
        return RedirectToAction(nameof(GetFeatures));
    }


    //////////////// FEATURE END ////////////////
}
