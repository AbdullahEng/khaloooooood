using AdmissionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.View_Model
{
//this class is smilar to Department_Relation_Type class but i added departmentName prperty on it to make the select list show a name 
    public class Wishes
    {
        public int id { get; set; }
        public Department FK_Department { get; set; }
        public string DepartmentName { get; set; }
        public Type_of_high_school_Cirtificate FK_type_Of_High_School_Cirtificate { get; set; }//one_to_many relationship
        public double Minemum_of_Rate { get; set; }
        public double Rate_of_chaire_count { get; set; }
    }
}
