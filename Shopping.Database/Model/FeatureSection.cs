
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class FeatureSection
{
    [Key]
    [Display(Name = "کد قسمت ویژگی")]
    public int Id { get; set; }


    [Required]
    [Display(Name = "انتخاب گروه ویژگی")]
    public int FeatureGroupId { get; set; }


    [Required]
    [Display(Name = "عنوان قسمت ویژگی")]
    public string SectionName { get; set; }



    [ForeignKey(nameof(FeatureGroupId))]
    public virtual FeatureGroup? FeatureGroup { get; set; }
    public virtual ICollection<Feature>? Features { get; set; }
}
