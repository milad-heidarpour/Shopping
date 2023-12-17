
using System.ComponentModel.DataAnnotations;

namespace Shopping.Database.Model;

public class FeatureGroup
{
    [Key]
    public int Id { get; set; }

    [Required]

    public string GroupName { get; set; }

    public virtual ICollection<FeatureSection>? FeatureSections { get; set; }

}
