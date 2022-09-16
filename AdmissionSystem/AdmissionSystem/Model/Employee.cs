using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Nick_Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string The_ID_Number { get; set; }//abd
        public string Type { get; set; }//abd
        public string Gender { get; set; }//abd
        public DateTime Birth { get; set; }//abd
    }
}
