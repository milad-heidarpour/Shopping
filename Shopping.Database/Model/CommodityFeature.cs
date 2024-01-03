using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Database.Model;

public class CommodityFeature
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    public Guid CommodityId { get; set; }


    [Required]
    public int FeatureId { get; set; }


    [Required]
    public string Value { get; set; }



    [ForeignKey(nameof(CommodityId))]
    public virtual Commodity Commodity { get; set; }



    [ForeignKey(nameof(FeatureId))]
    public virtual Feature Feature { get; set; }
}
