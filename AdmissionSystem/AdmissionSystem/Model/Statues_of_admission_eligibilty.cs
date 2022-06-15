using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Statues_of_admission_eligibilty
    {

        public int id { get; set; }
        public string Type_of_admission_eligibilty{ get; set; }
        public DateTime Begaining_date_of_the_process { get; set; }
        public int semester_no { get; set; }
        public DateTime semester_Date { get; set; }
        // we have to add this prop to controller
        // للعدد الطلاب المسموح قبولهم من قبل الوزارة 
        public int Number_Student  { get; set; }

    }
}
