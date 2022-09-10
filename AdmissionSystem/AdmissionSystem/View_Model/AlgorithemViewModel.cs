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
        public List<Department> departmentList { get; set; }
        public int DepartmentId { get; set; }
        public List<Statues_of_admission_eligibilty> statues_Of_Admission_Eligibiltieslist{ get; set; }
        public int statusofAdmissionId { get; set; }
        public List<AcceptebleIformationAnd_Details> Accinfo{ get; set; }
    }
}
