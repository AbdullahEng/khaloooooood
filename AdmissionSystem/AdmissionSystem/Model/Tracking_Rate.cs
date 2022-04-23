using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Tracking_Rate
    {
        public int id { get; set; }
         public int old_rate { get; set; }
        public int new_rate { get; set; }
        public int FK_Student_InfoId { get; set; }//sorry i modify it ^_^
        public Student FK_Student_Info { get; set; }//sorry i modify it ^_^
    //  public int FK_Employee_InfoId { get; set; }//Modifid AB
      public Employee FK_Employee_Info { get; set; }//sorry i modify it ^_^
  
      
    }
}
