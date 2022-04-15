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
        public int StudentID { get; set; }
        public Student Student_Info { get; set; }
        public Employee Employee_Info { get; set; }

    }
}
