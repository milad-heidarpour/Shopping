using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Database.Model;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "کد کاربری")]
    public Guid Id { get; set; }


    [Required]
    [Display(Name = " کد نقش کاربر")]
    public Guid RoleId { get; set; }//foreign key

    [Display(Name = "نام")]
    public string? FName { get; set; }


    [Display(Name = "نام خانوادگی")]
    public string? LName { get; set; }


    public string? ProfileImg { get; set; }


    //public string BirthDate { get; set; }


    [Required]
    [Display(Name = "شماره تلفن")]
    [MaxLength(11)]
    [MinLength(11)]
    public string PhoneNumb { get; set; }


    [Required]
    [Display(Name = "رمز عبور")]

    public string Password { get; set; }


    [Required]
    [Display(Name = "تکرار رمز عبور")]

    public string RePassword { get; set; }


    [Required]
    [Display(Name = "جنسیت")]
    public string Gender { get; set; }

    [Required]
    [Display(Name = "تاریخ ثبت نام")]
    public string RegisterDate { get; set; }


    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; }
}
