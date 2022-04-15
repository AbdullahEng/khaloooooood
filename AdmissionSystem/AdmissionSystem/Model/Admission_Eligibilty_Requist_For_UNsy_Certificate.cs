using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model
{
    public class Admission_Eligibilty_Requist_For_UNsy_Certificate
    {   public int id { get; set; }
        public int The_Rate { get; set; }
        public string city_of_high_school_cirtificate { get; set; }
        public DateTime date_of_high_school_cirtificate { get; set; }
        public string Image_of_crtificat_URL { get; set; }//ما العمل اذا كانت الشهادة من اكثر من صورة 
        public string check_recipt_image_URL { get; set; }
      
        /// for syrian student 
        public string LAnguge_of_the_addmintion { get; set; }
        public string Subscription_number { get; set; }
        public int course_number { get; set; }
       
      //  public Department_relation_type1 wish1 { get; set; }
     //   public Department_relation_type2 wish1 { get; set; }
      //  public Department_relation_type3 wish1 { get; set; }

        public int StudentId { get; set; } //(FK)
        public Student student_Info { get; set; }
        public Type_of_high_school_Cirtificate Type_of_high_school_CirtificateID { get; set; }
    }
}
