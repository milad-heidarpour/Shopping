using Shopping.Database.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Core.ViewModels;

public class CreateCommodityFeatureViewModel
{
    public Guid Id { get; set; }

    public Guid CommodityId { get; set; }

    public int FeatureGroupId { get; set; }


    public int FeatureSectionId { get; set; }


    public int FeatureId { get; set; }

    public string Value { get; set; }

    public virtual Commodity Commodity { get; set; }

    public virtual Feature Feature { get; set; }
}
