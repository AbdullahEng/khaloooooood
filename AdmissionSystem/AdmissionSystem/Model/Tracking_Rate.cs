using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Tracking_Rate
    {
        public int id { get; set; }
        public float old_rate { get; set; }
        public float new_rate { get; set; }
        public string old_country { get; set; }
        public string new_country { get; set; }
        public string old_typeofcertificate { get; set; }
        public string new_typeofcertificate { get; set; }
        public DateTime Date_Of_Modification { get; set; }
        public int FK_Student_InfoId { get; set; }//sorry i modify it ^_^
        public Student FK_Student_Info { get; set; }//sorry i modify it ^_^
                                                    //  public int FK_Employee_InfoId { get; set; }//Modifid AB
        public Employee FK_Employee_Info { get; set; }//sorry i modify it ^_^


    }
}
