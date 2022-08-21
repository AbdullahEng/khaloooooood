using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class AcceptebleIformationAnd_Details
    {
        [Display(Name = "Status of admission")]
        public string Status_of_Admission_elgibility { get; set; }
        [Display(Name = "studnet Name")]
        public string studnet_name { get; set; }
        [Display(Name = "Country")]
        public string cuntry { get; set; }
        [Display(Name = "Accepted wish")]
        public string Accepted_wish { get; set; }
        [Display(Name = "Rate")]
        public float The_rate { get; set; }
        [Display(Name = "University ID")]
        public string University_ID { get; set; }

    }
}
