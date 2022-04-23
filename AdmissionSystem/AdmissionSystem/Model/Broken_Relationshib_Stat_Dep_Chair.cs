using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Broken_Relationshib_Stat_Dep_Chair
    {
        public int id { get; set; }
      //  public int FK_statues_Of_Admission_EligibiltyId { get; set; }//one_to_many relationship
        public Statues_of_admission_eligibilty FK_statues_Of_Admission_Eligibilty { get; set; }//one_to_many relationship
     //   public int Fk_departmentId { get; set; }//one_to_many relationship
        public Department Fk_department { get; set; }//one_to_many relationship
        public int Chair_count { get; set; }
    }
}
