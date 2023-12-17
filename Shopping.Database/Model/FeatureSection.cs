
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class FeatureSection
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int FeatureGroupId { get; set; }
    [Required]
    public string SectionName { get; set; }

    [ForeignKey(nameof(FeatureGroupId))]
    public virtual FeatureGroup? FeatureGroup { get; set; }
    public virtual ICollection<Feature>? Features { get; set; }
}
