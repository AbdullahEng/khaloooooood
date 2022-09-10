using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model.Identity_view_model
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string  Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Confirm Password")]
       [Compare("Password",ErrorMessage ="Passowrd and confirm password must match")]
        public string ConfirmPassword { get; set; }
        public string token { get; set; }

    }
}
