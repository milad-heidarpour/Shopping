using Shopping.Database.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Shopping.Core.ViewModels;

public class RegisterViewModel
{
    //[Display(Name = "نام", Prompt = "نام خود را وارد کنید")]
    //public string? FName { get; set; }


    //[Display(Name = "نام خانوادگی", Prompt = "نام خانوادگی خود را وارد کنید")]
    //public string? LName { get; set; }


    //public string? ProfileImg { get; set; }

    //public int Code { get; set; }


    //public string BirthDate { get; set; }

    [Required(ErrorMessage = "شماره موبایل 11 رقمی را وارد نمایید")]
    [Display(Name = "Mobile", Prompt = "شماره موبایل 11 رقمی")]
    [MaxLength(11)]
    [MinLength(11)]
    public string PhoneNumb { get; set; }

    [Required(ErrorMessage = "رمز عبور را وارد نمایید")]
    [Display(Name = "Password", Prompt = "رمز عبور حداقل 8 کارکتر")]
    [MinLength(8, ErrorMessage = "رمز عبور حداقل 8 کارکتر")]
    [MaxLength(25, ErrorMessage = "رمز عبور حداکثر 25 کارکتر")]
    [DataType(DataType.Password)]

    public string Password { get; set; }

    [Required(ErrorMessage = "تکرار رمز عبور را وارد نمایید")]
    [Display(Name = "Password", Prompt = "تکرار رمز عبور")]
    [MinLength(8, ErrorMessage = "تکرار رمز عبور حداقل 8 کارکتر")]
    [MaxLength(25, ErrorMessage = "تکرار رمز عبور حداکثر 25 کارکتر")]
    [DataType(DataType.Password)]

    public string RePassword { get; set; }


    [Display(Name = "جنسیت")]
    public string? Gender { get; set; }

}
