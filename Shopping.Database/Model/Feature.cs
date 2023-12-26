

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class Feature
{
    [Key]
    [Display(Name = "کد ویژگی")]
    public int Id { get; set; }


    [Required]
    [Display(Name = "انتخاب قسمت ویژگی")]
    public int FeatureSectionId { get; set; }


    [Required]
    [Display(Name = "عنوان ویژگی")]
    public string Title { get; set; }



    [ForeignKey(nameof(FeatureSectionId))]
    public virtual FeatureSection? FeatureSection { get; set; }
}
