using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class CommodityAlbum
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "کد آلبوم")]
    public Guid Id { get; set; }

    [Required]
    [Display(Name = "کد شناسایی محصول")]
    public Guid CommodityId { get; set; }

    [Required]
    [Display(Name = "انتخاب عکس")]
    public string CommodityImg { get; set; }



    [ForeignKey(nameof(CommodityId))]
    public virtual Commodity? Commodity { get; set; }
}
