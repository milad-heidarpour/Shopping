
using System.ComponentModel.DataAnnotations;

namespace Shopping.Database.Model;

public class FeatureGroup
{
    [Key]
    [Display(Name = "کد گروه ویژگی")]
    public int Id { get; set; }

    [Required]
    [Display(Name = "عنوان")]
    public string GroupName { get; set; }

    public virtual ICollection<FeatureSection>? FeatureSections { get; set; }

}
