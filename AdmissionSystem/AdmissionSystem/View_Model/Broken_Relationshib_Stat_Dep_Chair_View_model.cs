using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class Broken_Relationshib_Stat_Dep_Chair_View_model
    {
        public int id { get; set; }
        //  public int FK_statues_Of_Admission_EligibiltyId { get; set; }//one_to_many relationship
        public int status_of_admi_eligi_id { get; set; }
        public List<Statues_of_admission_eligibilty> FK_statues_Of_Admission_Eligibilty { get; set; }//one_to_many relationship
        public int department_id { get; set; }                                                     //   public int Fk_departmentId { get; set; }//one_to_many relationship
        public List<Department> Fk_department { get; set; }//one_to_many relationship
        public int Chair_count { get; set; }
    }
}
