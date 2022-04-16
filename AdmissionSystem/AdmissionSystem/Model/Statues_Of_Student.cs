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
        public int FK_Student_InfoId { get; set; }//sorry i modify it ^_^//one_to_one relationship
        public Student FK_Student_Info { get; set; }//If you like modify the name to FK_Student_Info //sorry i modify it ^_^//one_to_one relationship
        public int FK_Employee_InfoId { get; set; }//sorry i modify it ^_^
        public Employee FK_Employee_Info { get; set; }//If you like modify the name to FK_Employee_Info 
    }
}
