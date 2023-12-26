using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class Commodity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "کد کالا")]
    public Guid Id { get; set; }


    [Required(ErrorMessage = "لطفا برند کالا را انتخاب نمایید")]
    [Display(Name = "انتخاب برند")]
    public Guid BrandId { get; set; }


    [Required]
    [Display(Name = "انتخاب طبقه بندی")]
    public Guid GroupId { get; set; }


    [Required(ErrorMessage = "درج نام کالا (فارسی) الزامی است")]
    [Display(Name = "نام کالا")]
    public string ProductFaName { get; set; }


    [Required(ErrorMessage = "درج نام کالا (انگلیسی) الزامی است")]
    [Display(Name = "نام کالا")]
    public string? ProductEnName { get; set; }


    [Display(Name = "قیمت کالا")]
    [Required(ErrorMessage = "درج قیمت کالا الزامی است")]
    public int Price { get; set; }



    [Display(Name = "درصد تخفیف")]
    public int Discount { get; set; } = 0;



    [Display(Name = "موجودی")]
    [Required(ErrorMessage = "درج تعداد موجودی الزامی است")]
    public int Inventory { get; set; }


    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "درج توضیحات الزامی است")]
    public string Introduction { get; set; }



    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;


    [Display(Name = "تاریخ ثبت کالا")]
    public string? RegisterDate { get; set; }

    [Display(Name ="تاریخ بروزرسانی")]
    public string? UpdateDate { get; set; }=null;

    //[Display(Name ="تعداد فروخته شده")]
    //public int SellCount { get; set; }



    [ForeignKey(nameof(BrandId))]
    public virtual Brand? Brand { get; set; }


    [ForeignKey(nameof(GroupId))]
    public virtual ProductClassification? Group { get; set; }

    public virtual ICollection<CommodityAlbum>? CommodityAlbums { get; set; }

}
