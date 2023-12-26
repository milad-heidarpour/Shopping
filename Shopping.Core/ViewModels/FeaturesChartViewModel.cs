
using Shopping.Database.Model;
using System.Text.RegularExpressions;

namespace Shopping.Core.ViewModels;

public class FeaturesChartViewModel
{
    public IEnumerable<FeatureGroup>? FeatureGroups { get; set; } = null;
    public IEnumerable<FeatureSection>? FeatureSections { get; set; } = null;
    public IEnumerable<Feature>? Features { get; set; } = null;

}
