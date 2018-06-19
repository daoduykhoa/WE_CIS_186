using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WE_CIS_186.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên của bạn")]
        [Display(Name = "Họ và tên:")]
        public string Name { set; get; }

        //[Required(ErrorMessage = "Vui lòng nhập họ tên của bạn")]
        [Display(Name = "Email:")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [Display(Name = "DoB:")]
        public string DoB { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "SĐT:")]
        public string Phone { set; get; }

        [Display(Name = "Địa chỉ:")]
        public string Address { set; get; }
        [Display(Name = "Code:")]
        public string PreCode { set; get; }

    }
}