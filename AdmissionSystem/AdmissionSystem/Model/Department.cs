using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Department
    {
        public int id { get; set; }
        public string specialization_name { get; set; }
        public int FK_facultyId { get; set; }//one_to_many relationship
        public Faculty FK_faculty { get; set; }//one_to_many relationship
    }
}
