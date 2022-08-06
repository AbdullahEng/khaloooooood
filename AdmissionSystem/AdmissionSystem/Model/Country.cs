using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Country
    {
        public int id { get; set; }
        [Display(Name="Country name")]
        [StringLength(20)]
        [Required]
        public string country_name { get; set; }
       // public Persentage_count_for_each__country FK_persentage_count_for_each__country { get; set; }//one_to_one relashionship

    }
}
