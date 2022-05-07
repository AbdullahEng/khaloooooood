using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class Department_faculty_view_model
    {
        public int id { get; set; }
        public string specialization_name { get; set; }
        public int facultyid { get; set; }
        public List<Faculty> facultylist { get; set; }
    }
}
