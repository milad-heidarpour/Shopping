using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class Brand
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "کد برند")]
    public Guid Id { get; set; }


    [Required(ErrorMessage = "نام برند الزامی است")]
    [Display(Name = "نام برند به انگلیسی")]
    public string BrandEnName { get; set; }


    [Required(ErrorMessage = "نام برند الزامی است")]
    [Display(Name = "نام برند به فارسی")]
    public string BrandFaName { get; set; }


    [Display(Name = "درباره برند")]
    public string? BrandDes { get; set; }

    [Required]
    [Display(Name = "تصویر برند")]
    public string BrandImg { get; set; }


    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;



    public virtual ICollection<Commodity>? Commodities { get; set; }

}
