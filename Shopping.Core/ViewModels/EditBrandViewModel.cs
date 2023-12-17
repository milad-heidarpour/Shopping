using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Core.ViewModels;

public class EditBrandViewModel
{
    [Display(Name = "کد برند")]
    public Guid Id { get; set; }

    [Display(Name = "نام برند به انگلیسی")]
    public string BrandEnName { get; set; }

    [Display(Name = "نام برند به فارسی")]
    public string BrandFaName { get; set; }

    [Display(Name = "درباره برند")]
    public string? BrandDes { get; set; }

    [Display(Name = "تصویر برند")]
    public string? BrandImg { get; set; }

    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;
}
