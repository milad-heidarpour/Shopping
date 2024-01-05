using Shopping.Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.ViewModels
{
    public class EditCommodityViewModel
    {
        [Display(Name = "کد کالا")]
        public Guid Id { get; set; }


        [Display(Name = "انتخاب برند")]
        public Guid BrandId { get; set; }


        [Display(Name = "انتخاب طبقه بندی")]
        public Guid GroupId { get; set; }


        [Display(Name = "نام کالا")]
        public string ProductFaName { get; set; }


        [Display(Name = "نام کالا")]
        public string ProductEnName { get; set; }


        [Display(Name = "تصویر کالا")]
        public string ProductImg { get; set; }


        [Display(Name = "قیمت کالا")]
        public int Price { get; set; }



        [Display(Name = "درصد تخفیف")]
        public int Discount { get; set; } = 0;



        [Display(Name = "موجودی")]
        public int Inventory { get; set; }


        [Display(Name = "توضیحات")]
        public string Introduction { get; set; }



        [Display(Name = "عدم نمایش")]
        public bool NotShow { get; set; } = false;


        [Display(Name = "تاریخ ثبت کالا")]
        public string? RegisterDate { get; set; }

        [Display(Name = "تاریخ بروزرسانی")]
        public string? UpdateDate { get; set; } = null;

    }
}
