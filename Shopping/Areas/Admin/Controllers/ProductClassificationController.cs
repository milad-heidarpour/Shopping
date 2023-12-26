using Microsoft.AspNetCore.Mvc;
using Shopping.Core.Interface;
using Shopping.Core.ViewModels;
using Shopping.Database.Model;
using System.Drawing.Drawing2D;

namespace Shopping.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductClassificationController : Controller
{
    string imgPath = "wwwroot/Images/ProductClassification";

    IBrand _brand;
    ICommodity _commodity;
    IClassification _classification;
    public ProductClassificationController(IBrand brand,ICommodity commodity,IClassification classification)
    {
        _brand = brand;
        _commodity = commodity;
        _classification = classification;
    }
    public async Task<IActionResult> Index()
    {
        var classifications = await _classification.GetProductClassifications();
        return View(classifications);
    }

    public async Task<IActionResult> CreateClassification()
    {
        ViewBag.ClassificationId=Guid.NewGuid();
        return await Task.FromResult(View());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateClassification(ProductClassification classification, IFormFile ClsfLogo)
    {
        if (ModelState.IsValid)
        {
            if (await _classification.AddClassification(classification,ClsfLogo))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ClassificationId = Guid.NewGuid();
            ModelState.AddModelError("GroupEnName", "خطا در ثبت برند");
        }
        ViewBag.ClassificationId = Guid.NewGuid();
        return await Task.FromResult(View(classification));
    }

    public async Task<IActionResult> ClassificationDetails(Guid Id)//id= classificationId
    {
        var classification = await _classification.GetProductClassification(Id);
        ViewBag.RelatedCommodity = (await _commodity.GetClassificationCommodities(Id)).Take(5)/*.OrderByDescending(c=>c.RegisterDate)*/;  
        //به ترتیب جدید ترین ها محصول ها را گرفتم
        //اینجا باید مثلا 5 تا محصول بفرستم که دکمه نمایش بیشتر رو دز بره اون محصولایی که تو این دسته بندی هستن رو نمایش بده
        //بعد باید همه محصولات رئ نشون بدم اونایی که عدم نمایش هستن رو روش قرمز بنویسم نه عدم نمایش 
        //اونایی که عکس ندارن هم باید بگم که عکسی برای محصول وجود ندارد
        return await Task.FromResult(View(classification));
    }

    public async Task<IActionResult> EditClassificationTitle(Guid Id)//id==classificationId 
    {
        var classification=await _classification.GetProductClassification(Id);
        if (classification!=null)
        {
            EditClassificationViewModel viewModel = new EditClassificationViewModel()
            {
                Id = classification.Id,
                GroupEnName = classification.GroupEnName,
                GroupFaName = classification.GroupFaName,
                GroupImg = classification.GroupImg,
                GroupDes = classification.GroupDes,
                NotShow = classification.NotShow,
            };
            return await Task.FromResult(View(viewModel));
        }
        return RedirectToAction(nameof(Index));

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditClassificationTitle(EditClassificationViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _classification.EditClassification(viewModel))
            {
                return RedirectToAction(nameof(ClassificationDetails), new { Id = viewModel.Id });
            }
            return await Task.FromResult( View(viewModel));
        }
        return await Task.FromResult(View(viewModel));
    }


    public async Task<IActionResult> EditClassificationImg(Guid Id)//id==classificationId 
    {
        var classification = await _classification.GetProductClassification(Id);
        if (classification!=null) 
        {
            EditClassificationViewModel viewModel = new EditClassificationViewModel()
            {
                Id = classification.Id,
                GroupEnName = classification.GroupEnName,
                GroupFaName = classification.GroupFaName,
                GroupImg = classification.GroupImg,
                GroupDes = classification.GroupDes,
                NotShow = classification.NotShow,
            };

            var previousImg = viewModel.GroupImg;
            TempData["Img"] = previousImg.ToString();
            return await Task.FromResult(View(viewModel));
        }
        return RedirectToAction(nameof(Index));
        
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditClassificationImg(EditClassificationViewModel viewModel,IFormFile ClassificationImg)
    {
        if (ModelState.IsValid)
        {
            if (await _classification.EditClassificationImg(viewModel,ClassificationImg))
            {
                //for deleting previous image
                var previousimg = (TempData["Img"]).ToString();
                string ExitingFile = Path.Combine(imgPath, previousimg);
                System.IO.File.Delete(ExitingFile);
                //end deleting previous image

                ViewBag.RelatedCommodity = (await _commodity.GetClassificationCommodities(viewModel.Id)).Take(5);
                return RedirectToAction(nameof(ClassificationDetails), new { Id = viewModel.Id });
            }
            return await Task.FromResult(View(viewModel));
        }
        ModelState.AddModelError("GroupEnName", " ویرایش امکان پذیر نمی باشد");
        return await Task.FromResult(View(viewModel));
    }


    public async Task<IActionResult> DeleteClassification(Guid Id)
    {
        var classsification = await _classification.GetProductClassification(Id);
        if (classsification!=null)
        {
            return PartialView(classsification);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteClassification(ProductClassification classification)
    {
        var Previousimg = (await _classification.GetProductClassification(classification.Id)).GroupImg;
        if (await _classification.DeleteClassification(classification.Id))
        {
            string ExitingFile = Path.Combine(imgPath, Previousimg);
            System.IO.File.Delete(ExitingFile);

            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }
}
