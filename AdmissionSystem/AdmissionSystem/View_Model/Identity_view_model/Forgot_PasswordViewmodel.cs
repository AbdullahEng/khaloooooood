using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model.Identity_view_model
{
    public class Forgot_PasswordViewmodel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
