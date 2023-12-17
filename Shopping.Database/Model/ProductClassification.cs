using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class ProductClassification
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "کد طبقه بندی کالا")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "نام طبقه بندی محصول الزامی است")]
    [Display(Name = "نام طبقه بندی به انگلیسی")]
    public string GroupEnName { get; set; }


    [Required(ErrorMessage = "نام طبقه بندی محصول الزامی است")]
    [Display(Name = "نام طبقه بندی به فارسی")]
    public string GroupFaName { get; set; }

    [Display(Name = "تصویر طبقه بندی")]
    public string GroupImg { get; set; }


    [Display(Name = "درباره طبقه بندی")]
    public string? GroupDes { get; set; }


    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;


    public virtual ICollection<Commodity>? Commodities { get; set; }
}
