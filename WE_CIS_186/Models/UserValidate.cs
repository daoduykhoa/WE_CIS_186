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
        public string loginUsername { get; set; }

        [DataType(DataType.Password)]
        public string loginPassword { get; set; }


        //===========================Register===============================//

        public string registerUsername { get; set; }

        [DataType(DataType.Password)]
        public string registerPassword { get; set; }
        
    }
}