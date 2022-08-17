using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class AlgorithemViewModel
    {
        public List<Country> CountryList { get; set; }
        [Required]
        public int countryId { get; set; }

    }
}
