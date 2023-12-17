using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Core.ViewModels;

public class EditClassificationViewModel
{
    public Guid Id { get; set; }
    public string GroupEnName { get; set; }
    public string GroupFaName { get; set; }
    public string? GroupImg { get; set; }
    public string? GroupDes { get; set; }
    public bool NotShow { get; set; } = false;
}
