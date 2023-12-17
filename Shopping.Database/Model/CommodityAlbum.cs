using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Database.Model;

public class CommodityAlbum
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CommodityId { get; set; }

    [Required]
    public string CommodityImg { get; set; }



    [ForeignKey(nameof(CommodityId))]
    public virtual Commodity? Commodity { get; set; }
}
