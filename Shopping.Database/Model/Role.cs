using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Database.Model;

public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "کد نقش")]
    public Guid Id { get; set; }

    [Required]
    [Display(Name = "نام نقش")]
    public string RoleEnName { get; set; }//en


    [Required]
    [Display(Name = "نام نقش")]
    public string RoleFaName { get; set; }//fa


    public virtual ICollection<User> Users { get; set; }

}
