using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Statues_Of_Student
    { public int id { get; set; }
        public DateTime Date_of_Acshiving { get; set; }
        public bool Checked_recipet { get; set; }
        public bool Checked_Identity { get; set; }
        public bool Checked_city_certificate { get; set; }
        public bool Checked_Rate { get; set; }
        public int Studentid { get; set; }
        public Student Student_Info { get; set; }
        public Employee Employee_Info { get; set; }
    }
}
