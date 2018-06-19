using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WE_CIS_186.Models
{
    public class UserValidate
    {
        [Required(ErrorMessage = "This field is required.")]
        public string username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}