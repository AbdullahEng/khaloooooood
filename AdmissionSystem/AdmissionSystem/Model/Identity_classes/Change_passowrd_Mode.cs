using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.Identity_classes
{
    public class Change_passowrd_Mode
    {
      
        [Required,DataType(DataType.Password),Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string NewPassowrd { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm New Password")]
        [Compare("NewPassowrd", ErrorMessage ="confirm new password does not match")]
        public string ConfirmNerPassword { get; set; }

    }
}
