using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
    public class Student_Wishes_View_Model
    {
        public int id { get; set; }
        public List<Wishes> specializtions { get; set; }
        public int wish_Department_Id1 { get; set; }
        public int wish_Department_Id2 { get; set; }
        public int wish_Department_Id3 { get; set; }
    }
}
