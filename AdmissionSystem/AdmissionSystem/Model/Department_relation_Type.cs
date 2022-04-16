using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Department_relation_Type
    {
        public int id { get; set; }
        public int FK_DepartmentId { get; set; }//one_to_many relationship
        public Department FK_Department { get; set; }//one_to_many relationship
        public int FK_type_Of_High_School_CirtificateId { get; set; }//one_to_many relationship
        public Type_of_high_school_Cirtificate FK_type_Of_High_School_Cirtificate { get; set; }//one_to_many relationship
        public double Minemum_of_Rate  { get; set; }
        public double Rate_of_chaire_count { get; set; } 

        public int FK_Admission_Eligibilty_Requist_For_UNsy_Certificate1Id { get; set; }//one_to_one relationship
        public Admission_Eligibilty_Requist_For_UNsy_Certificate FK_Admission_Eligibilty_Requist_For_UNsy_Certificate1 { get; set; }//one_to_one relationship
        public int FK_Admission_Eligibilty_Requist_For_UNsy_Certificate2Id { get; set; }//one_to_one relationship
        public Admission_Eligibilty_Requist_For_UNsy_Certificate FK_Admission_Eligibilty_Requist_For_UNsy_Certificate2 { get; set; }//one_to_one relationship
        public int FK_Admission_Eligibilty_Requist_For_UNsy_Certificate3Id { get; set; }//one_to_one relationship
        public Admission_Eligibilty_Requist_For_UNsy_Certificate FK_Admission_Eligibilty_Requist_For_UNsy_Certificate3 { get; set; }//one_to_one relationship
    }
}
