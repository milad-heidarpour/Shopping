

using Shopping.Database.Model;

namespace Shopping.Core.ViewModels;

public class CompareViewModel
{
    public Commodity Commodity1 { get; set; }
    public Commodity? Commodity2 { get; set; }
    public Commodity? Commodity3 { get; set; }
    public Commodity? Commodity4 { get; set; }
    public IEnumerable<Commodity> Commodities { get; set; }
}
