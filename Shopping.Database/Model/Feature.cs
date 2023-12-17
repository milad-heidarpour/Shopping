

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class Feature
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int FeatureSectionId { get; set; }
    [Required]
    public string Title { get; set; }

    [ForeignKey(nameof(FeatureSectionId))]
    public virtual FeatureSection? FeatureSection { get; set; }
}
