using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model.Identity_view_model
{
    public class LoginViewModle
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
        public string sitkey { get; set; }
       // public string Error { get; set; }
        //[Required]
        //public string token { get; set; }

    }
}
