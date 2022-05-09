using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model.Identity_view_model
{
    public class RegisterViewModel
    {
        [Required]
        public string  UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string  password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string  ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int TheIDnumber { get; set; }

    }
}
