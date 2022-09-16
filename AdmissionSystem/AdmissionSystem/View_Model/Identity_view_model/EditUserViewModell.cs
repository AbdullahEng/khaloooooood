using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model.Identity_view_model
{
    public class EditUserViewModell
    {
        public EditUserViewModell()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{9}([0-9]{2})?$",
        ErrorMessage = "Characters are not allowed and only 11 for identity and 9 for passport.")]
        public string IDNumber { get; set; }
        public List<string> Claims { get; set; }
        public List<string> Roles{ get; set; }        
    }
}
