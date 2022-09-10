using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Type_of_high_school_Cirtificate
    {
        public int id { get; set; }
        [Display(Name= "Type of high school Cirtificate ")]
        [Required]
        [StringLength(15)]
        public string type { get; set; }
    }
}
