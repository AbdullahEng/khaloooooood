using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Accabtable_config
    {
        public int id { get; set; }
        public int FK_Statues_of_admission_eligibiltyId { get; set; }//one_to_many relationship
        public Statues_of_admission_eligibilty FK_Statues_of_admission_eligibilty { get; set; }//one_to_many relationship
        public int FK_studentId { get; set; }//one_to_one relationship
        public Student FK_student { get; set; }//one_to_one relationship
        public bool Accepted_Wishes { get; set; }

    }
}
