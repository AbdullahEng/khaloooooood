using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Statues_of_admission_eligibilty
    {

        public int id { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Type of admission eligibilty")]
        public string Type_of_admission_eligibilty{ get; set; }
        //[DisplayFormat(ApplyFormatInEditMode= true, DataFormatString="{0:yyyy - MM - dd HH: mm}")]
       
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Begaining date of the process")]
        public DateTime Begaining_date_of_the_process { get; set; }
        [Required]
        [Display(Name = "semester")]
        public int semester_no { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "semester Date")]
        public DateTime semester_Date { get; set; }
        // we have to add this prop to controller
        // للعدد الطلاب المسموح قبولهم من قبل الوزارة 
       
        public int Number_Student  { get; set; }

    }
}
